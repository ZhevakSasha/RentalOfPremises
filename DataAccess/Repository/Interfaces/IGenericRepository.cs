using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseModel
    {
        public Task Create(TEntity item);
        public Task<TEntity> FindById(int id);
        public Task<IList<TEntity>> Get();
        public Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        public Task Remove(int id);
        public Task Update(TEntity item);
    }
}
