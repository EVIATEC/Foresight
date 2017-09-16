using Newtonsoft.Json;
using Platform.ApiGateways.WebGateway.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Platform.ApiGateways.WebGateway.Services.Events
{
    public class Downloads
    {
        public static List<EventDownload> ListDownloads(EventServiceConfiguration settings)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync(settings.ResourceRoot + "/downloads").Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<EventDownload>>(stringData);
                }
            }

            return null;
        }
        public static EventDownload DeleteDownload(EventServiceConfiguration settings, long downloadId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.DeleteAsync(settings.ResourceRoot + "/downloads/" + downloadId.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<EventDownload>(stringData);
                }
            }

            return null;
        }

        public static FileStream GetFileStream(EventServiceConfiguration settingsEventService, StorageServiceConfiguation settingsStorrageService, long downloadId)
        {
            EventDownload download = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settingsEventService.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync(settingsEventService.ResourceRoot + "/downloads/" + downloadId.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    download = JsonConvert.DeserializeObject<EventDownload>(stringData);
                }
            }

            if (download == null)
            {
                return null;
            }
            
            return Services.Storages.Files.GetFileStream(settingsStorrageService, download.StorageServiceFileId);
        }


        public static EventDownload ReadDownload(EventServiceConfiguration settings, long downloadId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl); // api/modules
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");
                HttpResponseMessage response = client.GetAsync(settings.ResourceRoot + "/downloads/" + downloadId.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<EventDownload>(stringData);
                }
            }

            return null;
        }

        public static EventDownload CreateDownload(EventServiceConfiguration settings, EventDownload newDownload)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");

                var stringContent = new StringContent(JsonConvert.SerializeObject(newDownload),
                         Encoding.UTF8,
                         "application/json");

                HttpResponseMessage response = client.PostAsync(settings.ResourceRoot + "/downloads", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {

                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<EventDownload>(stringData);
                }
            }

            return null;
        }

        public static EventDownload UpdateDownload(EventServiceConfiguration settings, EventDownload downloadToUpdate)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("api-version", "1.0");

                var stringContent = new StringContent(JsonConvert.SerializeObject(downloadToUpdate),
                         Encoding.UTF8,
                         "application/json");

                HttpResponseMessage response = client.PutAsync(settings.ResourceRoot + "/downloads/" + downloadToUpdate.DownloadId.ToString(), stringContent).Result;
                if (response.IsSuccessStatusCode)
                {

                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<EventDownload>(stringData);
                }
            }

            return null;
        }
    }
}
