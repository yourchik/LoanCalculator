using Domain.Entity;
using Domain.Interfaces.IResponse;
using Services.DtoModel;

namespace Services.Interfaces;

public interface ILoanDetailsService
{
    IBaseResponse<LoanDetailsEntity> CreateLoan(DtoLoanDetails loanDetails, DtoLoanCalculation loanCalculation,
        ClientEntity client);
    
    LoanDetailsEntity FindLoanDetailsEntity(ClientEntity client);
}

