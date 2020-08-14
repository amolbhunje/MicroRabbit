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
    public class AccountScanCompletedEventHandler : IEventHandler<AccountScanCompletedEvent>
    {
        private readonly ILogger<AccountScanCompletedEventHandler> _logger;
        private readonly IEventBus _bus;

        public AccountScanCompletedEventHandler(IEventBus bus, ILogger<AccountScanCompletedEventHandler> logger) 
        {
            _logger = logger;
            _bus = bus;
        }

        public Task Handle(AccountScanCompletedEvent @event)
        {
            //Logic for Asset scan completed event
            _logger.LogInformation("Account scan completed for Scan ID {0}", @event.ScanID);

           

            return Task.CompletedTask;
        }
    }
}
