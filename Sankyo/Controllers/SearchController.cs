using Microsoft.Extensions.Configuration;
using Sankyo.Auth;
using Sankyo.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Sankyo.Controllers
{
    public class SearchController
    {
        readonly AuthenticationInfo authInfo;

        public SearchController(IConfiguration icon)
        {
            authInfo = new AuthenticationInfo(icon);
        }

        public void Page_Load(object sender, EventArgs e)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                    string q = "q=coronavirus";

                    ResultType result_type = ResultType.mixed;

                    string lang = "&lang=English";

                    string latitude = "39.035147";
                    string longitude = "-77.503127";
                    string radius = "3000";
                    string geocode = "&geocode=" + latitude + "," + longitude + "," + radius;

                    string count = "&count=99";

                    int since_id = 99999;

                    string max_id = "&max_id=100";

                    string include_entities = "&include_entities=true";

                    string unformatted = "https://api.twitter.com/1.1/search/tweets.json";

                    string url = String.Format(unformatted + "?" + q + geocode + lang + "&result_type=" + result_type.ToString() +
                    count + max_id + include_entities);
                string url2 = url;
                    client.BaseAddress = new System.Uri(url);

                Uri _url = client.BaseAddress;

                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer " + authInfo.BEARER);

                WebRequest requestObject = WebRequest.Create(client.BaseAddress);
                requestObject.Method = "GET";
                HttpWebResponse responseObjectGet = null;

                try
                {
                    responseObjectGet = (HttpWebResponse)requestObject.GetResponse();//400 Bad Request.  Works in POSTMAN with same URI and Token
                }
                catch (WebException webEx)
                {
                    Console.WriteLine(webEx.Response);
                    Console.WriteLine(webEx.Message);
                    Console.WriteLine(webEx.Status);

                }

                string stringResults = null;
                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    stringResults = sr.ReadToEnd();
                    sr.Close();
                }
            }




            
            
        }
    }
}
