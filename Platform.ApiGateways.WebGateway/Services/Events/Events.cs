using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Platform.ApiGateways.WebGateway.Models;

namespace Platform.ApiGateways.WebGateway.Services.Events
{
    public class Events
    {
        public static List<Models.Event> ListEvents(EventServiceConfiguration settings)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync(settings.ResourceRoot + "/events").Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Models.Event>>(stringData);
                }
            }

            return null;
        }
        public static Event DeleteEvent(EventServiceConfiguration settings, long eventId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.DeleteAsync(settings.ResourceRoot + "/events/" + eventId.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Models.Event>(stringData);
                }
            }

            return null;
        }


        public static Event ReadEvent(EventServiceConfiguration settings, long eventId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl); // api/modules
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync(settings.ResourceRoot + "/events/" + eventId.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Models.Event>(stringData);
                }
            }

            return null;
        }

        public static Event CreateEvent(EventServiceConfiguration settings, Models.Event newEvent)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");

                var stringContent = new StringContent(JsonConvert.SerializeObject(newEvent),
                         Encoding.UTF8,
                         "application/json");

                HttpResponseMessage response = client.PostAsync(settings.ResourceRoot + "/events", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {

                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Models.Event>(stringData);
                }
            }

            return null;
        }

        public static Event UpdateEvent(EventServiceConfiguration settings, Models.Event eventToUpdate)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");

                var stringContent = new StringContent(JsonConvert.SerializeObject(eventToUpdate),
                         Encoding.UTF8,
                         "application/json");

                HttpResponseMessage response = client.PutAsync(settings.ResourceRoot + "/events/" + eventToUpdate.EventId.ToString(), stringContent).Result;
                if (response.IsSuccessStatusCode)
                {

                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Models.Event>(stringData);
                }
            }

            return null;
        }

        public static List<EventDownload> GetDownloads(EventServiceConfiguration settings, long eventId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync(settings.ResourceRoot + "/events/" + eventId.ToString() + "/downloads").Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<EventDownload>>(stringData);
                }
            }

            return null;

        }

        public static List<EventRegistration> GetRegistrations(EventServiceConfiguration settings, long eventId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync(settings.ResourceRoot + "/events/" + eventId.ToString() + "/registrations").Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<EventRegistration>>(stringData);
                }
            }

            return null;

        }

    }
}
