using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Account.Application.Models
{
    public class ScanInfoModel
    {
        public string ScanId { get; set; }
        public string ScanType { get; set; }
        public string Payload { get; set; }
    }
}
