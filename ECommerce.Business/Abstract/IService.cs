using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public abstract class IService<TEntity>
    {
        public abstract Task<TEntity> AddAsync(TEntity Entity);
        public abstract void Update(TEntity Entity);
        public abstract void Delete(TEntity Entity);
        public abstract void DeleteById(object EntityId);
        public abstract Task<TEntity> GetByIdAsync(int id);
        public abstract Task<TEntity> GetAsync();
        public abstract IEnumerable<TEntity> GetAll();

    }
}
