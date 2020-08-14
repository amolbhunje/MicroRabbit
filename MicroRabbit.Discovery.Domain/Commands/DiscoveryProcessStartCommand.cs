using System;
using System.Collections.Generic;
using System.Text;
using MicroRabbit.Domain.Core.Commands;

namespace MicroRabbit.Discovery.Domain.Commands
{
    public class DiscoveryProcessStartCommand : Command
    {
        public string ScanID { get; set; }
        public string ScanType { get; set; }
    }
}
