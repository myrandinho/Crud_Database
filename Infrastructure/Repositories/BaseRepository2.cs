

using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class BaseRepository2<TEntity> where TEntity : class
{

    private readonly DataContext2 _context2;



    public BaseRepository2(DataContext2 context2)
    {
        _context2 = context2;

    }



    public virtual TEntity Create(TEntity entity)
    {
        _context2.Set<TEntity>().Add(entity);
        _context2.SaveChanges();
        return entity;
    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context2.Set<TEntity>().FirstOrDefault(expression);
        return entity!;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _context2.Set<TEntity>().ToList();
    }

    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        var entityToUpdate = _context2.Set<TEntity>().FirstOrDefault(expression);
        _context2.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
        _context2.SaveChanges();

        return entityToUpdate!;
    }

    public virtual void Delete(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context2.Set<TEntity>().FirstOrDefault(expression);
        _context2.Remove(entity!);
        _context2.SaveChanges();

    }

    public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {

            var result = _context2.Set<TEntity>().Any(predicate);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}


