using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Services.ContentService.Models
{
    public class Profile
    {
        public long ProfileId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string phone { get; set; }

        public string MobilePhone { get; set; }

        public string EMail { get; set; }

        public string Room { get; set; }

        public string Department { get; set; }

        public string JobTitle { get; set; }

        public string Supervisor { get; set; }

        public string Occupation { get; set; }        
    }
}
