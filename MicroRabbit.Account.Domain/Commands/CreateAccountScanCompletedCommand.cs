using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Account.Domain.Commands
{
    public class CreateAccountScanCompletedCommand : AccountScanCompletedCommand
    {
        public CreateAccountScanCompletedCommand(string scanID, string scanType, string payload)
        {
            ScanID = scanID;
            ScanType = scanType;
            Payload = payload;
        }
    }
}
