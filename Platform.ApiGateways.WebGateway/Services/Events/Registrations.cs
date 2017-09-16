using Newtonsoft.Json;
using Platform.ApiGateways.WebGateway.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Platform.ApiGateways.WebGateway.Services.Events
{
    public class Registrations
    {
        public static List<EventRegistration> ListRegistrations(EventServiceConfiguration settings)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync(settings.ResourceRoot + "/registrations").Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<EventRegistration>>(stringData);
                }
            }

            return null;
        }
        public static EventRegistration DeleteRegistration(EventServiceConfiguration settings, long registrationId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.DeleteAsync(settings.ResourceRoot + "/registrations/" + registrationId.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<EventRegistration>(stringData);
                }
            }

            return null;
        }


        public static EventRegistration ReadRegistration(EventServiceConfiguration settings, long registrationId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl); // api/modules
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync(settings.ResourceRoot + "/registrations/" + registrationId.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<EventRegistration>(stringData);
                }
            }

            return null;
        }

        public static EventRegistration CreateRegistration(EventServiceConfiguration settings, EventRegistration newRegistration)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");

                var stringContent = new StringContent(JsonConvert.SerializeObject(newRegistration),
                         Encoding.UTF8,
                         "application/json");

                HttpResponseMessage response = client.PostAsync(settings.ResourceRoot + "/registrations", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {

                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<EventRegistration>(stringData);
                }
            }

            return null;
        }

        public static EventRegistration UpdateRegistration(EventServiceConfiguration settings, EventRegistration registrationToUpdate)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");

                var stringContent = new StringContent(JsonConvert.SerializeObject(registrationToUpdate),
                         Encoding.UTF8,
                         "application/json");

                HttpResponseMessage response = client.PutAsync(settings.ResourceRoot + "/registrations/" + registrationToUpdate.RegistrationId.ToString(), stringContent).Result;
                if (response.IsSuccessStatusCode)
                {

                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<EventRegistration>(stringData);
                }
            }

            return null;
        }
    }
}