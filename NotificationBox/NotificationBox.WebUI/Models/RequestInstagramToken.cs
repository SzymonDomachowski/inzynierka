using Newtonsoft.Json.Linq;
using Ninject.Activation;
using NotificationBox.Domain.Entities;
using System.Net;
using System.Text.RegularExpressions;

namespace NotificationBox.WebUI.Models
{
    public class RequestInstagramToken
    {
        public string GetAuthorizationCode(string fullUrl)
        {
            return Regex.Replace(fullUrl, @".*?=", "");
        }

        public dynamic ReturnInstagramToken()
        {
            using (WebClient client = new WebClient())
            {
                byte[] response = client.UploadValues("https://api.instagram.com/oauth/access_token", new System.Collections.Specialized.NameValueCollection()
                {
                    { "client_id",InstagramApp.ClientId },
                    { "client_secret",InstagramApp.ClientSecret },
                    { "grant_type","authorization_code" },
                    { "redirect_uri",InstagramApp.RedirectUri },
                    { "code",InstagramApp.Code }
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return JObject.Parse(result);
            }
        }
    }
}