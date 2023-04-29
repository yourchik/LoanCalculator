namespace Domain.Entity;

public class ClientEntity : BaseEntity<long>
{
    public string  FullName { get; set; }
    
    public string Phone { get; set; }
    
    public virtual IEnumerable<LoanDetailsEntity> LoanDetails { get; set; }
}