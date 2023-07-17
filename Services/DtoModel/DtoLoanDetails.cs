using Domain.Enum;

namespace Services.DtoModel;

public class DtoLoanDetails
{
    public long Id { get; set; }
    
    public string  FullName { get; set; }
    
    public string Phone { get; set; }
    
    public decimal Sum { get; set; }
    
    public int Term { get; set; }
    
    public decimal Rate { get; set; }
    
    public PaymentType PaymentType { get; set; }

}