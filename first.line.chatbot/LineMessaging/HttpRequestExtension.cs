﻿using first.line.chatbot.Models;
using Line.Messaging;
using Line.Messaging.Webhooks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace first.line.chatbot.LineMessaging
{
    internal static class HttpRequestExtension
    {
        internal static async Task<IEnumerable<WebhookEvent>> GetWebhookEventsAsync(this HttpRequest request)
        {
            var channelSecret = Environment.GetEnvironmentVariable("LineBotChannelSecret");
            if (channelSecret == null)
                channelSecret = "";

            string body;
            using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8))
            {
                body = await reader.ReadToEndAsync();
            }

            var lineSignature = request.Headers["X-Line-Signature"];

            var isValid = ValidateSignature.IsSignatureValid(channelSecret, body, lineSignature);

            var eventsObject = JsonConvert.DeserializeObject<WebhookEventBody>(body);
            var events = eventsObject.Events;


            var webhookEvents = new List<WebhookEvent>();
            foreach (var ev in events)
                webhookEvents.Add(ev as WebhookEvent);
            return webhookEvents;
        }
    }
}
