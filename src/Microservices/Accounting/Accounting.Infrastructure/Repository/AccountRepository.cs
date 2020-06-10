using DistributedBank.Services.Accounting.Domain.Interfaces;
using DistributedBank.Services.Accounting.Domain.Models;
using DistributedBank.Services.Accounting.Infrastructure.Context;
using System.Collections.Generic;

namespace DistributedBank.Services.Accounting.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountingDbContext _context;

        public AccountRepository(AccountingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts;
        }
    }
}
