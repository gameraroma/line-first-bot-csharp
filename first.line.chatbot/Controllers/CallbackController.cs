using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using first.line.chatbot.Messaging;

namespace first.line.chatbot.Controllers
{
    [Route("callback")]
    public class CallbackController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Callback()
        {
            var triggerFunction = new HttpTriggerFunction();
            var statusCode = await triggerFunction.Run(Request);
            return statusCode;
        }
    }
}