using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Platform.Services.ContentService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Services.ContentService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        private readonly WebAPIDataContext _context;

        public ProfilesController(WebAPIDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Profile> GetProfiles()
        {
            return _context.Profiles.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @profile = await _context.Profiles.SingleOrDefaultAsync(m => m.ProfileId == id);

            if (@profile == null)
            {
                return NotFound();
            }

            return Ok(@profile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile([FromRoute] int id, [FromBody] ContentService.Models.Profile @profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @profile.ProfileId)
            {
                return BadRequest();
            }

            _context.Entry(@profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] ContentService.Models.Profile @profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Profiles.Add(@profile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfileExists(@profile.ProfileId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfile", new { id = @profile.ProfileId }, @profile);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @profile = await _context.Profiles.SingleOrDefaultAsync(m => m.ProfileId == id);
            if (@profile == null)
            {
                return NotFound();
            }

            _context.Profiles.Remove(@profile);
            await _context.SaveChangesAsync();

            return Ok(@profile);
        }

        private bool ProfileExists(long id)
        {
            return _context.Profiles.Any(e => e.ProfileId == id);
        }
    }
}