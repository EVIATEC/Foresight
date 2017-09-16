using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Services.ContentService.Models
{
    public class ImprovementProposal
    {
        public string Topic { get; set; }

        public string EmployeeName { get; set; }

        public string Process { get; set; }

        public string Description { get; set; }

        public string Improvement { get; set; }
    }
}
