using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Common
{
    public class TransactionStatus
    {
        public enum StatusType {
            Success,
            Error
        }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
