using Microsoft.EntityFrameworkCore.Storage;

namespace ClincProject.Infrastructure.InfrastructureBases
{
    public interface IGenericRepository<T> where T : class
    {
        //Add - Update - Delete - Get Operations
        //Transaction Operations
        //SaveChanges Operation

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task<bool> UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task<bool> DeleteAsync(T entity);
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RolleBackAsync();
    }
}
