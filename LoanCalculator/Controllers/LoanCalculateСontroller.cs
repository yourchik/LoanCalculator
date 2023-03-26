using LoanCalculator.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoanCalculator.Controllers;

public class LoanCalculateController : Controller
{
    
    [HttpGet]
    public IActionResult LoanCalculate()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult LoanCalculate(LoanDetailsViewModel loanDetails)
    {
        return View();
    }
}