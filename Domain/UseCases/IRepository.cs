using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Domain.UseCases;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        bool disableTracking = true);
    T GetById(object id);
    T GetByIdAsync(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        bool disableTracking = true);

    void Add(T entity);
    Task<T> AddAsync(T entity);

    void Update(T entity);
    Task<T> UpdateAsync(T entity);

    void Delete(T entity);
    Task<T> DeleteAsync(T entity);
    void DeleteRange(IEnumerable<T> entities);

}
