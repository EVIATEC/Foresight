using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Platform.Services.System.AppManager.Models;
using Microsoft.EntityFrameworkCore;

namespace Platform.Services.EventService.Controllers
{
    [Produces("application/json")]
    [Route("api/Registrations")]
    public class RegistrationsController : Controller
    {
        private readonly WebAPIDataContext _context;

        public RegistrationsController(WebAPIDataContext context)
        {
            _context = context;
        }

        // GET: api/Modules
        [HttpGet]
        public IEnumerable<Models.Registration> GetRegistrations()
        {
            return _context.Registrations.ToList();
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistration([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @registration = await _context.Registrations.SingleOrDefaultAsync(m => m.RegistrationId == id);

            if (@registration == null)
            {
                return NotFound();
            }

            return Ok(@registration);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration([FromRoute] int id, [FromBody] Models.Registration @registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @registration.RegistrationId)
            {
                return BadRequest();
            }

            _context.Entry(@registration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(id))
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
        public async Task<IActionResult> PostRegistration([FromBody] Models.Registration @registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Registrations.Add(@registration);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegistrationExists(@registration.RegistrationId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegistration", new { id = @registration.RegistrationId }, @registration);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @registration = await _context.Registrations.SingleOrDefaultAsync(m => m.RegistrationId == id);
            if (@registration == null)
            {
                return NotFound();
            }

            _context.Registrations.Remove(@registration);
            await _context.SaveChangesAsync();

            return Ok(@registration);
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registrations.Any(e => e.RegistrationId == id);
        }
    }
}