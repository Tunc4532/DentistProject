using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsyncOrderByFilter(Expression<Func<T, int>> filter);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<List<T?>> GetByFilterListAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> Include(Expression<Func<T, object>>[] entity);
        Task<List<T>> Include(Expression<Func<T, object>> entity);
        Task<List<T>> IncludeWithFilter(Expression<Func<T, object>> entity, Expression<Func<T, bool>> filter);
        Task<T> IncludeSingle(Expression<Func<T, object>> entity, Expression<Func<T, bool>> id);
    }
}
