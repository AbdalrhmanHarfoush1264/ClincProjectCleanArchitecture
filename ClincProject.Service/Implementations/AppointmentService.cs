using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ILogger<AppointmentService> _logger;
        private readonly IGenericRepository<Appointment> _appointmentRepository;
        private readonly IGenericRepository<StatusHistory> _statusHistoryRepository;
        private readonly IGenericRepository<Document> _documentRepository;
        #region Fields

        #endregion

        #region Constructors
        public AppointmentService(ILogger<AppointmentService> logger,
            IGenericRepository<Appointment> appointmentRepository,
            IGenericRepository<StatusHistory> statusHistoryRepository,
            IGenericRepository<Document> documentRepository)
        {
            _logger = logger;
            _appointmentRepository = appointmentRepository;
            _statusHistoryRepository = statusHistoryRepository;
            _documentRepository = documentRepository;
        }
        #endregion

        #region Functions
        public async Task<bool> AddAppointmentAsync(Appointment appointment)
        {
            try
            {
                var result = await _appointmentRepository.AddAsync(appointment);
                if (result == null)
                    return false;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in AddAppointmentAsync");
                throw;
            }
        }

        public async Task<bool> UpdateAppointmentAsync(Appointment appointment)
        {
            try
            {
                var result = await _appointmentRepository.UpdateAsync(appointment);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in UpdateAppointmentAsync");
                throw;
            }
        }

        public async Task<bool> DeleteAppointmentAsync(Appointment appointment)
        {
            try
            {
                var AnyStatusHistoryUesThisId = await _statusHistoryRepository.GetTableNoTracking()
                    .Where(x => x.AppointmentId == appointment.AppointmentId).AnyAsync();
                if (AnyStatusHistoryUesThisId)
                    return false;

                var AnyDocumentUseThisId = await _documentRepository.GetTableNoTracking()
                    .Where(x => x.AppointmentId == appointment.AppointmentId).AnyAsync();

                if (AnyDocumentUseThisId)
                    return false;

                var result = await _appointmentRepository.DeleteAsync(appointment);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteAppointmentAsync");
                throw;
            }
        }

        public async Task<List<Appointment>> GetAppointmentListAsync()
        {
            try
            {
                var result = await _appointmentRepository.GetTableNoTracking()
                    .Include(x => x.Doctor).Include(x => x.AppointmentStatus).Include(x => x.PatientCase)
                    .Include(x => x.PatientCase.Patient).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetAppointmentListAsync");
                throw;
            }
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int Id)
        {
            try
            {
                var result = await _appointmentRepository.GetTableNoTracking()
                    .Where(x => x.AppointmentId == Id)
                    .Include(x => x.Doctor)
                    .Include(x => x.AppointmentStatus)
                    .Include(x => x.PatientCase)
                    .Include(x => x.PatientCase.Patient)
                    .FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetAppointmentByIdAsync");
                throw;
            }
        }

        public async Task<bool> IsAppointmentExistByIdAsync(int Id)
        {
            try
            {
                var result = await _appointmentRepository.GetTableNoTracking()
                     .Where(x => x.AppointmentId == Id).FirstOrDefaultAsync();
                if (result == null)
                    return false;


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsAppointmentExistByIdAsync");
                throw;
            }
        }

        public IQueryable<Appointment> FilterAppointmentPaginatedQuerable(string? DoctorName = null,
            string? PatientName = null, string? statusName = null)
        {

            try
            {
                var query = _appointmentRepository.GetTableNoTracking()
                    .Include(x => x.Doctor)
                    .Include(x => x.AppointmentStatus)
                    .Include(x => x.PatientCase)
                    .Include(x => x.PatientCase.Patient).AsQueryable();


                if (DoctorName != null)
                {
                    query = query.Where(x => (x.Doctor.FirstName.ToLower() + " " + x.Doctor.LastName.ToLower()) == DoctorName.ToLower());
                }
                else if (PatientName != null)
                {
                    query = query.Where(x => (x.PatientCase.Patient.FirstName.ToLower() + " " + x.PatientCase.Patient.LastName.ToLower()) == PatientName.ToLower());
                }
                else if (statusName != null)
                {
                    query = query.Where(x => x.AppointmentStatus.StatusName.ToLower() == statusName.ToLower());
                }


                return query;

            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in FilterAppointmentPaginatedQuerable");
                throw;
            }

        }
        #endregion
    }
}
