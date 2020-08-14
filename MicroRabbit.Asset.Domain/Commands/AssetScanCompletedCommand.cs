using MicroRabbit.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Asset.Domain.Commands
{
    public abstract class AssetScanCompletedCommand : Command
    {
        public string ScanID { get; set; }
        public string ScanType { get; set; }
        public string Payload { get; set; }
    }
}
