using DistributedBank.Domain.Core.Bus;
using DistributedBank.Services.Transfer.Domain.Events;
using System.Threading.Tasks;

namespace DistributedBank.Services.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        public TransferEventHandler()
        {
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
