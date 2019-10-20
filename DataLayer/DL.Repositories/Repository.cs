using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DL.Interfaces.Repositories;
using DL.Interfaces.DatabaseContext;
using DL.DomainModels.Base;

namespace DL.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IAppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(IAppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<T>> GetByIds(IEnumerable<int> ids)
        {
            return await _dbSet.AsNoTracking().Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<bool> IsExists(Expression<Func<T, bool>> where)
        {
            return await _dbSet.AsNoTracking().Where(where).AnyAsync();
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetCustomSingle(Func<IQueryable<T>, IQueryable<T>> func)
        {
            IQueryable<T> query = func(_dbSet);

            var result = query.AsNoTracking();

            return await result.FirstOrDefaultAsync();
        }

        public async Task<ICollection<T>> GetCustom(Func<IQueryable<T>, IQueryable<T>> func)
        {
            IQueryable<T> query = func(_dbSet);

            var result = query.AsNoTracking();

            return await result.ToListAsync();
        }


        public async Task<ICollection<T>> GetByCreateDate(DateTime date)
        {
            return await _dbSet.AsNoTracking().Where(x => x.CreateDate == date).ToListAsync();
        }
        public async Task<ICollection<T>> GetByCreateDates(DateTime startDate, DateTime endDate)
        {
            return await _dbSet.AsNoTracking().Where(x => x.CreateDate >= startDate && x.CreateDate <= endDate).ToListAsync();
        }
        public async Task<ICollection<T>> GetByUpdateDate(DateTime date)
        {
            return await _dbSet.AsNoTracking().Where(x => x.UpdateDate == date).ToListAsync();
        }
        public async Task<ICollection<T>> GetByUpdateDates(DateTime startDate, DateTime endDate)
        {
            return await _dbSet.AsNoTracking().Where(x => x.UpdateDate >= startDate && x.CreateDate <= endDate).ToListAsync();
        }
    }
}
