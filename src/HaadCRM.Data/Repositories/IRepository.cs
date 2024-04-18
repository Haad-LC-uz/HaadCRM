using HaadCRM.Domain.Commons;
using System.Linq.Expressions;

namespace HaadCRM.Data.Repositories;

public interface IRepository<T> where T : Auditable
{
    Task<T> InsertAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<T> DropAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null);
    Task<IEnumerable<T>> SelectAsEnumerableAsync(Expression<Func<T, bool>> expression = null, string[] includes = null, bool isTracked = true);
    IQueryable<T> SelectAsQueryable(Expression<Func<T, bool>> expression = null, string[] includes = null, bool isTracked = true);
}