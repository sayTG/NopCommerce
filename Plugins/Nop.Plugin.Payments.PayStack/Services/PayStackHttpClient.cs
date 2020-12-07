using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Plugin.Payments.PayStack.Models;

namespace Nop.Plugin.Payments.PayStack.Services
{
    /// <summary>
    /// Represents the HTTP client to request PayPal services
    /// </summary>
    public partial class PayStackHttpClient
    {
        #region Fields

        private readonly HttpClient _httpClient;
        private readonly PayStackPaymentSettings _PayStackPaymentSettings;

        #endregion

        #region Ctor

        public PayStackHttpClient(HttpClient client,
            PayStackPaymentSettings PayStackPaymentSettings)
        {
            //configure client
            client.Timeout = TimeSpan.FromSeconds(20);
            client.DefaultRequestHeaders.Add(HeaderNames.UserAgent, $"nopCommerce-{NopVersion.CurrentVersion}");

            _httpClient = client;
            _PayStackPaymentSettings = PayStackPaymentSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets PDT details
        /// </summary>
        /// <param name="tx">TX</param>
        /// <returns>The asynchronous task whose result contains the PDT details</returns>
        public string GetPdtDetailsAsync(string refrenceCode)
        {
            //get response
            if (!string.IsNullOrEmpty(refrenceCode))
            {
                VerifyPayStackResponseModel responseModel = new VerifyPayStackResponseModel();

                var uri = $"https://api.paystack.co/transaction/verify/" + refrenceCode;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer sk_test_14d4e5c61bcf32e8e01dc30dc7a6e7b9d734946e");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = client.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;
                    //var content = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<VerifyPayStackResponseModel>(content);
                }

                if (responseModel.Data.Status.ToLower() == "success")
                {
                    return "Success";
                }
                else
                {
                    return "Payment verification failed";
                }
            }
            else
            {
                return "No Reference code passed";
            }
        }

        /// <summary>
        /// Verifies IPN
        /// </summary>
        /// <param name="formString">Form string</param>
        /// <returns>The asynchronous task whose result contains the IPN verification details</returns>
        public async Task<string> VerifyIpnAsync(string formString)
        {
            //get response
            var url =
                "https://ipnpb.sandbox.paypal.com/cgi-bin/webscr";
            var requestContent = new StringContent($"cmd=_notify-validate&{formString}",
                Encoding.UTF8, MimeTypes.ApplicationXWwwFormUrlencoded);
            var response = await _httpClient.PostAsync(url, requestContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        #endregion
    }
}