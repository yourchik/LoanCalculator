using Domain.Entity;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;

namespace Services.Interfaces;

public interface ILoanCalculationService
{
    IBaseResponse<LoanDetailsEntity> CreateLoanDetails(LoanDetailsViewModel loanDetails);
    
}

