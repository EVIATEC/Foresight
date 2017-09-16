using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Services.EventService.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public DateTimeOffset RegistrationDate { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Salutation { get; set; }

        public string Title { get; set; }

        public string Street { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public string EMail { get; set; }
    }
}
