using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Platform.ApiGateways.WebGateway.Services.Content
{
    public class ImprovementProposal
    { 
        public static Models.ImprovementProposal CreateProposal(ContentServiceConfiguration settings, Models.ImprovementProposal newProposal)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");

                var stringContent = new StringContent(JsonConvert.SerializeObject(newProposal),
                         Encoding.UTF8,
                         "application/json");

                HttpResponseMessage response = client.PostAsync(settings.ResourceRoot + "/ImprovementProposals", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {

                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Models.ImprovementProposal>(stringData);
                }
            }

            return null;
        }
        
    }
}
