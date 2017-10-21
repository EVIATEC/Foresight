using Microsoft.Extensions.Options;
using Platform.ApiGateways.WebGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Platform.ApiGateways.WebGateway.Controllers.Content
{
    [Produces("application/json")]
    [Route("api/content/staffcouncil")]

    public class StaffCouncilController : Controller
    {

        private readonly ContentServiceConfiguration _contentSettings;

        public StaffCouncilController(IOptions<ApiSettings> settings)
        {
            this._contentSettings = settings.Value.ContentService;
        }

        [HttpPost]
        public StaffCouncil PostFeedback([FromBody] StaffCouncil newStaffCouncil)
        {
            try
            {
                StaffCouncil result = Services.Content.StaffCouncil.CreateStaffCouncil(this._contentSettings, newStaffCouncil);
                return result;
            }
            catch
            {
                return null;
            }
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
