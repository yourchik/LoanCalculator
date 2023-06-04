using Domain.Entity;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;
using Services.DtoModel;

namespace Services.Interfaces;

public interface ILoanDetailsService
{
    IBaseResponse<LoanDetailsEntity> CreateLoan(LoanDetailsViewModel loanDetails, DtoLoanCalculation loanCalculation,
        ClientEntity client);
    
    LoanDetailsEntity FindLoanDetailsEntity(ClientEntity client);
}

