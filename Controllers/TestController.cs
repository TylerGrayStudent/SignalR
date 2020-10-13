using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalRChat.Hubs;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hub;
        public TestController(IHubContext<ChatHub> hubcontext)
        {
            _hub = hubcontext;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            await _hub.Clients.All.SendAsync("Add",1);
            return Ok("test");
        }
    }
}
