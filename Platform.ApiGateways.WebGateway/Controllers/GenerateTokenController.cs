using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Platform.ApiGateways.WebGateway.Controllers
{
    [Produces("application/json")]
    [Route("api/GenerateToken")]
    public class GenerateTokenController : Controller
    {
    }
}