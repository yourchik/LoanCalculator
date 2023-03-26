using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Implementation.Response;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;
using Service.Interfaces;

namespace Service.Implementation;

public class LoanCalculationService : ILoanCalculationService
{
    private readonly IBaseRepository<LoanDetailsEntity> _loanDetailsRepository;
    private readonly IBaseRepository<PaymentScheduleEntity> _paymentScheduleRepository;

    public LoanCalculationService
        (IBaseRepository<LoanDetailsEntity> loanDetailsRepository, 
         IBaseRepository<PaymentScheduleEntity> paymentScheduleRepository)
    {
        _loanDetailsRepository = loanDetailsRepository;
        _paymentScheduleRepository = paymentScheduleRepository;
    }

    public IBaseResponse<LoanDetailsEntity> CreateLoanDetails(LoanDetailsViewModel loanDetailsViewModel)
    {
        var loanDetailsEntity = new LoanDetailsEntity
        {
            Sum = loanDetailsViewModel.Sum,
            Term = loanDetailsViewModel.Term,
            Rate = loanDetailsViewModel.Rate,
            PaymentType = loanDetailsViewModel.PaymentType
            
        };
        
        _loanDetailsRepository.Create(loanDetailsEntity);
        
        return new BaseResponse<LoanDetailsEntity>()
        {
            Description = "Данные по кредиту созданы",
            StatusCode = StatusCode.OK,
        };
    }
}