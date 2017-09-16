using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.ApiGateways.WebGateway.Models
{
    public class Page
    {
        public long PageId { get; set; }

        public string PageName { get; set; }

        public string PageElements { get; set; }
    }
}
