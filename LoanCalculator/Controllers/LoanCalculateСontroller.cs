using Microsoft.AspNetCore.Mvc;
using Services.DtoModel;
using Services.Interfaces;
using UI.ViewModel;

namespace LoanCalculator.Controllers;

public class LoanCalculateController : Controller
{
    private readonly IDtoCalculation _dtoCalculation;

    public LoanCalculateController(IDtoCalculation dtoCalculation)
    {
        _dtoCalculation = dtoCalculation;
    }
    
    [HttpGet]
    public IActionResult LoanCalculate()
    {
        return View();
    }
    
    /// <summary>
    /// Вычисление кредита
    /// </summary>
    /// <param name="loanDetails"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult LoanCalculate(LoanDetailsViewModel loanDetails)
    {
        if (!ModelState.IsValid)
            return View(loanDetails);
        var loanDetailsDto = new DtoLoanDetails()
        {
            Id = loanDetails.Id,
            FullName = loanDetails.FullName,
            Phone = loanDetails.Phone,
            Sum = loanDetails.Sum,
            Term = loanDetails.Term,
            Rate = loanDetails.Rate,
            PaymentType = loanDetails.PaymentType
        };
        
        var dtoLoanCalculation = _dtoCalculation.DtoLoanCalculation(loanDetailsDto);

        return View();
    }
}
