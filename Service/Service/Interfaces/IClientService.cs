using Domain.Entity;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;

namespace Service.Interfaces;

public interface IClientService
{
    IBaseResponse<ClientEntity> CreateClient(LoanDetailsViewModel loanDetails);
}