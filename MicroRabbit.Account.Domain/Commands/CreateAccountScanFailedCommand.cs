using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Account.Domain.Commands
{
    public class CreateAccountScanFailedCommand : AccountScanFailedCommand 
    {
        public CreateAccountScanFailedCommand(string scanID, string scanType, string payload)
        {
            ScanID = scanID;
            ScanType = scanType;
            Payload = payload;
        }
    }
}
