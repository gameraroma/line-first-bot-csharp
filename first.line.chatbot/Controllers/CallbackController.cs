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
using first.line.chatbot.Messaging;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace first.line.chatbot.Controllers
{
    [Route("callback")]
    public class CallbackController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Callback(HttpRequestMessage req)
        {

            try
            {
                var channelSecret = Environment.GetEnvironmentVariable("LineBotChannelSecret");
                if (channelSecret == null)
                    channelSecret = "";
                string body;

                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    body = await reader.ReadToEndAsync();
                }

                string signature;

                var encoding = new ASCIIEncoding();
                var keyByte = encoding.GetBytes(channelSecret);
                var messageByte = encoding.GetBytes(body);
                using (var hmacsha256 = new HMACSHA256(keyByte))
                {
                    byte[] hashmessage = hmacsha256.ComputeHash(messageByte);
                    signature = Convert.ToBase64String(hashmessage);
                }

                var lineSignature = Request.Headers["X-Line-Signature"];

                if (lineSignature == signature)
                {
                    return new StatusCodeResult(200);
                }
                else
                {
                    throw new InvalidSignatureException();
                }
            }
            catch (InvalidSignatureException e)
            {
                return new StatusCodeResult(403);
            }

            //            var hash = new HMACSHA256(channelSecret)

            //            var hash = hmac.new(channel_secret.encode('utf-8'),
            //    body.encode('utf-8'), hashlib.sha256).digest()
            //signature = base64.b64encode(hash)

            //IEnumerable<WebhookEvent> events;
            //try
            //{
            //    //Parse Webhook-Events
            //    var channelSecret = Environment.GetEnvironmentVariable("LineBotChannelSecret");
            //    if (channelSecret == null)
            //        channelSecret = "";
            //    events = await req.GetWebhookEventsAsync(channelSecret);
            //}
            //catch (InvalidSignatureException e)
            //{
            //    //Signature validation failed
            //    return new StatusCodeResult(403);
            //}

            //try
            //{
            //    //Process the webhook-events
            //    var channelToken = Environment.GetEnvironmentVariable("LineBotChannelToken");
            //    if (channelToken == null)
            //        channelToken = "";
            //    var client = new LineMessagingClient(channelToken);
            //    var app = new LineBotApp(client);
            //    await app.RunAsync(events);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //}

            return new StatusCodeResult(200);
        }
    }
}