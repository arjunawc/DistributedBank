using DistributedBank.Services.Accounting.Application.Models;
using DistributedBank.Services.Accounting.Domain.Models;
using System.Collections.Generic;

namespace DistributedBank.Services.Accounting.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
