using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Implementation.Response;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;
using Services.Interfaces;

namespace Services.Implementation;

public class ClientService : IClientService
{
    private readonly IBaseRepository<ClientEntity> _clientRepository;

    public ClientService(IBaseRepository<ClientEntity> clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public IBaseResponse<ClientEntity> CreateClient(LoanDetailsViewModel loanDetailsViewModel)
    {
        var client = _clientRepository.GetAll().FirstOrDefault(x => x.Phone == loanDetailsViewModel.Phone);

        if (client != null)
        {
            return new BaseResponse<ClientEntity>()
            {
                Description = "Клиент с таким номером телефона уже существует",
                StatusCode = StatusCode.ServerError,
            };
        }
        
        client = new ClientEntity
        {
            FullName = loanDetailsViewModel.FullName,
            Phone = loanDetailsViewModel.Phone,
        };

        _clientRepository.Create(client);
        _clientRepository.Save();

        return new BaseResponse<ClientEntity>()
        {
            Description = "Клиент создан",
            StatusCode = StatusCode.OK,
        };
    }
    
    public ClientEntity FindClient(string phone)
    {
        return _clientRepository.GetAll().FirstOrDefault(x => x.Phone == phone) ?? throw new InvalidOperationException();
    }
}