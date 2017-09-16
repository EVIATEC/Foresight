using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.Extensions.Options;
using Platform.ApiGateways.WebGateway.Models;

namespace Platform.ApiGateways.WebGateway.Controllers
{
    [Route("/api/[controller]")]
    [Route("/FrontendSystem/api/[controller]")]
    public class EventDownloadsController : Controller
    {
        private readonly EventServiceConfiguration _eventSettings;
        private readonly StorageServiceConfiguation _storageSettings;

        public EventDownloadsController(IOptions<ApiSettings> settings)
        {
            this._eventSettings = settings.Value.EventService;
            this._storageSettings = settings.Value.StorageService;
        }

        [HttpGet]
        public IEnumerable<EventDownload> GetDonloads()
        {
            return Services.Events.Downloads.ListDownloads(this._eventSettings);
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public EventDownload GetDownload([FromRoute] int id)
        {
            return Services.Events.Downloads.ReadDownload(this._eventSettings, id);
        }
        
        // GET: api/Modules/5
        [HttpGet("{id}/file")]
        public EventDownload GetDownloadFile([FromRoute] int id)
        {
            return null;
            //return Services.Events.Downloads.StreamDownloadFile(this._storageSettings, id);
        }

        [HttpDelete("{id}"), Route("[Controller]/{id}")]
        public bool Delete(int id)
        {

            EventDownload download = Services.Events.Downloads.ReadDownload(this._eventSettings, id);

            Services.Events.Downloads.DeleteDownload(this._eventSettings, id);

            Services.Storages.Files.DeleteFile(this._storageSettings, download.StorageServiceFileId);
            return true;
        }

        // POST: Module/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public EventDownload PostDownload([FromBody] EventDownload newDownload)
        {
            try
            {
                EventDownload result = Services.Events.Downloads.CreateDownload(this._eventSettings, newDownload);
                return result;
            }
            catch
            {
                return null;
            }
        }

        [HttpPut("{id}")]
       // [ValidateAntiForgeryToken]
        public EventDownload PutDownload([FromRoute] int id, [FromBody] EventDownload downloadToEdit)
        {
            try
            {
                EventDownload result = Services.Events.Downloads.UpdateDownload(this._eventSettings, downloadToEdit);
                return result; // RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
