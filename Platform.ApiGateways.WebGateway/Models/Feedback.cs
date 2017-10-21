using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.ApiGateways.WebGateway.Models
{
    public class Feedback
    {
        public string Topic { get; set; }
        
        public string Comment { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

    }
}
