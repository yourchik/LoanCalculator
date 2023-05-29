using Domain.Entity;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;

namespace Services.Interfaces;

public interface ILoanDetailsService
{
    IBaseResponse<LoanDetailsEntity> CreateLoan(LoanDetailsViewModel loanDetails, ClientEntity client);
    
    LoanDetailsEntity FindLoanDetailsEntity(ClientEntity client);
}

