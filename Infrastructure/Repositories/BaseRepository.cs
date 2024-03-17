using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;

    public virtual async Task<TEntity> CreateOneAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            return result!;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public virtual async Task<TEntity> UpdateOneAsync(Expression<Func<TEntity, bool>> predicate, TEntity entity)
    {
        try
        {
            var entityToUpdate = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return entityToUpdate!;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public virtual async Task<TEntity> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entityToDelete = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            _context.Remove(entityToDelete!);
            _context.SaveChanges();
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
}
