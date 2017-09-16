using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.ApiGateways.WebGateway.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string Location { get; set; }

        public DateTime EventDate { get; set; }

        public string DescriptionShort { get; set; }

        public string DescriptionLong { get; set; }
    }
}
