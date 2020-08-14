using MediatR;
using MicroRabbit.Account.Domain.Commands;
using MicroRabbit.Account.Domain.Events;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbit.Account.Domain.CommandHandlers
{
    public class AccountScanFailedCommandHandler : IRequestHandler<CreateAccountScanFailedCommand, bool>
    {
        private readonly IEventBus _bus;

        public AccountScanFailedCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateAccountScanFailedCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ
            _bus.Publish(new AccountScanFailedEvent(request.ScanID, request.ScanType, request.Payload));

            return Task.FromResult(true);
        }
    }
}
