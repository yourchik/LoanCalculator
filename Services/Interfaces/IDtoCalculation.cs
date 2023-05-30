using LoanCalculator.ViewModels;
using Services.DtoModel;

namespace Services.Interfaces;

public interface IDtoCalculation
{
    DtoLoanCalculation DtoLoanCalculation(LoanDetailsViewModel loanDetailsViewModel);
}