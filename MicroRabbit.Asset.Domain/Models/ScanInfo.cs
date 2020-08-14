using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Asset.Domain.Models
{
    public class ScanInfo
    {
        public string ScanId { get; set; }
        public string ScanType { get; set; }
        public string Payload { get; set; }
    }
}
