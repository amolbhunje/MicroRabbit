using MediatR;
using MicroRabbit.Discovery.Domain.Commands;
using MicroRabbit.Discovery.Domain.Events;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbit.Discovery.Domain.CommandHandlers
{
    public class DiscoveryProcessStartCommandHandler:IRequestHandler<CreateDiscoveryProcessStartCommand, bool>
    {
        private readonly IEventBus _bus;

        public DiscoveryProcessStartCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateDiscoveryProcessStartCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ         
    
            _bus.Publish(new DiscoveryProcessStartEvent(request.ScanID, request.ScanType));            

            return Task.FromResult(true);
        }
    }
}
