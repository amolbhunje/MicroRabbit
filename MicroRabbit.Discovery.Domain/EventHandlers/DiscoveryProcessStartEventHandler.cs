using System;
using System.Collections.Generic;
using System.Text;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Discovery.Domain.Events;
using System.Threading.Tasks;
using MicroRabbit.Discovery.Domain.Models;
using System.Threading;
using System.Data.SqlTypes;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Discovery.Domain.EventHandlers
{
    public class DiscoveryProcessStartEventHandler : IEventHandler<DiscoveryProcessStartEvent>
    {
        private readonly IEventBus _bus;
        private readonly ILogger<DiscoveryProcessStartEventHandler> _logger;

        public DiscoveryProcessStartEventHandler(IEventBus bus, ILogger<DiscoveryProcessStartEventHandler> logger) 
        {
            _bus = bus;
            _logger = logger;
        }

        public Task Handle(DiscoveryProcessStartEvent @event)
        {
            //throw new Exception();
            ProcessDiscoveryRequest(new DiscoveryInfo { Id = @event.ScanID, ScanType = @event.ScanType });

            return Task.CompletedTask;
        }

        public Task<bool> ProcessDiscoveryRequest(DiscoveryInfo discoveryInfo)
        {
            _logger.LogInformation("Discovery processs start for Scan ID {0}", discoveryInfo.Id);
            //Logic for discovery request process
            Task.Delay(3000);   //delay 

            _logger.LogInformation("Discovery processs complete for Scan ID {0}", discoveryInfo.Id);

            //Publish event to RabbitMQ
            if (discoveryInfo.ScanType == "Account")
                _bus.Publish(new StartAccountScanEvent(discoveryInfo.Id, discoveryInfo.ScanType, discoveryInfo.Payload));
            else
                _bus.Publish(new StartAssetScanEvent(discoveryInfo.Id, discoveryInfo.ScanType, discoveryInfo.Payload));

            return Task.FromResult<bool>(true);
        }
    }
}



