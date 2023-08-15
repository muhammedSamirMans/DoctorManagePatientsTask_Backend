using DoctorManagePatientsTask_DAL.Context;
using DoctorManagePatientsTask_DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 
using System.Linq.Expressions; 

namespace DoctorManagePatientsTask_DAL.Repositories.Impelementations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region instances
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        #endregion

        #region Constuctor
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        #endregion

        #region Bascic Operation On any (Genaric) Entity
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {

            return await _dbSet.ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(int currentPage, int pageSize)
        {
            if (currentPage <= 0)
                currentPage = 1;
            return await _dbSet.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, int page, int count)
        {
            if (page <= 0)
                page = 1;
            return await _dbSet.Where(predicate).Skip((page - 1) * count).Take(count).ToListAsync();
        }

        public int GetTotalCountAsync()
        {
            return _dbSet.Count();
        }
        public int GetTotalCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).Count();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        #endregion
    }
}
