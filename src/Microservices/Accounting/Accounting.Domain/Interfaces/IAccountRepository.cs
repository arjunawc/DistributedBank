using DistributedBank.Services.Accounting.Domain.Models;
using System.Collections.Generic;

namespace DistributedBank.Services.Accounting.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
