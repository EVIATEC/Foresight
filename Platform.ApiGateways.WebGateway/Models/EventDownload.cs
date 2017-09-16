using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.ApiGateways.WebGateway.Models
{
    public class EventDownload
    {
        public int DownloadId { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public string Name { get; set; }

        public long StorageServiceFileId { get; set; }
    }
}
