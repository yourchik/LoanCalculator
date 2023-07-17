using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace UI.ViewModel;

public class LoanDetailsViewModel
{
    public long Id { get; set; }
    
    [Display(Name = "ФИО"), Required(ErrorMessage = "Введите ФИО"),
     RegularExpression(@"[А-Я]{1}[а-я]{1,10} [А-Я]{1}[а-я]{1,10}", ErrorMessage = "Некорректное имя")]
    public string  FullName { get; set; }
    
    [Display(Name = "Телефон"), Required(ErrorMessage = "Введите номер телефона"),
     RegularExpression(@"[8]{1}[9]{1}[0-9]{9}", ErrorMessage = "Некорректный номер телефона")]
    public string Phone { get; set; }
    
    [Display(Name = "Сумма"), Required(ErrorMessage = "Введите сумму кредита"),
     Range(1000, 100000000, ErrorMessage = "Недопустимая сумма")]
    public decimal Sum { get; set; }
    
    [Display(Name = "Срок"), Required(ErrorMessage = "Введите срок кредита"), 
     Range(1, 360, ErrorMessage = "Недопустимый срок")]
    public int Term { get; set; }
    
    [Display(Name = "Процентная ставка"), Required(ErrorMessage = "Введите процентную ставку"),
     Range(1, 500, ErrorMessage = "Недопустимая процентная ставка")]
    public decimal Rate { get; set; }
    
    [Display(Name = "Тип платежей")]
    public PaymentType PaymentType { get; set; }
}