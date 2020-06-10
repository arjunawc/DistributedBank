using DistributedBank.Services.Accounting.Application.Interfaces;
using DistributedBank.Services.Accounting.Domain.Interfaces;
using DistributedBank.Services.Accounting.Domain.Models;
using System.Collections.Generic;

namespace DistributedBank.Services.Accounting.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }
    }
}
