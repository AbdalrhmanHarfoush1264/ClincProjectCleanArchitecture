using ClincProject.Data.Entities;

namespace ClincProject.Service.Abstracts
{
    public interface IScheduleService
    {
        public Task<bool> AddScheduleAsync(Schedule schedule);
        public Task<bool> UpdateScheduleAsync(Schedule schedule);
        public Task<bool> DeleteScheduleAsync(Schedule schedule);
        public Task<List<Schedule>> GetScheduleListAsync();
        public Task<Schedule> GetScheduleByIdAsync(int Id);
        public Task<bool> IsScheduleExistById(int Id);
        public IQueryable<Schedule> FilterSchedulePaginatedQuerable(DateOnly? date = null);
    }
}
