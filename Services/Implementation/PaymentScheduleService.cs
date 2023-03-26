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

    public IBaseResponse<PaymentScheduleEntity> CreatePaymentScheduleEntity(LoanDetailsViewModel loanDetailsViewModel)
    {
        var monthlyRate = loanDetailsViewModel.Rate / 12 / 100;
        var totalRate = (decimal)Math.Pow((double)(1 + monthlyRate), loanDetailsViewModel.Term);
        var monthlyPayment = loanDetailsViewModel.Sum * monthlyRate * totalRate / (totalRate - 1);
        var bodyDebt = loanDetailsViewModel.Sum;
        var overpayment = Math.Round((monthlyPayment * loanDetailsViewModel.Term - loanDetailsViewModel.Sum), 2);
        
        var paymentsSchedule = new List<PaymentScheduleEntity>();
        
        for (var i = 0; i < loanDetailsViewModel.Term; i++)
        {
            var marginSum = bodyDebt * monthlyRate;  //Процентная часть
            var bodySum = monthlyPayment - marginSum;  //Основная часть
            bodyDebt -= bodySum;  // Остаток долга
            var dataPay = DateTime.Today;
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