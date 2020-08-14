using MediatR;
using MicroRabbit.Asset.Domain.Commands;
using MicroRabbit.Asset.Domain.Events;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Asset.Domain.CommandHandlers
{
    public class AssetScanCompletedCommandHandler : IRequestHandler<CreateAssetScanCompletedCommand, bool>
    {
        private readonly IEventBus _bus;
        private readonly ILogger<AssetScanCompletedCommandHandler> _logger;

        public AssetScanCompletedCommandHandler(IEventBus bus, ILogger<AssetScanCompletedCommandHandler> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public Task<bool> Handle(CreateAssetScanCompletedCommand request, CancellationToken cancellationToken)
        {
                     
            //publish event to RabbitMQ
            _bus.Publish(new AssetScanCompletedEvent(request.ScanID, request.ScanType, request.Payload));

            return Task.FromResult(true);
        }


     
    }
}
