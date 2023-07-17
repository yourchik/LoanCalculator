using Services.DtoModel;

namespace Services.Interfaces;

public interface IDtoCalculation
{
    DtoLoanCalculation DtoLoanCalculation(DtoLoanDetails loanDetailsViewModel);
}