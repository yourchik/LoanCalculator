using DAL.Interfaces;
using Domain.Entity;
using Domain.Interfaces.IResponse;

namespace DAL.Repositories;

public class EntityRepository<T> : IBaseRepository<T> where T : BaseEntity<long>
{
    private readonly AppDbContext _db; 
    public EntityRepository(AppDbContext db)
    {
        _db = db;
    }

    public bool Create(T entity)
    {
        try
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
       
    }
    
    public bool CreateRange(IEnumerable<T> entity)
    {
        try
        {
            _db.Set<T>().AddRange(entity);
            _db.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public IQueryable<T> GetAll()
    {
        return _db.Set<T>();
    }

    public bool Delete(T entity)
    {
        try
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Update(T entity)
    {
        try
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
        
    }
    
}