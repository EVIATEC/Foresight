using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Platform.ApiGateways.WebGateway.Services.Content
{
    public class Feedback
    { 
        public static Models.Feedback CreateFeedback(ContentServiceConfiguration settings, Models.Feedback newFeedback)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");

                var stringContent = new StringContent(JsonConvert.SerializeObject(newFeedback),
                         Encoding.UTF8,
                         "application/json");

                HttpResponseMessage response = client.PostAsync(settings.ResourceRoot + "/Feedbacks", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {

                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Models.Feedback>(stringData);
                }
            }

            return null;
        }
        
    }
}
