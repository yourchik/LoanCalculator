using Domain.Enum;
using Domain.Interfaces.IResponse;

namespace Domain.Implementation.Response;

public class BaseResponse<T> : IBaseResponse<T>
{
    public string Description { get; set;}
    
    public StatusCode StatusCode { get; set;}
    
    public T Data { get; set;}
}