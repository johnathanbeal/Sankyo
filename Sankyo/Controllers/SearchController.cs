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
using Microsoft.AspNetCore.DataProtection;
using System.Text.Json;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Sankyo.Controllers
{
    public class SearchController
    {
        public string SearchString { get; }

        readonly AuthenticationInfo authInfo;

        public SearchController(IConfiguration icon)
        {
            authInfo = new AuthenticationInfo(icon);
        }

        public async Task Page_Load(object sender, EventArgs e)
        {
                   string q = "q=moms";

                    ResultType result_type = ResultType.popular;

                    string lang = "&lang=English";

                    string latitude = "39.035147";
                    string longitude = "-77.503127";
                    string radius = "3000";
                    string geocode = "&geocode=" + latitude + "," + longitude + "," + radius;

                    string count = "&count=99";

                    int since_id = 99999;

                    string max_id = "";//"&max_id=100";

                    string include_entities = "&include_entities=true";

                    string _base = "https://api.twitter.com/1.1/search/tweets.json";
                    string resource = "?" + q + geocode + lang + "&result_type=" + result_type.ToString() +
                    count + max_id + include_entities;

                    string url = String.Format(_base);
                    Console.WriteLine("\nThe URI is ${url}");                   

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_base);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authInfo.BEARER);

                HttpResponseMessage response = new HttpResponseMessage();

                response = await client.GetAsync(resource).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    String result = response.Content.ReadAsStringAsync().Result;
                    //responseObj = JsonConvert.DeserializationObject<
                    var headers = response.Headers;
                    var reason = response.ReasonPhrase;
                    //StreamReader reader = new StreamReader(response.);

                    //string responseFromServer = reader.ReadToEnd();

                    //Console.WriteLine("\nThe contents received:");
                    Console.WriteLine(headers);
                    Console.WriteLine(reason);

                    //reader.Close();
                    //streamResponse.Close();
                }
            }

            

            /*HttpWebRequest request = null;
            HttpWebResponse myWebResponse = null;
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Headers.Add("Authorization", authInfo.BEARER);
                    request.Headers.Add("Connection", "keep-alive");
                    request.Headers.Add("Content-Type", "application/json");
                    request.Headers.Add("Accept", "application/json");
                    myWebResponse = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException webEx)
                {
                    Console.WriteLine(webEx.Response);
                    Console.WriteLine(webEx.Message);
                    Console.WriteLine(webEx.Status);
                    Console.WriteLine(webEx.Data);
                
                }
                */
            
           
        }




            
            
        
    }
}
