

using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
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
        try
        {
            _context2.Set<TEntity>().Add(entity);
            _context2.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

        return null!;

    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _context2.Set<TEntity>().FirstOrDefault(expression);
            if (entity != null)
            {
                return entity!;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }


    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            var result = _context2.Set<TEntity>().ToList();
            if (result != null)
            {
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }


    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        try
        {
            var entityToUpdate = _context2.Set<TEntity>().FirstOrDefault(expression);
            if (entityToUpdate != null)
            {
                _context2.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
                _context2.SaveChanges();
                return entityToUpdate!;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public virtual bool Delete(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _context2.Set<TEntity>().FirstOrDefault(expression);
            if (entity != null)
            {
                _context2.Remove(entity!);
                _context2.SaveChanges();
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;


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


