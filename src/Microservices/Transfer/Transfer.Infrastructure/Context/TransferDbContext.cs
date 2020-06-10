using DistributedBank.Services.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DistributedBank.Services.Transfer.Infrastructure.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {
        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}
