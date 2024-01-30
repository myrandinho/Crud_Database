

using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class BaseRepository<TEntity> where TEntity : class
{

    private readonly DataContext _context;
    


    public BaseRepository(DataContext context)
    {
        _context = context;
        
    }



    public virtual TEntity Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        return entity!;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
        _context.SaveChanges();

        return entityToUpdate!;
    }

    public virtual void Delete(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Remove(entity!);
        _context.SaveChanges();

    }

    public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {

            var result = _context.Set<TEntity>().Any(predicate);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}


