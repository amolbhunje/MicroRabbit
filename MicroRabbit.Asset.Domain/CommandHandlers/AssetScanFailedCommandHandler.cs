using MediatR;
using MicroRabbit.Asset.Domain.Commands;
using MicroRabbit.Asset.Domain.Events;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbit.Asset.Domain.CommandHandlers
{
    public class AssetScanFailedCommandHandler : IRequestHandler<CreateAssetScanFailedCommand, bool>
    {
        private readonly IEventBus _bus;

        public AssetScanFailedCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateAssetScanFailedCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ
            _bus.Publish(new AssetScanFailedEvent(request.ScanID, request.ScanType, request.Payload));

            return Task.FromResult(true);
        }
    }
}
