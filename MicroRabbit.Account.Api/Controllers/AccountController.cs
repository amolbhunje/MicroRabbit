using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Account.Application.Interfaces;
using MicroRabbit.Account.Application.Models;
using MicroRabbit.Account.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Asset.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
    

        [HttpPost]
        public IActionResult Post([FromBody] ScanInfoModel scanInfoModel)
        {
            _accountService.StartAccountScan(scanInfoModel);
            return Ok(scanInfoModel);
        }
    }
}
