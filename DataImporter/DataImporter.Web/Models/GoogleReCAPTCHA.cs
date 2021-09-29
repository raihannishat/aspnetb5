using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataImporter.Web.Models
{
    public class GoogleReCAPTCHA
    {
        private readonly ReCAPTCHASettings _settings;

        public GoogleReCAPTCHA(IOptions<ReCAPTCHASettings> settings)
        {
            _settings = settings.Value;
        }

        public virtual async Task<GoogleResponse> VerifyReCaptcha(string token)
        {
            var data = new ReCaptchaData()
            {
                Response = token,
                Secret = _settings.ReCAPTCHA_Secret_key
            };

            var client = new HttpClient();

            var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?=Secret{data.Secret}&response={data.Response}");

            return JsonConvert.DeserializeObject<GoogleResponse>(response);
        }
    }
}
