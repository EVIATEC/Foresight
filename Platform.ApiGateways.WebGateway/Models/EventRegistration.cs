using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.ApiGateways.WebGateway.Models
{
    public class EventRegistration
    {
        public int RegistrationId { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public DateTime RegistrationDate { get; set; }

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
