using MicroRabbit.Discovery.Application.Interfaces;
using MicroRabbit.Discovery.Application.Models;
using MicroRabbit.Discovery.Domain.Commands;
using MicroRabbit.Discovery.Domain.Interfaces;
using MicroRabbit.Discovery.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using MicroRabbit.Discovery.Domain.Events;

namespace MicroRabbit.Discovery.Application.Services
{
    public class DiscoveryService : IDiscoveryService
    {
        private readonly IEventBus _bus;

        public DiscoveryService(IEventBus bus)
        {
            _bus = bus;
        }

        public IEnumerable<Domain.Models.DiscoveryInfo> GetDiscoveryResult()
        {
            throw new NotImplementedException();
        }

        public void StartScan(ScanInfo scanInfo)
        {

            //once discovery request received, push it to queue.
            var createProcessStartCommand = new CreateDiscoveryProcessStartCommand(scanInfo.Id, scanInfo.ScanType);

            _bus.SendCommand(createProcessStartCommand);
           
        }      
    }
}
