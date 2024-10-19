using ClincProject.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClincProject.Infrastructure.InfrastructureBases
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Fileds
        private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Handle Functions

        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            try
            {
                await _dbContext.Set<T>().AddRangeAsync(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            try
            {
                return await _dbContext.Database.BeginTransactionAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await _dbContext.Database.CommitTransactionAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                var rowEffectedCout = await _dbContext.SaveChangesAsync();
                return rowEffectedCout > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            try
            {
                _dbContext.Set<T>().RemoveRange(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Set<T>().FindAsync(id);

            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public virtual IQueryable<T> GetTableAsTracking()
        {
            try
            {
                return _dbContext.Set<T>().AsQueryable();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public virtual IQueryable<T> GetTableNoTracking()
        {
            try
            {
                return _dbContext.Set<T>().AsNoTracking().AsQueryable();

            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public async Task RolleBackAsync()
        {
            try
            {
                await _dbContext.Database.RollbackTransactionAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public virtual async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {

            try
            {
                _dbContext.Set<T>().Update(entity);
                var rowUpdated = await _dbContext.SaveChangesAsync();
                return rowUpdated > 0;// إرجاع true إذا تم تحديث صف واحد أو أكثر
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            try
            {
                _dbContext.Set<T>().UpdateRange(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing the database.", ex);
            }
        }
        #endregion
    }
}
