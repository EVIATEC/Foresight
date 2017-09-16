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
    public class PagesController : Controller
    {
        private readonly WebAPIDataContext _context;

        public PagesController(WebAPIDataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<Page> GetPages()
        {
            return _context.Pages.ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @page = await _context.Pages.SingleOrDefaultAsync(m => m.PageId == id);

            if (@page == null)
            {
                return NotFound();
            }

            return Ok(@page);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPage([FromRoute] int id, [FromBody] ContentService.Models.Page @page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @page.PageId)
            {
                return BadRequest();
            }

            _context.Entry(@page).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageExists(id))
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
        public async Task<IActionResult> PostEvent([FromBody] ContentService.Models.Page @page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pages.Add(@page);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PageExists(@page.PageId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPage", new { id = @page.PageId}, @page);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @page = await _context.Pages.SingleOrDefaultAsync(m => m.PageId == id);
            if (@page == null)
            {
                return NotFound();
            }

            _context.Pages.Remove(@page);
            await _context.SaveChangesAsync();

            return Ok(@page);
        }

        private bool PageExists(long id)
        {
            return _context.Pages.Any(e => e.PageId== id);
        }
    }
}