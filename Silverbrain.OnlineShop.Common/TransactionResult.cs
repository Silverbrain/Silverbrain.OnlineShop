﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Common
{
    public class TransactionResult
    {

        public bool IsSuccess { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
