using ChannelsExample.Service;
using Microsoft.AspNetCore.Mvc;

namespace ChannelsExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ConsumerController : ControllerBase
    {
        private readonly ChannelService _channelService;

        public ConsumerController(ChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpPost("GetData")]
        public IActionResult Get()
        {
            return Ok(_channelService._ConsumedMessage);
        }
    }
}
