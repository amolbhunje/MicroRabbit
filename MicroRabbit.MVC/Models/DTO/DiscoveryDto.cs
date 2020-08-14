using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Models.DTO
{
    public class DiscoveryDto
    {
        public int noOfAssetScanReq { get; set; }
        public int noOfAccountScanReq { get; set; }
        public int noOfBothScanReq { get; set; }
    }
}
