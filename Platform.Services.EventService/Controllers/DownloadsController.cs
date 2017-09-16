using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Platform.Services.System.AppManager.Models;
using System.IO;

namespace Platform.Services.EventService.Controllers
{
    [Produces("application/json")]
    [Route("api/Downloads")]
    public class DownloadsController : Controller
    {
        private readonly WebAPIDataContext _context;

        public DownloadsController(WebAPIDataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<Models.Download> GetDownloads()
        {
            return _context.Downloads.ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDownload([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @download = await _context.Downloads.SingleOrDefaultAsync(m => m.DownloadId == id);

            if (@download == null)
            {
                return NotFound();
            }

            return Ok(@download);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutDownload([FromRoute] int id, [FromBody] Models.Download @download)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @download.DownloadId)
            {
                return BadRequest();
            }

            _context.Entry(@download).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DownloadExists(id))
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
        public async Task<IActionResult> PostDownload([FromBody] Models.Download @download)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Downloads.Add(@download);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (DownloadExists(@download.DownloadId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDownload", new { id = @download.DownloadId }, @download);
        }

        [HttpPost("{id}/file")]
        public async Task<IActionResult> PostDownloadFile([FromRoute]int id)
        {
            if (Request.HasFormContentType)
            {
                var form = Request.Form;
                foreach (var formFile in form.Files)
                {
                    var targetDirectory = @"C:\temp\Upload";
                    
                    var fileName = Guid.NewGuid().ToString().Trim('{').Trim('}') + "." + FileExtension(formFile.FileName);

                    var savePath = Path.Combine(targetDirectory, fileName);

                    using (var fileStream = new FileStream(savePath, FileMode.Create))
                    {
                        formFile.CopyTo(fileStream);
                    }
                }
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @download = await _context.Downloads.SingleOrDefaultAsync(m => m.DownloadId == id);
            if (@download == null)
            {
                return NotFound();
            }

            _context.Downloads.Remove(@download);
            await _context.SaveChangesAsync();

            return Ok(@download);
        }

        private bool DownloadExists(int id)
        {
            return _context.Downloads.Any(e => e.DownloadId == id);
        }

        private string FileExtension(string fileName)
        {
            int lastIndex = fileName.LastIndexOf('.');
            if (lastIndex < 0 || fileName.Length <= 0)
            {
                return string.Empty;
            }

            return fileName.Substring(lastIndex + 1, fileName.Length - lastIndex - 1);

        }

    }
}