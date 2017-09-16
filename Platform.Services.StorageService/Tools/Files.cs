using System;
//using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Platform.Services.StorageService.Tools
{
    public class Files
    {
     

        public void CreateFile(IFormFile formFile)
        {

        }

        public void UpdateFile(long fileId, IFormFile formFile)
        {

        }

        public static FileStreamResult GetFilestream(long fileId)
        {
            throw new NotImplementedException();
            /*
             *  var stream = await {{__get_stream_here__}}
        var response = File(stream, "application/octet-stream"); // FileStreamResult
        return response;*/

            // return File(new MemoryStream(_bytes), "application/octet-stream");

            /*
            System.IO.FileStream fs = new System.IO.FileStream(@"C:\temp\upload\6cf8ca93-ae86-4ac0-bc8e-66a198664232.txt", FileMode.Open);
            var response = File(fs, "application /octet-stream"); // FileStreamResult
            */


            /*
            const string contentType = "application/pdf";
            HttpContext.Response.ContentType = contentType;
            var result = new FileContentResult(System.IO.File.ReadAllBytes(@"{path_to_files}\file.pdf"), contentType)
            {
                FileDownloadName = $"{filename}.pdf"
            };

            return result;
            */
             
        }


        public static string GenerateHashSHA256(System.IO.Stream fileStream)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(fileStream);
                return BitConverter.ToString(hashedBytes).Replace("-", string.Empty);
            }
        }

        private static bool IsMultipartContentType(string contentType)
        {
            return
                !string.IsNullOrEmpty(contentType) &&
                contentType.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        

        public static string GetFileExtension(string fileName)
        {
            int lastIndex = fileName.LastIndexOf('.');
            if (lastIndex < 0 || fileName.Length <= 0)
            {
                return string.Empty;
            }

            return fileName.Substring(lastIndex + 1, fileName.Length - lastIndex - 1);

        }

        /*
        private static string GetBoundary(string contentType)
        {
            var elements = contentType.Split(' ');
            var element = elements.Where(entry => entry.StartsWith("boundary=")).First();
            var boundary = element.Substring("boundary=".Length);
            // Remove quotes
            if (boundary.Length >= 2 && boundary[0] == '"' &&
                boundary[boundary.Length - 1] == '"')
            {
                boundary = boundary.Substring(1, boundary.Length - 2);
            }
            return boundary;
        }*/

    }
    }
