using DistributedBank.Domain.Core.Bus;
using DistributedBank.Services.Accounting.Domain.Commands;
using DistributedBank.Services.Accounting.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DistributedBank.Services.Accounting.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            /* publish event to RabbitMQ */
            _bus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));

            return Task.FromResult(true);
        }
    }
}
