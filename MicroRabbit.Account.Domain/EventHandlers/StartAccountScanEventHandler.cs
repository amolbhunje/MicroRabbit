using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Account.Domain.Interfaces;
using MicroRabbit.Account.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MicroRabbit.Account.Domain.Events;
using MicroRabbit.Account.Domain.Commands;

namespace MicroRabbit.Account.Domain.EventHandlers
{
    public class StartAccountScanEventHandler : IEventHandler<StartAccountScanEvent>
    {
        //private readonly ILogger _logger;
        private readonly IEventBus _bus;

        public StartAccountScanEventHandler(IEventBus bus) //ILogger logger
        {
            //_logger = logger;
            _bus = bus;
        }

        public Task Handle(StartAccountScanEvent @event)
        {
            //throw new Exception();
            var result = ScanAccount(new ScanInfo { ScanId = @event.ScanID, ScanType = @event.ScanType, Payload = @event.Payload });


            return Task.CompletedTask;
        }

        public Task<bool> ScanAccount(ScanInfo scanInfo)
        {
            //_logger.LogInformation(string.Format("Account scan started for {0}", @event.ScanID));

            Random gen = new Random();
            int prob = gen.Next(100);

            //Account scan logic             
            Thread.Sleep(3000);


            //publish success or fail command
            if (prob <= 50)
            {

                var createAccountScanCompletedCommand = new CreateAccountScanCompletedCommand(scanInfo.ScanId, scanInfo.ScanType, scanInfo.Payload);
                _bus.SendCommand(createAccountScanCompletedCommand);
            }
            else
            {
                var createAccountScanFailedCommand = new CreateAccountScanFailedCommand(scanInfo.ScanId, scanInfo.ScanType, scanInfo.Payload);
                _bus.SendCommand(createAccountScanFailedCommand);
            }
            return Task.FromResult<bool>(true);
        }
    }
}
