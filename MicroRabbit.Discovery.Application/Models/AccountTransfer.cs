﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Discovery.Application.Models
{
    public class AccountTransfer
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
