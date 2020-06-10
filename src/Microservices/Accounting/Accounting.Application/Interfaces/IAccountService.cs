using DistributedBank.Services.Accounting.Domain.Models;
using System.Collections.Generic;

namespace DistributedBank.Services.Accounting.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}
