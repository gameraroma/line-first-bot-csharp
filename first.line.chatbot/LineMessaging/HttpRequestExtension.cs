using Line.Messaging;
using Line.Messaging.Webhooks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace first.line.chatbot.LineMessaging
{
    internal static class HttpRequestExtension
    {
        /// <summary>
        /// Verify if the request is valid, then returns LINE Webhook events from the request
        /// </summary>
        /// <param name="request">HttpRequest</param>
        /// <returns>List of WebhookEvent</returns>
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

            if (isValid)
            {
                return WebhookEventParser.Parse(body);
            }
            else
                throw new InvalidSignatureException();
        }
    }
}
