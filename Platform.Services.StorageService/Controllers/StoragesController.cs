using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Platform.Services.StorageService.Models;

namespace Platform.Services.StorageService.Controllers
{
    [Produces("application/json")]
    [Route("api/Storages")]
    public class StoragesController : Controller
    {
        private readonly WebAPIDataContext _context;

        public StoragesController(WebAPIDataContext context)
        {

            _context = context;
        }

        [HttpGet]
        public IEnumerable<Models.Storage> GetStorages()
        {
            return _context.Storages.ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStorage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @storage = await _context.Storages.SingleOrDefaultAsync(m => m.StorageId == id);

            if (@storage == null)
            {
                return NotFound();
            }

            return Ok(@storage);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorage([FromRoute] int id, [FromBody] Models.Storage @storage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @storage.StorageId)
            {
                return BadRequest();
            }

            _context.Entry(@storage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageExists(id))
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
        public async Task<IActionResult> PostStorage([FromBody] Models.Storage @storage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Storages.Add(@storage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StorageExists(@storage.StorageId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStorage", new { id = @storage.StorageId}, @storage);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @storage = await _context.Storages.SingleOrDefaultAsync(m => m.StorageId == id);
            if (@storage == null)
            {
                return NotFound();
            }

            _context.Storages.Remove(@storage);
            await _context.SaveChangesAsync();

            return Ok(@storage);
        }

        private bool StorageExists(long id)
        {
            return _context.Storages.Any(e => e.StorageId == id);
        }
    }
}