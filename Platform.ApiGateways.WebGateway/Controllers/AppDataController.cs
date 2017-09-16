using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Platform.ApiGateways.WebGateway.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Platform.ApiGateways.WebGateway.Controllers
{

    [Route("api/[controller]")]
    public class AppDataController : Controller
    {

        [HttpGet("[action]")]
        public IEnumerable<App> Apps()
        {
            return Services.Apps.Apps.ListApps();
            /*
            IEnumerable<App> x = Enumerable.Range(1, 5).Select(index => new App
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                Name = "K2"
            });

            return x;
            */
        }

    }
}
