using DistributedBank.Domain.Core.Bus;
using DistributedBank.Services.Transfer.Domain.Events;
using DistributedBank.Services.Transfer.Domain.Interfaces;
using DistributedBank.Services.Transfer.Domain.Models;
using System.Threading.Tasks;

namespace DistributedBank.Services.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amount
            });

            return Task.CompletedTask;
        }
    }
}
