using MicroRabbit.Account.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Account.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<ScanInfo> GetAccounts();
    }
}
