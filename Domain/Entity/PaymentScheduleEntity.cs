namespace Domain.Entity;

public class PaymentScheduleEntity : BaseEntity<long>
{
    public DateTime Date { get; set; }
    
    public decimal BodySum { get; set; }
    
    public decimal MarginSum { get; set; }
    
    public decimal BodyDebt { get; set; }
    
    public decimal TotalAmount => BodySum + MarginSum;
    
    public long LoanDetailsId { get; set; }
    
    public virtual LoanDetailsEntity LoanDetails{ get; set; }
}