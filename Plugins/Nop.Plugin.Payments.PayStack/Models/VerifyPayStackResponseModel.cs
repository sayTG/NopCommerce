using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Payments.PayStack.Models
{
    class VerifyPayStackResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }
}
