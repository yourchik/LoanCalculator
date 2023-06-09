﻿using Domain.Entity;
using Domain.Interfaces.IResponse;
using LoanCalculator.ViewModels;

namespace Services.Interfaces;

public interface IClientService
{
    IBaseResponse<ClientEntity> CreateClient(LoanDetailsViewModel loanDetails);
    
    ClientEntity FindClient(string phone);
}