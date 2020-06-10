using DistributedBank.Domain.Core.Bus;
using DistributedBank.Services.Accounting.Application.Interfaces;
using DistributedBank.Services.Accounting.Application.Models;
using DistributedBank.Services.Accounting.Domain.Commands;
using DistributedBank.Services.Accounting.Domain.Interfaces;
using DistributedBank.Services.Accounting.Domain.Models;
using System.Collections.Generic;

namespace DistributedBank.Services.Accounting.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                    accountTransfer.FromAccount,
                    accountTransfer.ToAccount,
                    accountTransfer.TransferAmount
                );

            _bus.SendCommand(createTransferCommand);
        }
    }
}
