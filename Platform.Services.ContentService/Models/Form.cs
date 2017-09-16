using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Services.ContentService.Models
{
    public class Form
    {
        public long FormId { get; set; }

        public string FormName { get; set; }

        public string ApiUrl { get; set; }

        public string FormDefinition { get; set; }
    }
}
