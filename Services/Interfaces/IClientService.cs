using Domain.Entity;
using Domain.Interfaces.IResponse;
using Services.DtoModel;

namespace Services.Interfaces;

public interface IClientService
{
    IBaseResponse<ClientEntity> CreateClient(DtoLoanDetails loanDetails);
    
    ClientEntity FindClient(string phone);
}