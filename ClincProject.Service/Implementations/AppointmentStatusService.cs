using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class AppointmentStatusService : IAppointmentStatusService
    {
        #region Fileds
        private readonly IGenericRepository<AppointmentStatus> _appointmentStatusRepository;
        private readonly IGenericRepository<Appointment> _appointmentRepository;
        private readonly ILogger<AppointmentStatusService> _logger;
        #endregion

        #region Constructors
        public AppointmentStatusService(ILogger<AppointmentStatusService> logger,
            IGenericRepository<AppointmentStatus> appointmentStatusRepository,
            IGenericRepository<Appointment> appointmentRepository)
        {
            _logger = logger;
            _appointmentStatusRepository = appointmentStatusRepository;
            _appointmentRepository = appointmentRepository;
        }
        #endregion

        #region Functions

        public async Task<bool> CreateAppointmentStatusAsync(AppointmentStatus appointmentStatus)
        {
            try
            {
                var IsAdded = await _appointmentStatusRepository.AddAsync(appointmentStatus);
                if (IsAdded == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in CreateAppointmentStatusAsync");
                throw;
            }
        }

        public async Task<bool> EditAppointmentStatusAsync(AppointmentStatus appointmentStatus)
        {
            try
            {
                var result = await _appointmentStatusRepository.UpdateAsync(appointmentStatus);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in UpdateAppointmentStatusAsync");
                throw;
            }
        }

        public async Task<bool> DeleteAppointmentStatusAsync(AppointmentStatus appointmentStatus)
        {
            try
            {
                var anyAppointmentUserThisId = await _appointmentRepository.GetTableNoTracking().Where(x => x.AppointmentStatusId == appointmentStatus.AppointmentStatusId)
                    .AnyAsync();
                if (anyAppointmentUserThisId)
                    return false;

                var result = await _appointmentStatusRepository.DeleteAsync(appointmentStatus);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteAppointmentStatusAsync");
                throw;
            }
        }

        public async Task<AppointmentStatus> GetAppointmentStatusByIdAsync(int Id)
        {
            try
            {
                var result = await _appointmentStatusRepository.GetTableNoTracking()
                    .Where(x => x.AppointmentStatusId == Id).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetAppointmentStatusByIdAsync");
                throw;
            }
        }

        public async Task<bool> IsAppointmentStatusByNameAsync(string statusName)
        {
            try
            {
                var result = await _appointmentStatusRepository.GetTableNoTracking()
                    .Where(x => x.StatusName == statusName).FirstOrDefaultAsync();

                if (result == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsAppointmentStatusByNameAsync");
                throw;
            }
        }

        public async Task<bool> IsAppointmentStatusByIdAsync(int Id)
        {
            try
            {
                var result = await _appointmentStatusRepository.GetTableNoTracking()
                    .Where(x => x.AppointmentStatusId == Id).FirstOrDefaultAsync();

                if (result == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsAppointmentStatusByIdAsync");
                throw;
            }
        }

        public async Task<List<AppointmentStatus>> GetAppointmentStatusListAsync()
        {
            try
            {
                var result = await _appointmentStatusRepository.GetTableNoTracking().ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetAppointmentStatusListAsync");
                throw;
            }
        }

        #endregion

    }
}
