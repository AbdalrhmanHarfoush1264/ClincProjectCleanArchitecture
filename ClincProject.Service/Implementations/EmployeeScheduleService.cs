using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class EmployeeScheduleService : IEmployeeScheduleService
    {

        #region Fileds
        private readonly ILogger<EmployeeScheduleService> _logger;
        private readonly IGenericRepository<EmployeeSchedules> _employeeScheduleRepository;
        private readonly IGenericRepository<Schedule> _scheduleRepository;

        #endregion

        #region Constructor(s)
        public EmployeeScheduleService(ILogger<EmployeeScheduleService> logger,
            IGenericRepository<EmployeeSchedules> employeeScheduleRepository, IGenericRepository<Schedule> scheduleRepository)
        {
            _logger = logger;
            _employeeScheduleRepository = employeeScheduleRepository;
            _scheduleRepository = scheduleRepository;
        }
        #endregion

        #region Functions

        public async Task<bool> AddEmployeeScheduleAsync(EmployeeSchedules employeeSchedules)
        {
            try
            {
                var result = await _employeeScheduleRepository.AddAsync(employeeSchedules);
                if (result == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in AddEmployeeScheduleAsync");
                throw;
            }
        }

        public async Task<bool> EditEmployeeScheduleAsync(EmployeeSchedules employeeSchedules)
        {
            try
            {
                var result = await _employeeScheduleRepository.UpdateAsync(employeeSchedules);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in EditEmployeeScheduleAsync");
                throw;
            }
        }

        public async Task<bool> DeleteEmployeeScheduleAsync(EmployeeSchedules employeeSchedules)
        {
            try
            {
                var IsScheduleUseEmployeeSchedule = await _scheduleRepository.GetTableNoTracking()
                    .Where(x => x.EmployeeSchedulesId == employeeSchedules.EmployeeSchedulesId).AnyAsync();

                if (IsScheduleUseEmployeeSchedule)
                    return false;

                var result = await _employeeScheduleRepository.DeleteAsync(employeeSchedules);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteEmployeeScheduleAsync");
                throw;
            }
        }

        public async Task<List<EmployeeSchedules>> GetEmployeeSchedulesListAsync()
        {
            try
            {
                var result = await _employeeScheduleRepository.GetTableNoTracking()
                    .Include(x => x.ClinicDepartment).Include(x => x.Doctor).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetEmployeeSchedulesListAsync");
                throw;
            }
        }

        public IQueryable<EmployeeSchedules> FilterEmployeeSchedulesPaginatedQuerable(bool IsActive = true)
        {

            try
            {
                var quey = _employeeScheduleRepository.GetTableNoTracking().AsQueryable();
                if (IsActive)
                {
                    quey = quey.Where(x => x.IsActive == IsActive);
                }
                else
                {
                    quey = quey.Where(x => x.IsActive == IsActive);
                }

                return quey;

            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in FilterEmployeeSchedulesPaginatedQuerable");
                throw;
            }

        }

        public async Task<bool> IsEmployeeScheduleExist(int Id)
        {
            try
            {
                var result = await _employeeScheduleRepository.GetTableNoTracking().Where(x => x.EmployeeSchedulesId == Id).FirstOrDefaultAsync();
                if (result == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsEmployeeScheduleExist");
                throw;
            }
        }

        public async Task<EmployeeSchedules> GetEmployeeScheduleByIdAsync(int Id)
        {
            try
            {
                var result = await _employeeScheduleRepository.GetTableNoTracking().Where(x => x.EmployeeSchedulesId == Id)
                     .Include(x => x.Doctor).Include(x => x.ClinicDepartment).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in CreateClinicAsync");
                throw;
            }
        }
        #endregion

    }
}
