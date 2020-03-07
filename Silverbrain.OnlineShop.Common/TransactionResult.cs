using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Common
{
    public class TransactionResult
    {
        public enum ResultType {
            Success,
            Error
        }
        public string Type { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; } = null;
    }
}
