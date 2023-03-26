using Domain.Entity;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;

namespace Service.Interfaces;

public interface IPaymentScheduleService
{
    IBaseResponse<PaymentScheduleEntity> CreatePaymentScheduleEntity(LoanDetailsViewModel loanDetails);
}