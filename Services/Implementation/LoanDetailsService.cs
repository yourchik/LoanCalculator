using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Implementation.Response;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;
using Services.DtoModel;
using Services.Interfaces;

namespace Services.Implementation;

public class LoanDetailsService : ILoanDetailsService
{
    private readonly IBaseRepository<LoanDetailsEntity> _loanDetailsRepository;

    public LoanDetailsService (IBaseRepository<LoanDetailsEntity> loanDetailsRepository, IDtoCalculation dtoCalculation)
    {
        _loanDetailsRepository = loanDetailsRepository;
    }

    public IBaseResponse<LoanDetailsEntity> CreateLoan(LoanDetailsViewModel loanDetailsViewModel, DtoLoanCalculation loanCalculation, ClientEntity client)
    {
        var loanDetailsEntity = new LoanDetailsEntity
        {
            Sum = loanDetailsViewModel.Sum,
            Term = loanDetailsViewModel.Term,
            Rate = loanDetailsViewModel.Rate,
            PaymentType = loanDetailsViewModel.PaymentType,
            Overpayment = loanCalculation.Overpayment,
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
        return _loanDetailsRepository.GetAll().ToList().Find(x => x.ClientEntityId == client.Id) ?? throw new InvalidOperationException();
    }
}