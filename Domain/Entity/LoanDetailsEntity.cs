using Domain.Enum;

namespace Domain.Entity;

public class LoanDetailsEntity : BaseEntity<long>
{
    public decimal Sum { get; set; }
    
    public int Term { get; set; }
    
    public decimal Rate { get; set; }
    
    public decimal Overpayment { get; set; }

    public PaymentType PaymentType { get; set; }
    
    public long ClientId { get; set; }
    
    public virtual IEnumerable<PaymentScheduleEntity> PaymentSchedule { get; set; }
    
    public virtual ClientEntity Client { get; set; }
    
}