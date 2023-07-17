using Domain.Entity;
using Domain.Interfaces.IResponse;
using Services.DtoModel;

namespace Services.Interfaces;

public interface IPaymentScheduleService
{
    IBaseResponse<PaymentScheduleEntity> CreateLoan(LoanDetailsEntity loanDetails, DtoLoanCalculation loanCalculation);
}