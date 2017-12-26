﻿using System;
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
using first.line.chatbot.Messaging;

namespace first.line.chatbot.Controllers
{
    [Route("callback")]
    public class CallbackController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Callback(HttpRequestMessage req)
        {
            IEnumerable<WebhookEvent> events;
            try
            {
                //Parse Webhook-Events
                var channelSecret = Environment.GetEnvironmentVariable("LineBotChannelSecret");
                if (channelSecret == null)
                    channelSecret = "";
                events = await req.GetWebhookEventsAsync(channelSecret);
            }
            catch (InvalidSignatureException e)
            {
                //Signature validation failed
                return new StatusCodeResult(403);
            }

            try
            {
                //Process the webhook-events
                var channelToken = Environment.GetEnvironmentVariable("LineBotChannelToken");
                if (channelToken == null)
                    channelToken = "";
                var client = new LineMessagingClient(channelToken);
                var app = new LineBotApp(client);
                await app.RunAsync(events);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return new StatusCodeResult(200);
        }
    }
}