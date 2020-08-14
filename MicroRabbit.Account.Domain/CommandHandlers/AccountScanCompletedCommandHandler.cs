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
    public class AccountScanCompletedCommandHandler : IRequestHandler<CreateAccountScanCompletedCommand, bool>
    {
        private readonly IEventBus _bus;

        public AccountScanCompletedCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateAccountScanCompletedCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ
            _bus.Publish(new AccountScanCompletedEvent(request.ScanID, request.ScanType, request.Payload));

            return Task.FromResult(true);
        }
    }
}
