using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Implementation.Response;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;
using Services.Interfaces;

namespace Services.Implementation;

public class LoanDetailsService : ILoanDetailsService
{
    private readonly IBaseRepository<LoanDetailsEntity> _loanDetailsRepository;
    
    public LoanDetailsService (IBaseRepository<LoanDetailsEntity> loanDetailsRepository, 
         IBaseRepository<PaymentScheduleEntity> paymentScheduleRepository)
    {
        _loanDetailsRepository = loanDetailsRepository;
    }

    public IBaseResponse<LoanDetailsEntity> CreateLoan(LoanDetailsViewModel loanDetailsViewModel, ClientEntity client)
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
            Overpayment = overpayment,
            ClientEntity = client,
            ClientEntityId = client.Id
        };

        _loanDetailsRepository.Create(loanDetailsEntity);
        _loanDetailsRepository.Save();
        
        return new BaseResponse<LoanDetailsEntity>()
        {
            Description = "Данные по кредиту созданы",
            StatusCode = StatusCode.OK,
        };
    }

    public LoanDetailsEntity FindLoanDetailsEntity(ClientEntity client)
    {
        return _loanDetailsRepository.GetAll().FirstOrDefault(x => x.ClientEntityId == client.Id) ?? throw new InvalidOperationException();
    }
}