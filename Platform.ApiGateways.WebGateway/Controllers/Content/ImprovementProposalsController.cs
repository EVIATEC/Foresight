using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Platform.ApiGateways.WebGateway.Models;

namespace Platform.ApiGateways.WebGateway.Controllers
{
    [Produces("application/json")]
    [Route("api/content/improvementProposals")]
    public class ImprovementProposals : Controller
    {
        private readonly ContentServiceConfiguration _contentSettings;

        public ImprovementProposals(IOptions<ApiSettings> settings)
        {
            this._contentSettings = settings.Value.ContentService;
        }

        [HttpPost]
        public ImprovementProposal PostImprovementProposal([FromBody] Models.ImprovementProposal newProposal)
        {
            try
            {
                ImprovementProposal result = Services.Content.ImprovementProposal.CreateProposal(this._contentSettings, newProposal);
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}

