using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.FrameworkCore.Abstract
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> AddAsync(TEntity Entity);
        void Update(TEntity Entity);
        void Delete(TEntity Entity);
        void DeleteById(object EntityId);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
    }
}
