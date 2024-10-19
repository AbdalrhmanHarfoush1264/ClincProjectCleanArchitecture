using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class ScheduleService : IScheduleService
    {

        #region Fileds
        private readonly ILogger<ScheduleService> _logger;
        private readonly IGenericRepository<Schedule> _scheduleRepository;

        #endregion

        #region Constructors
        public ScheduleService(ILogger<ScheduleService> logger, IGenericRepository<Schedule> scheduleRepository)
        {
            _logger = logger;
            _scheduleRepository = scheduleRepository;
        }
        #endregion

        #region Functions
        /*
        try
           {

           }
           catch (Exception ex)
           {
               _logger.LogDebug(ex, "Error in CreateClinicAsync");
               throw;
           }
        */

        public async Task<bool> AddScheduleAsync(Schedule schedule)
        {
            try
            {
                var result = await _scheduleRepository.AddAsync(schedule);
                if (result == null)
                    return false;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in CreateScheduleAsync");
                throw;
            }
        }


        public async Task<bool> UpdateScheduleAsync(Schedule schedule)
        {
            try
            {
                var result = await _scheduleRepository.UpdateAsync(schedule);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in UpdateScheduleAsync");
                throw;
            }
        }

        public async Task<bool> DeleteScheduleAsync(Schedule schedule)
        {
            try
            {
                var result = await _scheduleRepository.DeleteAsync(schedule);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteScheduleAsync");
                throw;
            }
        }

        public async Task<List<Schedule>> GetScheduleListAsync()
        {
            try
            {
                var result = await _scheduleRepository.GetTableNoTracking()
                    .Include(x => x.EmployeeSchedules).Include(x => x.EmployeeSchedules.Doctor)
                    .Include(x => x.EmployeeSchedules.ClinicDepartment).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetScheduleListAsync");
                throw;
            }
        }

        public async Task<Schedule> GetScheduleByIdAsync(int Id)
        {
            try
            {
                var result = await _scheduleRepository.GetTableNoTracking()
                    .Where(x => x.ScheduleId == Id)
                    .Include(x => x.EmployeeSchedules).Include(x => x.EmployeeSchedules.Doctor)
                    .Include(x => x.EmployeeSchedules.ClinicDepartment).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetScheduleByIdAsync");
                throw;
            }
        }

        public async Task<bool> IsScheduleExistById(int Id)
        {
            try
            {
                var result = await _scheduleRepository.GetTableNoTracking().Where(x => x.ScheduleId == Id).AnyAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsScheduleExistById");
                throw;
            }
        }
        public IQueryable<Schedule> FilterSchedulePaginatedQuerable(DateOnly? date = null)
        {

            try
            {
                var query = _scheduleRepository.GetTableNoTracking().AsQueryable();
                if (date != null)
                {
                    query = query.Where(x => x.Date == date);
                }
                return query;

            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in FilterSchedulePaginatedQuerable");
                throw;
            }

        }
        #endregion
    }
}
