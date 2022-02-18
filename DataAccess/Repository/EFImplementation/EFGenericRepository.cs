using DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository.EFImplementation
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class, IBaseModel
    {
        private readonly DataBaseContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public EFGenericRepository(DataBaseContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IList<TEntity>> Get()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<TEntity> FindById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(TEntity item)
        {
            await _dbSet.AddAsync(item);
        }

        public async Task Update(TEntity item)
        {
            var toUpdate = await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == item.Id);

            if (toUpdate is not null)
                _context.Entry(item).State = EntityState.Modified;
            else 
                throw new ArgumentNullException($"Not found updating entity with ID={item.Id}");
        }

        public async Task Remove(int id)
        {
            var item = await _dbSet.FindAsync(id);
            _dbSet.Remove(item);
        }

        public Task<List<TEntity>> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToListAsync();
        }

        public Task<List<TEntity>> GetWithInclude(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToListAsync();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
