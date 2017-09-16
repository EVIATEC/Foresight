using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Platform.ApiGateways.WebGateway.Models;
using System;
using System.Collections.Generic;

namespace Platform.ApiGateways.WebGateway.Controllers
{
    [Produces("application/json")]
    [Route("api/content/feedbacks")]
    public class FeedbacksController : Controller
    {
        private readonly ContentServiceConfiguration _contentSettings;

        public FeedbacksController(IOptions<ApiSettings> settings)
        {
            this._contentSettings = settings.Value.ContentService;
        }

        [HttpPost]
        public Feedback PostFeedback([FromBody] Feedback newFeedback)
        {
            try
            {
                Feedback result = Services.Content.Feedback.CreateFeedback(this._contentSettings, newFeedback);
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}

