using DistributedBank.Services.Accounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DistributedBank.Services.Accounting.Infrastructure.Context
{
    public class AccountingDbContext : DbContext
    {
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
