using MicroRabbit.Asset.Application.Interfaces;
using MicroRabbit.Asset.Application.Models;
using MicroRabbit.Asset.Domain.Commands;
using MicroRabbit.Asset.Domain.Interfaces;
using MicroRabbit.Asset.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Asset.Application.Services
{
    public class AssetService : IAssetService
    {
        //private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AssetService(IEventBus bus)  //IAccountRepository accountRepository, 
        {
            //_accountRepository = accountRepository;
            _bus = bus;
        }

        public void StartAssetScan(ScanInfoModel scaninfo)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Account> GetAccounts()
        //{
        //    return _accountRepository.GetAccounts();
        //}

        //public void Transfer(AccountTransfer accountTransfer)
        //{
        //    var createTransferCommand = new CreateTransferCommand(
        //            accountTransfer.FromAccount,
        //            accountTransfer.ToAccount,
        //            accountTransfer.TransferAmount
        //        );

        //    _bus.SendCommand(createTransferCommand);
        //}


    }
}
