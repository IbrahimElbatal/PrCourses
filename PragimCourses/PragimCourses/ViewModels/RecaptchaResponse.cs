using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace PragimCourses.ViewModels
{
    public class RecaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }

        public static RecaptchaResponse GetRecaptchaResponse()
        {
            var response = HttpContext.Current.Request["g-recaptcha-response"];
            const string secret = "6LfKuN0UAAAAAEHNIaCSVtwDeOlnL1pX7uKIQWU8";

            var client = new WebClient();
            var result =
                client.DownloadString(
                    $"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={response}");

            var recaptchaResponse = JsonConvert.DeserializeObject<RecaptchaResponse>(result);

            return recaptchaResponse;
        }
    }
}