using System;
using System.Collections.Generic;
using System.Text;
using MicroRabbit.Discovery.Application.Models;
using MicroRabbit.Discovery.Domain.Models;

namespace MicroRabbit.Discovery.Application.Interfaces
{
    public interface IDiscoveryService
    {
        IEnumerable<Domain.Models.DiscoveryInfo> GetDiscoveryResult();
        void StartScan(ScanInfo discoveryTypes);
    }
}
