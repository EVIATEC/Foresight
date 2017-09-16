using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Platform.ApiGateways.WebGateway
{
    public class ApiSettings
    {
        public EventServiceConfiguration EventService { get; set; }

        public AppServiceConfiguration AppService { get; set; }

        public ContentServiceConfiguration ContentService { get; set; }

        public StorageServiceConfiguation StorageService { get; set; }
    }

    public class EventServiceConfiguration : IApiSetting
    {
        public string BaseUrl { get; set; }

        public string ResourceRoot { get; set; }
    }

    public class ContentServiceConfiguration : IApiSetting
    {
        public string BaseUrl { get; set; }

        public string ResourceRoot { get; set; }
    }

    public class AppServiceConfiguration : IApiSetting
    {
        public string BaseUrl { get; set; }

        public string ResourceRoot { get; set; }
    }
    
    public class StorageServiceConfiguation : IApiSetting
    {
        public string BaseUrl { get; set; }

        public string ResourceRoot { get; set; }
    }

    public interface IApiSetting
    {
        string BaseUrl { get; set; }
        string ResourceRoot { get; set; }
    }


}
