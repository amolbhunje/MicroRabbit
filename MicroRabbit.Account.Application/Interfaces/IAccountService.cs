using MicroRabbit.Account.Application.Models;
using MicroRabbit.Account.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Account.Application.Interfaces
{
    public interface IAccountService
    {      
        void StartAccountScan(ScanInfoModel scanInfo);
    }
}
