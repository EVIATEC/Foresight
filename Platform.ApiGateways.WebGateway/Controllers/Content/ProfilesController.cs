using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Platform.ApiGateways.WebGateway.Models;
using System;
using System.Collections.Generic;

namespace Platform.ApiGateways.WebGateway.Controllers
{
    [Produces("application/json")]
    [Route("api/content/profiles")]
    public class ProfilesController : Controller
    {
        private readonly ContentServiceConfiguration _contentSettings;

        public ProfilesController(IOptions<ApiSettings> settings)
        {
            this._contentSettings = settings.Value.ContentService;
        }

        [HttpGet]
        public IEnumerable<Profile> GetEvents()
        {
            return Services.Content.Profiles.ListProfiles(this._contentSettings);
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public Profile GetProfile([FromRoute] int id)
        {
            return Services.Content.Profiles.ReadProfile(this._contentSettings, id);
        }

        [HttpDelete("{id}"), Route("Delete/{id}")]
        public bool Delete(int id)
        {
            Services.Content.Profiles.DeleteProfile(this._contentSettings, id);
            return true;
        }

        // POST: Module/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public Profile PostProfile([FromBody] Profile newProfile)
        {
            try
            {
                Profile result = Services.Content.Profiles.CreateProfile(this._contentSettings, newProfile);
                return result;
            }
            catch
            {
                return null;
            }
        }
        
        [HttpPut("{id}")]
        // [ValidateAntiForgeryToken]
        public Profile PutProfile([FromRoute] int id, [FromBody] Profile profileToEdit)
        {
            try
            {
                Profile result = Services.Content.Profiles.UpdateProfile(this._contentSettings, profileToEdit);
                return result; // RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

