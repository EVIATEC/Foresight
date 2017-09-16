using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Platform.ApiGateways.WebGateway.Models;
using System;
using System.Collections.Generic;

namespace Platform.ApiGateways.WebGateway.Controllers
{
    [Produces("application/json")]
    [Route("api/Forms")]
    public class FormsController : Controller
    {
        private readonly ContentServiceConfiguration _contentSettings;

        public FormsController(IOptions<ApiSettings> settings)
        {
            this._contentSettings = settings.Value.ContentService;
        }

        [HttpGet]
        public IEnumerable<Form> GetEvents()
        {
            return Services.Content.Forms.ListForms(this._contentSettings);
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public Form GetForm([FromRoute] int id)
        {
            return Services.Content.Forms.ReadForm(this._contentSettings, id);
        }

        [HttpDelete("{id}"), Route("Delete/{id}")]
        public bool Delete(int id)
        {
            Services.Content.Forms.DeleteForm(this._contentSettings, id);
            return true;
        }

        // POST: Module/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public Form PostForm([FromBody] Form newForm)
        {
            try
            {
                Form result = Services.Content.Forms.CreateForm(this._contentSettings, newForm);
                return result;
            }
            catch
            {
                return null;
            }
        }
        
        [HttpPut("{id}")]
        // [ValidateAntiForgeryToken]
        public Form PutForm([FromRoute] int id, [FromBody] Form formToEdit)
        {
            try
            {
                Form result = Services.Content.Forms.UpdateForm(this._contentSettings, formToEdit);
                return result; // RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

