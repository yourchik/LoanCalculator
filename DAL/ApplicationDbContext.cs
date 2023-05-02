using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
    }
    
    public DbSet<ClientEntity> Clients { get; set; }
    
    public DbSet<PaymentScheduleEntity> PaymentSchedules { get; set; }
    
    public DbSet<LoanDetailsEntity> LoansDetails { get; set; }
}