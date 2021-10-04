using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataImporter.Web.Models.GoogleReCAPTCHA
{
    public class GoogleReCaptchaService
    {
        public GoogleReCaptchaService(IOptions<ReCAPTCHASettings> settings)
        {
            Settings = settings.Value;
        }

        private ReCAPTCHASettings Settings { get; }

        public virtual async Task<GoogleResponseData> VerifyReCaptcha(string token)
        {
            GoogleCaptchaData data = new GoogleCaptchaData
            {
                Response = token,
                Secret = Settings.ReCAPTCHA_Secret_key
            };

            using var client = new HttpClient();

            var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={data.Secret}&response={data.Response}");

            var captcha = JsonConvert.DeserializeObject<GoogleResponseData>(response);

            return captcha;
        }
    }

    public class GoogleCaptchaData
    {
        public string Response { get; set; }
        public string Secret { get; set; }
    }

    public class GoogleResponseData
    {
        public bool Success { get; set; }
        public double Score { get; set; }
        public string Action { get; set; }
        public DateTime Challenge_ts { get; set; }
        public string HostName { get; set; }
    }
}
