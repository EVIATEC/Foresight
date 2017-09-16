using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Platform.Services.StorageService.Models;
using System.IO;
using System;
using System.Security.Cryptography;

namespace Platform.Services.StorageService.Controllers
{
    [Produces("application/json")]
    [Route("api/files")]
    public class FilesController : Controller
    {
        private readonly WebAPIDataContext _context;

        public FilesController(WebAPIDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Models.File> GetFiles()
        {
            return _context.Files.Include(v=>v.CurrentVersion).ToList();            
        }

        [HttpGet("{id}")]
        public async Task<Models.File> GetCurrentFileProperties([FromRoute] long id)
        {
            Models.File @file = GetFileObject(id);

            // loading related data
            _context.Entry(@file).Reference(v => v.CurrentVersion).Load();

            return @file;

        }

        [HttpGet("{id}/file")]
        public async Task<IActionResult> DownloadFile([FromRoute] long id)
        {
            Models.File @file = GetFileObject(id);

            // loading related data
            _context.Entry(@file).Reference(v => v.CurrentVersion).Load();

            StorageSettingFilesystem @storageSetting = await _context.StoragesSettingsFilesystem.FirstAsync(s => s.StorageId == @file.CurrentVersion.StorageId);
            string filePath = Path.Combine(@storageSetting.BasePath, @file.CurrentVersion.SubPath, @file.CurrentVersion.FileGuid.ToString() + "." + @file.CurrentVersion.Extension);

            FileStream fs = new FileStream(filePath, FileMode.Open);

            return File(fs, @file.CurrentVersion.ContentType); // "application /octet-stream"); // FileStreamResult

        }


        [HttpGet("{id}/versions")]
        public IEnumerable<Models.FileVersion> GetFileVersions([FromRoute] long id)
        {
            return _context.FileVersions.ToList().Where(m => m.FileId == id);
        }


        [HttpGet("{fileId}/versions/{versionId}")]
        public async Task<FileVersion> GetFileVersion([FromRoute] long fileId, long versionId)
        {
            return await _context.FileVersions.SingleAsync(m => m.FileId == fileId && m.FileVersionId == versionId);
        }
        
        [HttpGet("{fileId}/versions/{versionId}/file")]
        public async Task<IActionResult> DownloadFileVersion([FromRoute] long fileId, long versionId)
        {
            FileVersion @version = await _context.FileVersions.SingleAsync(m => m.FileId == fileId && m.FileVersionId == versionId);
            
            StorageSettingFilesystem @storageSetting = await _context.StoragesSettingsFilesystem.FirstAsync(s => s.StorageId == @version.StorageId);
            string filePath = Path.Combine(@storageSetting.BasePath, @version.SubPath, @version.FileGuid.ToString() + "." + @version.Extension);

            FileStream fs = new FileStream(filePath, FileMode.Open);

            return File(fs, @version.ContentType, @version.OriginalFileName);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFile([FromRoute] long id)// , [FromBody] Models.File @file)
        {
            long storageId = 1; // TODO: Variabel machen

            StorageSettingFilesystem @storageSetting = await _context.StoragesSettingsFilesystem.SingleOrDefaultAsync(m => m.StorageId == storageId);

            var form = Request.Form;
            if (form.Files.Count == 0)
            {
                return BadRequest("File missing");
            }

            if (form.Files.Count > 1)
            {
                return BadRequest("only one file allowed");
            }

            IFormFile formFile = Request.Form.Files[0];
            
            Models.File @file = GetFileObject(id);
            FileVersion @version = new FileVersion();
            //@version.File = @file; //.FileId;
            @version.FileId = @file.FileId;
            @version.Created = DateTimeOffset.Now;
            @version.LastAccess = DateTime.Now;
            @version.Extension = Tools.Files.GetFileExtension(formFile.FileName);
            @version.StorageId = @storageSetting.StorageId;
            @version.FileGuid = Guid.NewGuid();
            @version.ContentType = formFile.ContentType;
            @version.OriginalFileName = formFile.FileName;
            @version.HashSha256 = Tools.Files.GenerateHashSHA256(formFile.OpenReadStream());
            @version.SubPath = GetSubPath(@storageSetting);
            @version.FileSizeInBytes = formFile.Length;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string targetDirectory = Path.Combine(@storageSetting.BasePath, @version.SubPath);
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string fileName = @version.FileGuid.ToString().Trim('{').Trim('}') + "." + @version.Extension;
            var savePath = Path.Combine(targetDirectory, fileName);

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            _context.FileVersions.Add(@version);
            

            try
            {
                await _context.SaveChangesAsync();

                _context.Entry(@version).State = EntityState.Modified;
                @version.File.CurrentVersionId = @version.FileVersionId;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!VersionExistsInDatabase(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            
            return CreatedAtAction("GetFileObject", new { id = @file.FileId }, @file);
        }
        

        [HttpPost]
        public async Task<IActionResult> PostFile()
        {
            long storageId = 1; // TODO: Variabel machen

            if (!Request.HasFormContentType)
            {
                return BadRequest();
            }

            Models.FileVersion @version = new FileVersion();
            var form = Request.Form;
            foreach (IFormFile formFile in form.Files)
            {
                StorageSettingFilesystem @storageSetting = await _context.StoragesSettingsFilesystem.SingleOrDefaultAsync(m => m.StorageId == storageId);

                @version.Created = DateTimeOffset.Now;
                @version.LastAccess = DateTime.Now;
                @version.Extension = Tools.Files.GetFileExtension(formFile.FileName);
                @version.StorageId = @storageSetting.StorageId;
                @version.FileGuid = Guid.NewGuid();
                @version.ContentType = formFile.ContentType;
                @version.OriginalFileName = formFile.FileName;
                @version.HashSha256 = Tools.Files.GenerateHashSHA256(formFile.OpenReadStream());
                @version.SubPath = GetSubPath(@storageSetting);
                @version.FileSizeInBytes = formFile.Length;
                @version.File = new Models.File();
                
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string targetDirectory = Path.Combine(@storageSetting.BasePath, @version.SubPath);
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }
                
                string fileName = @version.FileGuid.ToString().Trim('{').Trim('}') + "." + @version.Extension;
                var savePath = Path.Combine(targetDirectory, fileName);

                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }

                _context.FileVersions.Add(@version);
                await _context.SaveChangesAsync();

                @version.File.CurrentVersionId = @version.FileVersionId;
                await _context.SaveChangesAsync();

            }

            return Created($"api/files/{@version.File.FileId}", @version.File.FileId);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var @file = await _context.Files.SingleOrDefaultAsync(m => m.FileId == id); 

            if (@file == null)
            {
                return NotFound();
            }

            _context.Files.Remove(@file);
            await _context.SaveChangesAsync();
            
            return Ok(@file);
        }
 

        private bool FileExistsInDatabase(long id)
        {
            return _context.Files.Any(e => e.FileId == id);

        }
        private bool VersionExistsInDatabase(long id)
        {
            return _context.FileVersions.Any(e => e.FileVersionId == id);

        }
        
        private Models.File GetFileObject(long id)
        {
             return  _context.Files.Single(e => e.FileId == id);
        }

        private string GetSubPath(StorageSettingFilesystem @storageSetting)
        {
            long maxId = this._context.FileVersions.Where(f => f.StorageId == @storageSetting.StorageId).Max(f => f.FileId) + 1;
            return Math.Ceiling((decimal)maxId / (decimal)@storageSetting.MaxElements).ToString();
        }
    }
}