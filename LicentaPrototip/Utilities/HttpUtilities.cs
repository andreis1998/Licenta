using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace LicentaPrototip.Utilities
{
    public class HttpUtilities
    {
        private const string HouseIP = "http://93.118.47.218/";

        public async Task<string> PostAsync(string request, dynamic jsonObject)
        {
            var responseString = string.Empty;
            request = HouseIP + request;

            using (var client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(request, content);
                    responseString = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException)
                {
                   
                }
            }

            return responseString;
        }

        public async Task<string> PostAsync(string request)
        {
            var responseString = string.Empty;
            request = HouseIP + request;

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsync(request, null);
                    responseString = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException)
                {
                    
                }
            }

            return responseString;
        }
    }
}