using DistributedBank.Domain.Core.Bus;
using DistributedBank.Services.Transfer.Application.Interfaces;
using DistributedBank.Services.Transfer.Domain.Interfaces;
using DistributedBank.Services.Transfer.Domain.Models;
using System.Collections.Generic;

namespace DistributedBank.Services.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }
    }
}
