using ClincProject.Data.Entities;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClincProject.Service.Implementations
{
    public class StatusHistoryService : IStatusHistoryService
    {

        #region Fileds
        private readonly ILogger<StatusHistoryService> _logger;
        private readonly IGenericRepository<StatusHistory> _statusHistoryRepository;
        #endregion

        #region Constructors
        public StatusHistoryService(IGenericRepository<StatusHistory> statusHistoryRepository,
            ILogger<StatusHistoryService> logger)
        {
            _statusHistoryRepository = statusHistoryRepository;
            _logger = logger;
        }

        #endregion

        #region Functions
        public async Task<bool> CreateStatusHistoryAsync(StatusHistory statusHistory)
        {
            try
            {
                var IsAdded = await _statusHistoryRepository.AddAsync(statusHistory);
                if (IsAdded == null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in CreateStatusHistoryAsync");
                throw;
            }

        }

        public async Task<bool> EditStatusHistoryAsync(StatusHistory statusHistory)
        {
            try
            {
                var IsEdited = await _statusHistoryRepository.UpdateAsync(statusHistory);
                return IsEdited;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in EditStatusHistoryAsync");
                throw;
            }

        }

        public async Task<bool> DeleteStatusHistoryAsync(StatusHistory statusHistory)
        {
            try
            {
                var IsDeleted = await _statusHistoryRepository.DeleteAsync(statusHistory);
                return IsDeleted;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteStatusHistoryAsync");
                throw;
            }

        }

        public async Task<List<StatusHistory>> GetStatusHistoryListAsync()
        {
            try
            {
                var result = await _statusHistoryRepository.GetTableNoTracking()
                    .Include(x => x.AppointmentStatus).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetStatusHistoryListAsync");
                throw;
            }
        }

        public async Task<StatusHistory> GetStatusHistoryByIdAsync(int Id)
        {
            try
            {
                var result = await _statusHistoryRepository.GetTableNoTracking()
                    .Where(x => x.StatusHistoryId == Id).Include(x => x.Appointment)
                    .Include(x => x.AppointmentStatus).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetStatusHistoryByIdAsync");
                throw;
            }
        }

        public async Task<bool> IsStatusHistoryExistByIdAsync(int Id)
        {
            try
            {
                var result = await _statusHistoryRepository.GetTableNoTracking()
                    .Where(x => x.StatusHistoryId == Id).AnyAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsStatusHistoryExistByIdAsync");
                throw;
            }
        }

        public IQueryable<StatusHistory> FilterStatusHistoryPaginatedQuerable(string? statusName = null)
        {

            try
            {
                var query = _statusHistoryRepository.GetTableNoTracking()
                    .Include(x => x.AppointmentStatus).AsQueryable();
                if (statusName != null)
                {
                    query = query.Where(x => x.AppointmentStatus.StatusName.ToLower() == statusName.ToLower());

                }
                return query;

            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in FilterStatusHistoryPaginatedQuerable");
                throw;
            }

        }
        #endregion

    }
}
