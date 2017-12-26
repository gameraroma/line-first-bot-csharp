using first.line.chatbot.LineMessaging;
using Line.Messaging;
using Line.Messaging.Webhooks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace first.line.chatbot.Messaging
{
    public class HttpTriggerFunction
    {
        private LineMessagingClient _messagingClient;

        public HttpTriggerFunction()
        {
            var channelToken = Environment.GetEnvironmentVariable("LineBotChannelToken");
            if (channelToken == null)
                channelToken = "";

            _messagingClient = new LineMessagingClient(channelToken);
        }

        public async Task<StatusCodeResult> Run(HttpRequest req)
        {
            IEnumerable<WebhookEvent> events;
            try
            {
                events = await req.GetWebhookEventsAsync();
            }
            catch (InvalidSignatureException e)
            {
                return new StatusCodeResult(403);
            }

            try
            {
                var app = new LineBotApp(_messagingClient);
                await app.RunAsync(events);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new StatusCodeResult(200);
        }
    }
}
