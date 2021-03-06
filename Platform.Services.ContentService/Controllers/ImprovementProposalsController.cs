﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Platform.Services.ContentService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ImprovementProposalsController : Controller
    {
        private string _EOMInputPath;

        public ImprovementProposalsController(IOptions<ServiceSettings> settings)
        {
            this._EOMInputPath = settings.Value.EOMInputPath + "\\" + settings.Value.EOMFolderImprovement;
        }

        [HttpPost]
        public async Task<IActionResult> PostImprovementProposal([FromBody] ContentService.Models.ImprovementProposal @improvementProposal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: await, zuerst Tempfile-Schreiben;
            using (StreamWriter writer = System.IO.File.AppendText(_EOMInputPath + "\\" + Guid.NewGuid().ToString() + ".txt"))
            {
                var serializer = JsonSerializer.Create();
                serializer.Serialize(writer, @improvementProposal);
                writer.Close();
            }

            return AcceptedAtAction("PostImprovementProposal");
        }        
    }
}