using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Payments.PayStack.Models
{
    class PayStackRequestModel
    {
        public string Reference { get; set; }
        public string Email { get; set; }
        public string Amount { get; set; }
        public string SecretKey { get; set; }
        public string Callback_url { get; set; }
    }
}
