namespace Services.DtoModel;

public class DtoLoanCalculation
{
    public decimal MonthlyRate { get; set; }
    
    public decimal TotalRate { get; set; }
    
    public decimal MonthlyPayment { get; set; }
    
    public decimal BodyDebt { get; set; }
    
    public decimal Overpayment { get; set; }
}