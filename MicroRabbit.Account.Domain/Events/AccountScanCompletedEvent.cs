using MicroRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Account.Domain.Events
{
    public class AccountScanCompletedEvent : Event
    {

        public string ScanID { get; private set; }
        public string ScanType { get; private set; }
        public string Payload { get; private set; }

        public AccountScanCompletedEvent(string scanID, string scanType, string payload)
        {
            ScanID = scanID;
            ScanType = scanType;
            Payload = payload;
        }

    }
}
