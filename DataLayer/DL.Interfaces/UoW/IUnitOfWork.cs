using System.Collections.Generic;
using System.Threading.Tasks;
using DL.DomainModels.Base;

namespace DL.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        Task Add<TEntity>(ICollection<TEntity> entities) where TEntity : class, IBaseEntity;
        
        Task Update<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        Task Update<TEntity>(ICollection<TEntity> entities) where TEntity : class, IBaseEntity;

        void Delete<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        void Delete<TEntity>(ICollection<TEntity> entities) where TEntity : class, IBaseEntity;

        Task SaveChanges();
    }
}
