using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Asset.Domain.Events;
using MicroRabbit.Asset.Domain.Interfaces;
using MicroRabbit.Asset.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Asset.Domain.Commands;
using System.Threading;
using System.Data.SqlTypes;

namespace MicroRabbit.Asset.Domain.EventHandlers
{
    public class StartAssetScanEventHandler : IEventHandler<StartAssetScanEvent>
    {
        //private readonly ILogger _logger;
        private readonly IEventBus _bus;
       

        public StartAssetScanEventHandler( IEventBus bus) //ILogger logger
        {
            //_logger = logger;
            _bus = bus;
        }

        public Task Handle(StartAssetScanEvent @event)
        {
           
            var result =  ScanAsset(new ScanInfo { ScanId = @event.ScanID, ScanType = @event.ScanType, Payload = @event.Payload });
                       

            return Task.CompletedTask;
        }

        public Task<bool> ScanAsset(ScanInfo scanInfo)
        {
            Random gen = new Random();
            int prob = gen.Next(100);

            //_logger.LogInformation(string.Format("Asset scan started for {0}", @event.ScanID));

            //Asset scan logic             
            Thread.Sleep(3000);

            //publish success or fail command
            if (prob <= 50)
            {

                var createAssetScanCompletedCommand = new CreateAssetScanCompletedCommand(scanInfo.ScanId, scanInfo.ScanType, scanInfo.Payload);
                _bus.SendCommand(createAssetScanCompletedCommand);
            }
            else
            {
                var createAssetScanFailedCommand = new CreateAssetScanFailedCommand(scanInfo.ScanId, scanInfo.ScanType, scanInfo.Payload);
                _bus.SendCommand(createAssetScanFailedCommand);
            }

            return  Task.FromResult<bool>(true);
        }
    }
}
