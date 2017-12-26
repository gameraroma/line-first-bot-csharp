using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using first.line.chatbot.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Line.Messaging;
using Line.Messaging.Webhooks;
using System.Net.Http;

namespace first.line.chatbot.Controllers
{
    [Route("callback")]
    public class CallbackController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Callback([FromBody] MessageEvent request, [FromHeader] HeaderDictionary ex)
        {
            //var events = await request.GetWebhookEventsAsync("");

            var events = Request;

            return new StatusCodeResult(200);
        }
    }
}