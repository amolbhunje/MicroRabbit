using System;
using System.Collections.Generic;
using System.Text;
using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Discovery.Domain.Events
{
    public class DiscoveryProcessStartEvent : Event
    {
        public string ScanID { get; private set; }
        public string ScanType { get; private set; }
        

        public DiscoveryProcessStartEvent(string scanID, string scanType)
        {
            ScanID = scanID;
            ScanType = scanType;            
        }
    }
}
