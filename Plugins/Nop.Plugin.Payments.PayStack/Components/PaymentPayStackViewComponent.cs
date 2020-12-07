using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payments.PayStack.Components
{
    [ViewComponent(Name = "PaymentPayStack")]
    public class PaymentPayStackViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/Payments.PayStack/Views/PaymentInfo.cshtml");
        }
    }
}
