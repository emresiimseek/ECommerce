using ECommerce.FrameworkCore.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerce.FrameworkCore.Concrete
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        public readonly DbContext _dbContext;
        public readonly DbSet<TEntity> _dbSet;
        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity Entity)
        {
            EntityEntry res = await _dbSet.AddAsync(Entity);
            await _dbContext.SaveChangesAsync();
            return res.Entity as TEntity;
        }

        public void Delete(TEntity Entity)
        {
            _dbSet.Remove(Entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(object EntityId)
        {
            TEntity entityToDelete = _dbContext.Set<TEntity>().Find(EntityId);
            Delete(entityToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return filter == null ?
                _dbSet :
               _dbSet.Where(filter);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            TEntity entity = await _dbSet.SingleOrDefaultAsync(filter);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Update(TEntity Entity)
        {
            _dbSet.Update(Entity);
            _dbContext.SaveChanges();
        }

    }
}
