using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Implementation.Response;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;
using Services.Interfaces;

namespace Services.Implementation;

public class LoanCalculationService : ILoanCalculationService
{
    private readonly IBaseRepository<LoanDetailsEntity> _loanDetailsRepository;
    private readonly IBaseRepository<PaymentScheduleEntity> _paymentScheduleRepository;

    public LoanCalculationService (IBaseRepository<LoanDetailsEntity> loanDetailsRepository, 
         IBaseRepository<PaymentScheduleEntity> paymentScheduleRepository)
    {
        _loanDetailsRepository = loanDetailsRepository;
        _paymentScheduleRepository = paymentScheduleRepository;
    }

    public IBaseResponse<LoanDetailsEntity> CreateLoan(LoanDetailsViewModel loanDetailsViewModel)
    {
        var monthlyRate = loanDetailsViewModel.Rate / 12 / 100;
        var totalRate = (decimal)Math.Pow((double)(1 + monthlyRate), loanDetailsViewModel.Term);
        var monthlyPayment = loanDetailsViewModel.Sum * monthlyRate * totalRate / (totalRate - 1);
        var bodyDebt = loanDetailsViewModel.Sum;
        var overpayment = Math.Round((monthlyPayment * loanDetailsViewModel.Term - loanDetailsViewModel.Sum), 2);

        var paymentsSchedule = PaymentScheduleEntities(loanDetailsViewModel, bodyDebt, monthlyRate, monthlyPayment);

        var loanDetailsEntity = new LoanDetailsEntity
        {
            Sum = loanDetailsViewModel.Sum,
            Term = loanDetailsViewModel.Term,
            Rate = loanDetailsViewModel.Rate,
            PaymentType = loanDetailsViewModel.PaymentType,
            Overpayment = overpayment,
            PaymentSchedule = paymentsSchedule
        };

        _loanDetailsRepository.Create(loanDetailsEntity);
        _loanDetailsRepository.Save();
        
        return new BaseResponse<LoanDetailsEntity>()
        {
            Description = "Данные по кредиту созданы",
            StatusCode = StatusCode.OK,
        };
    }

    private List<PaymentScheduleEntity> PaymentScheduleEntities(LoanDetailsViewModel loanDetailsViewModel, decimal bodyDebt, decimal monthlyRate,
        decimal monthlyPayment)
    {
        var paymentsSchedule = new List<PaymentScheduleEntity>();
        var dataPay = DateTime.Today;
        for (var i = 0; i < loanDetailsViewModel.Term; i++)
        {
            var marginSum = bodyDebt * monthlyRate; //Процентная часть
            var bodySum = monthlyPayment - marginSum; //Основная часть
            bodyDebt -= bodySum; // Остаток долга
            dataPay = dataPay.AddMonths(1); //Дата

            var paymentSchedule = new PaymentScheduleEntity
            {
                Date = dataPay,
                MarginSum = Math.Round(marginSum, 2),
                BodySum = Math.Round(bodySum, 2),
                BodyDebt = Math.Round(bodyDebt, 2),
            };
            paymentsSchedule.Add(paymentSchedule);
        }

        return paymentsSchedule;
    }
}