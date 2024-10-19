using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class DoctorService : IDoctorService
    {

        #region Fileds
        private readonly ILogger<DoctorService> _logger;
        private readonly IGenericRepository<Doctor> _doctorRepository;
        private readonly IGenericRepository<EmployeeSchedules> _employeeSchedulesRepository;
        private readonly IGenericRepository<Appointment> _appointmentRepository;
        #endregion

        #region Constructors
        public DoctorService(ILogger<DoctorService> logger,
            IGenericRepository<Doctor> doctorRepository,
            IGenericRepository<EmployeeSchedules> employeeSchedulesRepository,
            IGenericRepository<Appointment> appointmentRepository)
        {
            _logger = logger;
            _doctorRepository = doctorRepository;
            _employeeSchedulesRepository = employeeSchedulesRepository;
            _appointmentRepository = appointmentRepository;
        }
        #endregion

        #region Handle Functions


        public async Task<bool> CreateDoctorAsync(Doctor doctor)
        {
            try
            {
                var result = await _doctorRepository.AddAsync(doctor);
                if (result == null)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in CreateDoctorAsync");
                throw;
            }

        }

        public async Task<bool> DeleteDoctorAsync(Doctor doctor)
        {
            try
            {
                var IsemployeeScheduleUseDoctorId = await _employeeSchedulesRepository.GetTableNoTracking()
                    .Where(x => x.DoctorId == doctor.DoctorId).AnyAsync();

                if (IsemployeeScheduleUseDoctorId)
                    return false;

                var IsAppointUseDoctorId = await _appointmentRepository.GetTableNoTracking()
                    .Where(x => x.DoctorId == doctor.DoctorId).AnyAsync();

                if (IsAppointUseDoctorId)
                    return false;

                var result = await _doctorRepository.DeleteAsync(doctor);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteDoctorAsync");
                throw;
            }
        }

        public IQueryable<Doctor> FilterDoctorPaginatedQuerable(string search)
        {
            try
            {
                var query = _doctorRepository.GetTableNoTracking().AsQueryable();
                if (search != null)
                {
                    query = query.Where(x => x.FirstName.ToLower() == search.ToLower()
                    || x.LastName.ToLower() == search.ToLower() || x.Email.ToLower() == search.ToLower());
                }
                return query;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in FilterDoctorPaginatedQuerable");
                throw;
            }
        }
        public async Task<bool> IsDoctorExistById(int Id)
        {
            try
            {
                var result = await _doctorRepository.GetTableNoTracking().Where(x => x.DoctorId == Id).FirstOrDefaultAsync();
                if (result == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsDoctorExistById");
                throw;
            }
        }

        public async Task<Doctor> GetDoctorByIdAsync(int Id)
        {
            try
            {
                var result = await _doctorRepository.GetByIdAsync(Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetDoctorByIdAsync");
                throw;
            }
        }

        public async Task<List<Doctor>> GetDoctorListAsync()
        {
            try
            {
                var result = await _doctorRepository.GetTableNoTracking().ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetDoctorListAsync");
                throw;
            }
        }

        public async Task<bool> IsEmailExist(string email)
        {
            try
            {
                var result = await _doctorRepository.GetTableNoTracking().Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();
                if (result == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsEmailExist");
                throw;
            }
        }

        public async Task<bool> UpdateDoctorAsync(Doctor doctor)
        {
            try
            {
                var result = await _doctorRepository.UpdateAsync(doctor);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in UpdateDoctorAsync");
                throw;
            }
        }
        #endregion
    }
}
