using MicroRabbit.Asset.Data.Context;
using MicroRabbit.Asset.Domain.Interfaces;
using MicroRabbit.Asset.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Asset.Data.Repository
{
    public class AssetRepository : IAccountRepository
    {
        private AssetDbContext _ctx;

        public AssetRepository(AssetDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _ctx.Accounts;
        }
    }
}
