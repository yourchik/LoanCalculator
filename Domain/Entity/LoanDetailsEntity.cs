using Domain.Enum;

namespace Domain.Entity;

public class LoanDetailsEntity : BaseEntity<long>
{
    public decimal Sum { get; set; }
    
    public int Term { get; set; }
    
    public decimal Rate { get; set; }
    
    public decimal Overpayment { get; set; }

    public PaymentType PaymentType { get; set; }
    
    public long ClientEntityId { get; set; }
    
    public long PaymentSchedulesEntityId { get; set; }
    
    public virtual IEnumerable<PaymentScheduleEntity> PaymentSchedulesEntity { get; set; }
    
    public virtual ClientEntity ClientEntity { get; set; }
    
}