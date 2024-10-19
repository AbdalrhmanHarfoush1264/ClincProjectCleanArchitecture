using ClincProject.Data.Entities;

namespace ClincProject.Service.Abstracts
{
    public interface IStatusHistoryService
    {
        public Task<bool> CreateStatusHistoryAsync(StatusHistory statusHistory);
        public Task<bool> EditStatusHistoryAsync(StatusHistory statusHistory);
        public Task<bool> DeleteStatusHistoryAsync(StatusHistory statusHistory);
        public Task<List<StatusHistory>> GetStatusHistoryListAsync();
        public Task<StatusHistory> GetStatusHistoryByIdAsync(int Id);
        public Task<bool> IsStatusHistoryExistByIdAsync(int Id);
        public IQueryable<StatusHistory> FilterStatusHistoryPaginatedQuerable(string? statusName = null);
    }
}
