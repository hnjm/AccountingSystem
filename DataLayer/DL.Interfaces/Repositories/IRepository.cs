using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DL.DomainModels.Base;

namespace DL.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);

        Task<ICollection<T>> GetByIds(IEnumerable<int> ids);

        Task<bool> IsExists(Expression<Func<T, bool>> where);

        Task<ICollection<T>> GetAll();

        Task<T> GetCustomSingle(Func<IQueryable<T>, IQueryable<T>> func);

        Task<ICollection<T>> GetCustom(Func<IQueryable<T>, IQueryable<T>> func);

        Task<ICollection<T>> GetByCreateDate(DateTime date);
        Task<ICollection<T>> GetByCreateDates(DateTime startDate, DateTime endDate);
        Task<ICollection<T>> GetByUpdateDate(DateTime date);
        Task<ICollection<T>> GetByUpdateDates(DateTime startDate, DateTime endDate);

    }
}
