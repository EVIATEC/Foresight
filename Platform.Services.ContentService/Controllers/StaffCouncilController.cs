﻿using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Platform.Services.ContentService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StaffCouncilController : Controller
    {
        private string _EOMInputPath;

        public StaffCouncilController(IOptions<ServiceSettings> settings)
        {
            this._EOMInputPath = settings.Value.EOMInputPath + "\\" + settings.Value.EOMFolderStaffCouncil;
        }

        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromBody] ContentService.Models.StaffCouncil @staffcouncil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: await, zuerst Tempfile-Schreiben;
            using (StreamWriter writer = System.IO.File.AppendText(_EOMInputPath + "\\" + Guid.NewGuid().ToString() + ".txt"))
            {
                var serializer = JsonSerializer.Create();
                serializer.Serialize(writer, @staffcouncil);
                writer.Close();
            }

            return AcceptedAtAction("PostFeedback");
        }
    }
}