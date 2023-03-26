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
    private readonly IPaymentScheduleService _paymentScheduleService;
        
    public LoanCalculationService
        (IBaseRepository<LoanDetailsEntity> loanDetailsRepository, 
         IBaseRepository<PaymentScheduleEntity> paymentScheduleRepository, 
         IPaymentScheduleService paymentScheduleService)
    {
        _loanDetailsRepository = loanDetailsRepository;
        _paymentScheduleRepository = paymentScheduleRepository;
        _paymentScheduleService = paymentScheduleService;
    }

    public IBaseResponse<LoanDetailsEntity> CreateLoanDetails(LoanDetailsViewModel loanDetailsViewModel)
    {
        var monthlyRate = loanDetailsViewModel.Rate / 12 / 100;
        var totalRate = (decimal)Math.Pow((double)(1 + monthlyRate), loanDetailsViewModel.Term);
        var monthlyPayment = loanDetailsViewModel.Sum * monthlyRate * totalRate / (totalRate - 1);
        var bodyDebt = loanDetailsViewModel.Sum;
        var overpayment = Math.Round((monthlyPayment * loanDetailsViewModel.Term - loanDetailsViewModel.Sum), 2);
        
        var loanDetailsEntity = new LoanDetailsEntity
        {
            Sum = loanDetailsViewModel.Sum,
            Term = loanDetailsViewModel.Term,
            Rate = loanDetailsViewModel.Rate,
            PaymentType = loanDetailsViewModel.PaymentType,
            Overpayment = overpayment
        };

        var test = _paymentScheduleService.CreatePaymentScheduleEntity(bodyDebt, monthlyRate, monthlyPayment, loanDetailsViewModel.Term);
        
        _loanDetailsRepository.Create(loanDetailsEntity);
        
        return new BaseResponse<LoanDetailsEntity>()
        {
            Description = "Данные по кредиту созданы",
            StatusCode = StatusCode.OK,
        };
    }
    
}