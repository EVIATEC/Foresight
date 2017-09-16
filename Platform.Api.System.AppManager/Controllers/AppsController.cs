using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Platform.Api.System.AppManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Platform.Api.System.AppManager.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AppsController : Controller
    {
        private readonly WebAPIDataContext _context;

        public AppsController(WebAPIDataContext context)
        {
            _context = context;
        }

        // GET: api/Modules
        [HttpGet]
        public IEnumerable<App> GetModules()
        {
            return _context.Apps;
        }
        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModule([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @module = await _context.Apps.SingleOrDefaultAsync(m => m.AppId == id);

            if (@module == null)
            {
                return NotFound();
            }

            return Ok(@module);
        }


        // PUT: api/Modules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule([FromRoute] int id, [FromBody] App @app)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @app.AppId)
            {
                return BadRequest();
            }

            _context.Entry(@app).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
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

        // POST: api/Modules
        [HttpPost]
        public async Task<IActionResult> PostModule([FromBody] App @app)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Apps.Add(@app);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModuleExists(@app.AppId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModule", new { id = @app.AppId }, @app);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @app = await _context.Apps.SingleOrDefaultAsync(m => m.AppId == id);
            if (@app == null)
            {
                return NotFound();
            }

            _context.Apps.Remove(@app);
            await _context.SaveChangesAsync();

            return Ok(@app);
        }

        private bool ModuleExists(int id)
        {
            return _context.Apps.Any(e => e.AppId == id);
        }
    }
}