﻿using DAL.Interfaces;
using Domain.Entity;
using Domain.Interfaces.IResponse;

namespace DAL.Repositories;

public class EntityRepository<T> : IBaseRepository<T> where T : BaseEntity<long>
{
    private readonly ApplicationDbContext _db; 
    public EntityRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public bool Create(T entity)
    {
        try
        {
            _db.Set<T>().Add(entity);
            return true;
        }
        catch
        {
            return false;
        }
       
    }
    
    public bool CreateRange(IEnumerable<T> entity)
    {
        try
        {
            _db.Set<T>().AddRange(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(T entity)
    {
        try
        {
            _db.Set<T>().Remove(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Update(T entity)
    {
        try
        {
            _db.Set<T>().Update(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public bool Save()
    {
        try
        {
            _db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public IQueryable<T> GetAll()
    {
        return _db.Set<T>();
    }
}