using Bliss.Recruitment.Simple.Api.Models.Response;
using Bliss.Recruitment.Simple.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        protected readonly IShareService _shareService;
        public ShareController(IShareService shareService)
        {
            this._shareService = shareService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromQuery] string destination_email, [FromQuery] string content_url)
        {
            try
            {
                await this._shareService.ShareByEmail(destination_email, content_url, "Share");
                
                return Ok(new ResponseModel("OK"));
            }
            catch (ArgumentNullException exception)
            {
                return BadRequest(new ResponseModel($"Bad Request. Either {nameof(destination_email)} not valid or empty {nameof(content_url)}"));
            }
        }

    }
}
