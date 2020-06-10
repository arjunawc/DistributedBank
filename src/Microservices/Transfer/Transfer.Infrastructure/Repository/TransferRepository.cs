using DistributedBank.Services.Transfer.Domain.Interfaces;
using DistributedBank.Services.Transfer.Domain.Models;
using DistributedBank.Services.Transfer.Infrastructure.Context;
using System.Collections.Generic;

namespace DistributedBank.Services.Transfer.Infrastructure.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _context;

        public TransferRepository(TransferDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _context.TransferLogs;
        }

        public void Add(TransferLog transferLog)
        {
            _context.TransferLogs.Add(transferLog);
            _context.SaveChanges();
        }
    }
}
