using MicroRabbit.Asset.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Asset.Domain.Interfaces
{
    public interface IAssetRepository
    {
        IEnumerable<ScanInfo> GetAccounts();
    }
}
