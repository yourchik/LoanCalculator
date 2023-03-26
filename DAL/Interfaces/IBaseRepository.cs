using Domain.Entity;

namespace DAL.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity<long>
{
    bool Create(T entity);
    
    bool CreateRange(IEnumerable<T> entity);

    IQueryable<T> GetAll();

    bool Delete(T entity);

    bool Update(T entity);
    
}