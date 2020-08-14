using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Asset.Domain.Commands
{
    public class CreateAssetScanCompletedCommand : AssetScanCompletedCommand
    {
        public CreateAssetScanCompletedCommand(string scanID, string scanType, string payload)
        {
            ScanID = scanID;
            ScanType = scanType;
            Payload = payload;
        }
    }
}
