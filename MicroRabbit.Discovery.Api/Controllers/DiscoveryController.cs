using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Discovery.Application.Interfaces;
using MicroRabbit.Discovery.Application.Models;
using MicroRabbit.Discovery.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Asset.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoveryController : ControllerBase
    {
        //private readonly IAccountService _accountService;
        private readonly IDiscoveryService _discoveryService;
        private readonly ILogger<DiscoveryController> _logger;

        public DiscoveryController( IDiscoveryService discoveryService, ILogger<DiscoveryController> logger)
        {            
            _discoveryService = discoveryService;
            _logger = logger;
        }

       

        [HttpPost]
        public IActionResult PostDiscovery([FromBody] ScanInfo scanInfo)
        {
            _logger.LogInformation("Discovery request received for Scan ID: {0} ScanType:{1}", scanInfo.Id, scanInfo.ScanType);
            _discoveryService.StartScan(scanInfo);
            return Ok(_discoveryService);
        }
    }
}
