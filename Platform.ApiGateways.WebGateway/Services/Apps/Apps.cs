using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using Platform.ApiGateways.WebGateway.Models;

namespace Platform.ApiGateways.WebGateway.Services.Apps
{
    public class Apps
    {
        public static List<App> ListApps()
        {
            using (var client = new HttpClient())// System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61163/"); // api/modules
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync("api/apps").Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<App>>(stringData);
                }
            }

            return null;
        }
    }
}
