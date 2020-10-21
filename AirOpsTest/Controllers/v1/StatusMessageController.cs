using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirOpsTest.DtoS;
using AirOpsTest.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirOpsTest.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StatusMessageController: ControllerBase
    {
        private readonly IStatusMessageService _statusMessageService;

        public StatusMessageController(IStatusMessageService statusMessageService)
        {
            _statusMessageService = statusMessageService;
        }
        
        [HttpGet(Name = nameof(GetMessages))]
        public async Task<ActionResult<IList<string>>> GetMessages(ApiVersion version)
        {
            return Ok(await _statusMessageService.GetAll());
        }
        
        [HttpPost(Name = nameof(AddMessage))]
        public IActionResult AddMessage(ApiVersion version, [FromBody] StatusMessageModel model)
        {
            try
            {
                if (model.Message.Length > 255)
                {
                    return BadRequest("Message too long");
                }
                _statusMessageService.AddMessage(model);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}