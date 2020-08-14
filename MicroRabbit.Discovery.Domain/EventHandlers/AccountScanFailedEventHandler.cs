using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Discovery.Domain.Events;
using MicroRabbit.Discovery.Domain.Interfaces;
using MicroRabbit.Discovery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Discovery.Domain.Commands;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Discovery.Domain.EventHandlers
{
    public class AccountScanFailedEventHandler : IEventHandler<AccountScanFailedEvent>
    {
        private readonly ILogger<AccountScanFailedEventHandler> _logger;
        private readonly IEventBus _bus;

        public AccountScanFailedEventHandler( IEventBus bus, ILogger<AccountScanFailedEventHandler> logger) 
        {
            _logger = logger;
            _bus = bus;
        }

        public Task Handle(AccountScanFailedEvent @event)
        {
            //Logic for Asset scan failed event
            _logger.LogInformation("Account scan failed for Scan ID {0}", @event.ScanID);

            return Task.CompletedTask;
        }
    }
}
