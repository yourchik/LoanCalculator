using Services.DtoModel;
using Services.Interfaces;

namespace Services.Implementation;

public class DtoCalculation : IDtoCalculation
{
    public DtoLoanCalculation DtoLoanCalculation(DtoLoanDetails loanDetailsViewModel)
    {
        var loanCalculation = new DtoLoanCalculation();
        
        loanCalculation.MonthlyRate = loanDetailsViewModel.Rate / 12 / 100;
        loanCalculation.TotalRate = 
            (decimal)Math.Pow((double)(1 + loanCalculation.MonthlyRate), loanDetailsViewModel.Term);
        loanCalculation.MonthlyPayment = loanDetailsViewModel.Sum * 
            loanCalculation.MonthlyRate * loanCalculation.TotalRate / (loanCalculation.TotalRate - 1);
        loanCalculation.BodyDebt = loanDetailsViewModel.Sum;
        loanCalculation.Overpayment = 
            Math.Round((loanCalculation.MonthlyPayment * loanDetailsViewModel.Term - loanDetailsViewModel.Sum), 2);
        return loanCalculation;
    }
}