using MicroRabbit.Asset.Application.Models;
using MicroRabbit.Asset.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Asset.Application.Interfaces
{
    public interface IAssetService
    {
        //IEnumerable<Account> GetAccounts();
        //void Transfer(AccountTransfer accountTransfer);
        void StartAssetScan(ScanInfoModel scanInfo);
    }
}
