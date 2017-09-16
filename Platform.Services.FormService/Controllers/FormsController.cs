using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Platform.Services.FormService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Platform.Services.FormService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FormsController : Controller
    {
        private readonly WebAPIDataContext _context;

        public FormsController(WebAPIDataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<Models.Form> GetForms()
        {
            return _context.Forms.ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetForm([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @form = await _context.Forms.SingleOrDefaultAsync(m => m.FormId == id);

            if (@form == null)
            {
                return NotFound();
            }

            return Ok(@form);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForm([FromRoute] int id, [FromBody] Models.Form @form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @form.FormId)
            {
                return BadRequest();
            }

            _context.Entry(@form).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormExists(id))
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
        public async Task<IActionResult> PostEvent([FromBody] Models.Form @form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Forms.Add(@form);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FormExists(@form.FormId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetForm", new { id = @form.FormId}, @form);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @form = await _context.Forms.SingleOrDefaultAsync(m => m.FormId == id);
            if (@form == null)
            {
                return NotFound();
            }

            _context.Forms.Remove(@form);
            await _context.SaveChangesAsync();

            return Ok(@form);
        }

        private bool FormExists(long id)
        {
            return _context.Forms.Any(e => e.FormId== id);
        }
    }
}