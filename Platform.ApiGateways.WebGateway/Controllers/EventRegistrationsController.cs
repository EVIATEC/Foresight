using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Platform.ApiGateways.WebGateway.Models;
using Microsoft.Extensions.Options;

namespace Platform.ApiGateways.WebGateway.Controllers
{
    [Produces("application/json")]
    [Route("api/EventRegistrations")]
    public class EventRegistrationsController : Controller
    {
        private readonly EventServiceConfiguration _settings;

        public EventRegistrationsController(IOptions<ApiSettings> settings)
        {

            this._settings = settings.Value.EventService;

        }

        [HttpGet]
        public IEnumerable<EventRegistration> GetRegistrations()
        {

            return Services.Events.Registrations.ListRegistrations(this._settings);

        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public EventRegistration GetRegistration([FromRoute] int id)
        {
            return Services.Events.Registrations.ReadRegistration(this._settings, id);
        }

        [HttpDelete("{id}"), Route("Delete/{id}")]
        public bool Delete(int id)
        {
            Services.Events.Registrations.DeleteRegistration(this._settings, id);
            return true;
        }

        // POST: Module/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public EventRegistration PostRegistration([FromBody] EventRegistration newRegistration)
        {
            try
            {
                EventRegistration result = Services.Events.Registrations.CreateRegistration(this._settings, newRegistration);
                return result;
            }
            catch
            {
                return null;
            }
        }

        [HttpPut("{id}")]
        // [ValidateAntiForgeryToken]
        public EventRegistration PutRegistration([FromRoute] int id, [FromBody] EventRegistration registrationToEdit)
        {
            try
            {
                EventRegistration result = Services.Events.Registrations.UpdateRegistration(this._settings, registrationToEdit);
                return result; // RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}