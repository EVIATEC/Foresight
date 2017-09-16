using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Platform.Services.ContentService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FeedbacksController : Controller
    {        
        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromBody] ContentService.Models.Form @form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            // TODO: generate file for eom
            // send mail over eom
            // await;

            return AcceptedAtAction("PostFeedback");
        }        
    }
}