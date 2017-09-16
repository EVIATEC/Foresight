using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Platform.ApiGateways.WebGateway.Services.Content
{
    public class Profiles
    {
        public static List<Models.Profile> ListProfiles(ContentServiceConfiguration settings)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync(settings.ResourceRoot + "/profiles").Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Models.Profile>>(stringData);
                }
            }

            return null;
        }
        public static Models.Profile DeleteProfile(ContentServiceConfiguration settings, long profileId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.DeleteAsync(settings.ResourceRoot + "/profiles/" + profileId.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Models.Profile>(stringData);
                }
            }

            return null;
        }
        
        public static Models.Profile ReadProfile(ContentServiceConfiguration settings, long profileId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl); // api/modules
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync(settings.ResourceRoot + "/profiles/" + profileId.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Models.Profile>(stringData);
                }
            }

            return null;
        }

        public static Models.Profile CreateProfile(ContentServiceConfiguration settings, Models.Profile newProfile)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");

                var stringContent = new StringContent(JsonConvert.SerializeObject(newProfile),
                         Encoding.UTF8,
                         "application/json");

                HttpResponseMessage response = client.PostAsync(settings.ResourceRoot + "/profiles", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {

                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Models.Profile>(stringData);
                }
            }

            return null;
        }

        public static Models.Profile UpdateProfile(ContentServiceConfiguration settings, Models.Profile profileToUpdate)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");

                var stringContent = new StringContent(JsonConvert.SerializeObject(profileToUpdate),
                         Encoding.UTF8,
                         "application/json");

                HttpResponseMessage response = client.PutAsync(settings.ResourceRoot + "/profiles/" + profileToUpdate.ProfileId.ToString(), stringContent).Result;
                if (response.IsSuccessStatusCode)
                {

                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Models.Profile>(stringData);
                }
            }

            return null;
        }
    }
}
