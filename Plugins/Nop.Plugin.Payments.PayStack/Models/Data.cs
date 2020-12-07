using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Payments.PayStack.Models
{
    class Data
    {
        public string Authorization_url { get; set; }
        public string Access_code { get; set; }
        public string Reference { get; set; }
        public string Amount { get; set; }
        public string Transaction_date { get; set; }
        public string Status { get; set; }
        public string Gateway_response { get; set; }
    }
}
