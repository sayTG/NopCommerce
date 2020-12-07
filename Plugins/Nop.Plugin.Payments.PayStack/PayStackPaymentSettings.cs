using Nop.Core.Configuration;

namespace Nop.Plugin.Payments.PayStack
{
    /// <summary>
    /// Represents settings of the PayPal Standard payment plugin
    /// </summary>
    public class PayStackPaymentSettings : ISettings
    {
        public string SecretKey { get; set; }
    }
}
