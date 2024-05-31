using System.Linq.Expressions;
using jobconnect.Dtos;
using jobconnect.Models;

namespace jobconnect.Data
{
    public interface IDataRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int jobId, int jobSeekerId);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        Task<List<Proposal>> GetByJobIdAsync(int jobId);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> Save();
       /* Task<IEnumerable<T>> GetAllAsyncInclude(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes);
        Expression<Func<T, bool>> And(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2);
        Task<IEnumerable<T>> GetAllfilterAsync(Expression<Func<T, bool>> filter = null);*/

    }
}
