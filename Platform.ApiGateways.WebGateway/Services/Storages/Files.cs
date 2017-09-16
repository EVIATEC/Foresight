using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Platform.ApiGateways.WebGateway.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Platform.ApiGateways.WebGateway.Services.Storages
{
    public class Files
    {
        public static long? NewFile(StorageServiceConfiguation settings, IFormFile file)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("api-version", "1.0");

                byte[] data;
                using (var br = new BinaryReader(file.OpenReadStream()))
                {
                    data = br.ReadBytes((int)file.OpenReadStream().Length);
                }

                ByteArrayContent bytes = new ByteArrayContent(data);
                MultipartFormDataContent multiContent = new MultipartFormDataContent();

                multiContent.Add(bytes, "file", file.FileName);

                HttpResponseMessage response = client.PostAsync(settings.ResourceRoot + "/files", multiContent).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                string stringData = response.Content.ReadAsStringAsync().Result;

                return Convert.ToInt64(stringData);
            }
        }

        public static bool DeleteFile(StorageServiceConfiguation settings, long fileId)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("api-version", "1.0");

                HttpResponseMessage response = client.DeleteAsync(settings.ResourceRoot + "/files/" + fileId.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return true; /// TODO return Convert.ToBoolean(stringData);
                }

                return false;
            }
        }

        public static FileStream GetFileStream(StorageServiceConfiguation settings, long fileId)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("api-version", "1.0");

                HttpResponseMessage response = client.DeleteAsync(settings.ResourceRoot + "/files/" + fileId.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    return null; /// TODO return Convert.ToBoolean(stringData);
                }

                return null;
            }
        }
    }
}
