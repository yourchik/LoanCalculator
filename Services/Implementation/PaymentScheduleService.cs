using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Implementation.Response;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;
using Services.DtoModel;
using Services.Interfaces;

namespace Services.Implementation;

public class PaymentScheduleService : IPaymentScheduleService
{
    private readonly IBaseRepository<PaymentScheduleEntity> _paymentScheduleRepository;

    public PaymentScheduleService(IBaseRepository<PaymentScheduleEntity> paymentScheduleRepository)
    {
        _paymentScheduleRepository = paymentScheduleRepository;
    }

    public IBaseResponse<PaymentScheduleEntity> CreateLoan(LoanDetailsEntity loanDetails, DtoLoanCalculation loanCalculation)
    {
        var paymentsSchedule = new List<PaymentScheduleEntity>();
        var dataPay = DateTime.Today;
        for (var i = 0; i < loanDetails.Term; i++)
        {
            var marginSum = loanCalculation.BodyDebt * loanCalculation.MonthlyRate; //Процентная часть
            var bodySum = loanCalculation.MonthlyRate - marginSum; //Основная часть
            loanCalculation.BodyDebt -= bodySum; // Остаток долга
            dataPay = dataPay.AddMonths(1); //Дата

            var paymentSchedule = new PaymentScheduleEntity
            {
                Date = dataPay,
                MarginSum = Math.Round(marginSum, 2),
                BodySum = Math.Round(bodySum, 2),
                BodyDebt = Math.Round(loanCalculation.BodyDebt, 2),
                LoanDetailsEntityId = loanDetails.Id,
                LoanDetailsEntity = loanDetails
            };
            paymentsSchedule.Add(paymentSchedule);
        }
        
        _paymentScheduleRepository.CreateRange(paymentsSchedule);
        _paymentScheduleRepository.Save();
        
        return new BaseResponse<PaymentScheduleEntity>()
        {
            Description = "График платежей создан",
            StatusCode = StatusCode.OK
        };
        
    }
}