using System.Text.Json;
using ChannelsExample.Model;
using ChannelsExample.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChannelsExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ProducerController : ControllerBase
    {
        private readonly ChannelService _channelService;

        public ProducerController(ChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpPost("PostData")]
        public async Task<IActionResult> Post([FromBody] Message message)
        {
            var jsonData = JsonSerializer.Serialize(message);
            await _channelService._Channel.Writer.WriteAsync(jsonData);

            return Ok(new
            {
                message = "Data sent to channel successfully"
            });
        }
    }
}
