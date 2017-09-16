using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Services.EventService.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string Location { get; set; }

        public DateTimeOffset EventDate { get; set; }
        
        public string DescriptionShort { get; set; }

        public string DescriptionLong { get; set; }

        public List<Download> Downloads { get; set; }

        public List<Registration> Registrations { get; set; }
    }
}