using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DL.Interfaces.DatabaseContext;
using DL.Interfaces.UoW;
using DL.DomainModels.Base;


namespace DL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAppDbContext _dbContext;

        public UnitOfWork(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
            entity.CreateDate = DateTime.Now;
            var dbEntity = await GetDbSet<TEntity>().AddAsync(entity);
            return dbEntity.Entity;
        }

        public virtual async Task Add<TEntity>(ICollection<TEntity> entities) where TEntity : class, IBaseEntity
        {
            foreach (var entity in entities)
                entity.CreateDate = DateTime.Now;

            await GetDbSet<TEntity>().AddRangeAsync(entities);
        }

        public virtual async Task Update<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
            entity.UpdateDate = DateTime.Now;

            var dbContext = GetDbContext<TEntity>();

            var dbEntity = await dbContext.Set<TEntity>().SingleAsync(t => t.Id == entity.Id);

            dbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
        }

        public virtual async Task Update<TEntity>(ICollection<TEntity> entities) where TEntity : class, IBaseEntity
        {
            var dbContext = GetDbContext<TEntity>();

            foreach (var entity in entities)
            {
                var dbEntity = await dbContext.Set<TEntity>().SingleAsync(t => t.Id == entity.Id);
                entity.UpdateDate = DateTime.Now;
                dbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
            }
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
            var dbSet = GetDbSet<TEntity>();

            dbSet.Attach(entity);

            dbSet.Remove(entity);
        }

        public virtual void Delete<TEntity>(ICollection<TEntity> entities) where TEntity : class, IBaseEntity
        {
            var dbSet = GetDbSet<TEntity>();

            dbSet.AttachRange(entities);

            dbSet.RemoveRange(entities);
        }

        public virtual async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        protected IAppDbContext GetDbContext<TEntity>()
        {
            if (typeof(BaseEntity).IsAssignableFrom(typeof(TEntity))) return _dbContext;

            throw new InvalidOperationException("The database context not found for entity " + typeof(TEntity).FullName);
        }

        protected DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IBaseEntity
        {
            return GetDbContext<TEntity>().Set<TEntity>();
        }
    }
}
