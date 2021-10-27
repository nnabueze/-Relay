using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Relay.Domain.Interface;
using Relay.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class TempleRelayController : ControllerBase
    {
        private readonly ITemple _temple;

        public TempleRelayController(ITemple temple)
        {
            _temple = temple;
        }

        [HttpPost]
        [Route("PushNotification")]
        public async Task<IActionResult> Notification(TempleModel request)
        {
            var response = await _temple.SendNotification(request);

            return Ok();
        }
    }
}
