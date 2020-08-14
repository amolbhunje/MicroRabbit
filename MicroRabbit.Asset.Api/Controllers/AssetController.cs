using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Asset.Application.Interfaces;
using MicroRabbit.Asset.Application.Models;
using MicroRabbit.Asset.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Asset.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _accountService;

        public AssetController(IAssetService accountService)
        {
            _accountService = accountService;
        }

        //// GET api/banking
        //[HttpGet]
        //public ActionResult<IEnumerable<ScanInfo>> Get()
        //{
        //    return Ok(_accountService.GetAccounts());
        //}

        [HttpPost]
        public IActionResult Post([FromBody] ScanInfoModel scanInfoModel)
        {
            _accountService.StartAssetScan(scanInfoModel);
            return Ok(scanInfoModel);
        }
    }
}
