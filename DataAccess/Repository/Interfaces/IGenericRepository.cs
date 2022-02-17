using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseModel
    {
        Task Create(TEntity item);
        Task<TEntity> FindById(int id);
        Task<IList<TEntity>> Get();
        Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task Remove(int id);
        Task Update(TEntity item);
    }
}
