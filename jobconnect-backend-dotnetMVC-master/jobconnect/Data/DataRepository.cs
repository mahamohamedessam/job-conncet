using System.Linq.Expressions;
using jobconnect.Dtos;
using jobconnect.Models;
using Microsoft.EntityFrameworkCore;

namespace jobconnect.Data
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly DataContext _db;
        private readonly DbSet<T> table;

        public DataRepository(DataContext db)
        {
            _db = db;
            table = _db.Set<T>();
            
        }


        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await table.SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<List<Proposal>> GetByJobIdAsync(int jobId)
        {
            return await _db.Proposal.Where(p => p.JobId == jobId).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int jobId, int jobSeekerId)
        {
            if (typeof(T) == typeof(Proposal))
            {
                var proposals = table as DbSet<Proposal>;
                return await proposals.FirstOrDefaultAsync(x => x.JobId == jobId && x.JobSeekerId == jobSeekerId) as T;
            }

            return null;
        }

        public async Task AddAsync(T entity)
        {
            await table.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(T entity)
        {
            table.Remove(entity);
        }

        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }
        /*
        public async Task<IEnumerable<T>> GetAllAsyncInclude(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (criteria != null)
            {
                query = query.Where(criteria);
            }

            return await query.ToListAsync();
        }

        public Expression<Func<T, bool>> And(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var paramExpr = Expression.Parameter(typeof(T));

            var body = Expression.AndAlso(
                Expression.Invoke(expr1, paramExpr),
                Expression.Invoke(expr2, paramExpr)
            );

            return Expression.Lambda<Func<T, bool>>(body, paramExpr);
        }
        public async Task<IEnumerable<T>> GetAllfilterAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = table;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }*/

    }
}
