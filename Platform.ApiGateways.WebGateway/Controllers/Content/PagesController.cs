using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Platform.ApiGateways.WebGateway.Models;
using Microsoft.Extensions.Options;

namespace Platform.ApiGateways.WebGateway.Controllers
{
    [Produces("application/json")]
    [Route("api/content/pages")]
    public class PagesController : Controller
    {
        private readonly ContentServiceConfiguration _contentSettings;

        public PagesController(IOptions<ApiSettings> settings)
        {
            this._contentSettings = settings.Value.ContentService;
        }

        [HttpGet]
        public IEnumerable<Page> GetPages()
        {
            return Services.Content.Pages.ListPages(this._contentSettings);
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public Page GetPage([FromRoute] int id)
        {
            return Services.Content.Pages.ReadPage(this._contentSettings, id);
        }

        [HttpDelete("{id}"), Route("Delete/{id}")]
        public bool Delete(int id)
        {
            Services.Content.Pages.DeletePage(this._contentSettings, id);
            return true;
        }

        // POST: Module/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public Page PostPage([FromBody] Page newPage)
        {
            try
            {
                Page result = Services.Content.Pages.CreatePage(this._contentSettings, newPage);
                return result;
            }
            catch
            {
                return null;
            }
        }

        [HttpPut("{id}")]
        // [ValidateAntiForgeryToken]
        public Page PutPage([FromRoute] int id, [FromBody] Page pageToEdit)
        {
            try
            {
                Page result = Services.Content.Pages.UpdatePage(this._contentSettings, pageToEdit);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
