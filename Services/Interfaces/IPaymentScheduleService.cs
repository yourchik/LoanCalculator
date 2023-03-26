using Domain.Entity;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;

namespace Services.Interfaces;

public interface IPaymentScheduleService
{
    IBaseResponse<PaymentScheduleEntity> CreatePaymentScheduleEntity(decimal bodyDebt, decimal monthlyRate, decimal monthlyPayment, int term);
}