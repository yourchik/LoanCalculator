using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace LoanCalculator.ViewModels;

public class LoanDetailsViewModel
{
    public long Id { get; set; }
    [Display(Name = "ФИО")]
    public string  FullName { get; set; }
    [Display(Name = "Телефон")]
    public string Phone { get; set; }
    [Display(Name = "Сумма")]
    public decimal Sum { get; set; }
    [Display(Name = "Срок")]
    public int Term { get; set; }
    [Display(Name = "Процентная ставка")]
    public decimal Rate { get; set; }
    [Display(Name = "Тип платежей")]
    public PaymentType PaymentType { get; set; }
}