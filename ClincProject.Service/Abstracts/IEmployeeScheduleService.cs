using ClincProject.Data.Entities;

namespace ClincProject.Service.Abstracts
{
    public interface IEmployeeScheduleService
    {
        public Task<bool> AddEmployeeScheduleAsync(EmployeeSchedules employeeSchedules);
        public Task<bool> EditEmployeeScheduleAsync(EmployeeSchedules employeeSchedules);
        public Task<bool> DeleteEmployeeScheduleAsync(EmployeeSchedules employeeSchedules);
        public Task<List<EmployeeSchedules>> GetEmployeeSchedulesListAsync();
        public IQueryable<EmployeeSchedules> FilterEmployeeSchedulesPaginatedQuerable(bool IsActive);
        public Task<bool> IsEmployeeScheduleExist(int Id);
        public Task<EmployeeSchedules> GetEmployeeScheduleByIdAsync(int Id);
    }
}
