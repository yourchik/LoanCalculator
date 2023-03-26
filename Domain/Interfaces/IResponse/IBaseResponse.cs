using Domain.Entity;
using Domain.Enum;

namespace Domain.Interfaces.IResponse;

public interface IBaseResponse<T>
{
    string Description { get; }
    
    StatusCode StatusCode { get; }
    
    T Data { get; }
    
}