using MicroRabbit.Account.Application.Interfaces;
using MicroRabbit.Account.Application.Models;
using MicroRabbit.Account.Domain.Commands;
using MicroRabbit.Account.Domain.Interfaces;
using MicroRabbit.Account.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Account.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IEventBus _bus;

        public AccountService(IEventBus bus) 
        {         
            _bus = bus;
        }

        public void StartAccountScan(ScanInfoModel scaninfo)
        {
            throw new NotImplementedException();
        }
    }
}
