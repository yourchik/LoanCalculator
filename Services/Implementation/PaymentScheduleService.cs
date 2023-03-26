using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Implementation.Response;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;
using Services.Interfaces;

namespace Services.Implementation;

public class PaymentScheduleService : IPaymentScheduleService
{
    private readonly IBaseRepository<PaymentScheduleEntity> _paymentScheduleRepository;

    public PaymentScheduleService(IBaseRepository<PaymentScheduleEntity> paymentScheduleRepository)
    {
        _paymentScheduleRepository = paymentScheduleRepository;
    }

    public IBaseResponse<PaymentScheduleEntity> CreatePaymentScheduleEntity(decimal bodyDebt, decimal monthlyRate, decimal monthlyPayment, int term)
    {
        var paymentsSchedule = new List<PaymentScheduleEntity>();
        var dataPay = DateTime.Today;
        for (var i = 0; i < term; i++)
        {
            var marginSum = bodyDebt * monthlyRate;  //Процентная часть
            var bodySum = monthlyPayment - marginSum;  //Основная часть
            bodyDebt -= bodySum;  // Остаток долга
            dataPay = dataPay.AddMonths(1);  //Дата
            
            var paymentSchedule = new PaymentScheduleEntity
            {
                Date = dataPay,
                MarginSum = Math.Round(marginSum, 2),
                BodySum = Math.Round(bodySum, 2),
                BodyDebt = Math.Round(bodyDebt, 2),
            };
            paymentsSchedule.Add(paymentSchedule);
        }
        
        _paymentScheduleRepository.CreateRange(paymentsSchedule);
            
        return new BaseResponse<PaymentScheduleEntity>()
        {
            Description = "График платежей создан",
            StatusCode = StatusCode.OK,
        };
    }
}