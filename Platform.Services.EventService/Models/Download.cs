using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Services.EventService.Models
{
    public class Download
    {
        public int DownloadId { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public string Name { get; set; }
        
        public long StorageServiceFileId { get; set; }
    }
}
