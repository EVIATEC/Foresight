using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Platform.ApiGateways.WebGateway.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace Platform.ApiGateways.WebGateway.Controllers
{
    [Route("/api/[controller]")]
    [Route("/FrontendSystem/api/[controller]")]
    [Authorize]
    public class EventsController : Controller
    {
        private readonly EventServiceConfiguration _eventSettings;
        private readonly StorageServiceConfiguation _storageSettings;
     
        
        public EventsController(IOptions<ApiSettings> settings)
        {
            this._eventSettings = settings.Value.EventService;
            this._storageSettings = settings.Value.StorageService;
        }

        [HttpGet]
        public IEnumerable<Event> GetEvents()
        {
            return Services.Events.Events.ListEvents(this._eventSettings);
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public Event GetEvent([FromRoute] int id)
        {
            return Services.Events.Events.ReadEvent(this._eventSettings, id);
        }

        [HttpDelete("{id}"), Route("Delete/{id}")]
        public bool Delete(int id)
        {
            Services.Events.Events.DeleteEvent(this._eventSettings, id);
            return true;
        }

        // POST: Module/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public Event PostEvent([FromBody] Event newEvent)
        {
            try
            {
                Event result = Services.Events.Events.CreateEvent(this._eventSettings, newEvent);
                return result;
            }
            catch
            {
                return null;
            }
        }


        [HttpGet("{id}/downloads")]
        public IEnumerable<Models.EventDownload> GetEventDownloads(long id)
        {
            List<EventDownload> downloads = Services.Events.Events.GetDownloads(this._eventSettings, id);
            return downloads;
        }

        [HttpGet("{id}/registrations")]
        public IEnumerable<Models.EventRegistration> GetEventRegistrations(long id)
        {
            List<EventRegistration> registration = Services.Events.Events.GetRegistrations(this._eventSettings, id);
            return registration;
        }


        [HttpPut("{id}")]
       // [ValidateAntiForgeryToken]
        public Event PutEvent([FromRoute] int id, [FromBody] Event eventToEdit)
        {
            try
            {
                Event result = Services.Events.Events.UpdateEvent(this._eventSettings, eventToEdit);
                return result; // RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return null;
            }
        }


        // POST: Module/Create
        [HttpPost("{id}/Downloads")]
        //[ValidateAntiForgeryToken]
        public EventDownload UploadFile(IFormFile file, [FromRoute] int id)
        {

            if (file.Length <= 0)
            {
                return null;
            }

            using (var client = new System.Net.Http.HttpClient())
            {
                // Upload File
                long? fileId = Services.Storages.Files.NewFile(this._storageSettings, file);
                if (!fileId.HasValue)
                {
                    return null;
                }

                Models.EventDownload newDownload = new EventDownload();
                
                newDownload.EventId = id;
                newDownload.StorageServiceFileId = fileId.Value;
                System.Text.RegularExpressions.Regex regexFileName = new System.Text.RegularExpressions.Regex(@".*(?=\.\w+$)");
                newDownload.Name = regexFileName.Match(file.FileName).Value;

                newDownload = Services.Events.Downloads.CreateDownload(this._eventSettings, newDownload);

                // TODO Im Fehlerfall Datei wieder löschen
                if (newDownload == null)
                {
                    Services.Storages.Files.DeleteFile(this._storageSettings, fileId.Value);
                }

                return newDownload;
            }

        }

    }
}

