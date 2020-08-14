using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Discovery.Domain.Models
{
    public class DiscoveryInfo
    {
        public string Id { get; set; }
        public string ScanType { get; set; }
        public string Payload { get; set; }
    }
}
