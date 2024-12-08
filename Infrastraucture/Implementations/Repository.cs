using Domain.UseCases;
using Infrastraucture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Infrastraucture.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly VotingContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(VotingContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Add(T entity) => _dbSet.Add(entity);

    public async Task<T> AddAsync(T entity) => (await _dbSet.AddAsync(entity)).Entity;

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task<T> DeleteAsync(T entity) => (await Task.Run(() => _dbSet.Remove(entity))).Entity;

    public void DeleteRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
    {
        var query = _dbSet.AsQueryable();
        if (disableTracking) query = query.AsNoTracking();
        if (include != null) query = include(query);
        if (filter != null) query = query.Where(filter);
        if (orderBy != null) return await orderBy(query).ToListAsync();
        return await query.ToListAsync();
    }

    public T GetById(object id) => _dbSet.Find(id);

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
    {
        var query = _dbSet.AsQueryable();
        if (disableTracking) query = query.AsNoTracking();
        if (include != null) query = include(query);
        if (filter != null) query = query.Where(filter);
        if (orderBy != null) return await orderBy(query).SingleOrDefaultAsync();
        return await query.SingleOrDefaultAsync();
    }

    public void Update(T entity) => _dbSet.Update(entity);

    public async Task<T> UpdateAsync(T entity) => (await Task.Run(() => _dbSet.Update(entity))).Entity;
}
