using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MicroRabbit.Discovery.Domain.Commands
{
    public class CreateDiscoveryProcessStartCommand : DiscoveryProcessStartCommand
    {
        public CreateDiscoveryProcessStartCommand(string scanId, string scanType)
        {
            ScanID = scanId;
            ScanType = scanType;
        }
    }
}
