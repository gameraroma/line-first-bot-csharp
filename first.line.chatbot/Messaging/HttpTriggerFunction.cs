using Line.Messaging;
using System;
using System.Threading.Tasks;

namespace first.line.chatbot.Messaging
{
    public class HttpTriggerFunction
    {
        private LineMessagingClient _messagingClient;

        public HttpTriggerFunction()
        {
            _messagingClient = new LineMessagingClient(Environment.GetEnvironmentVariable("LineBotChannelToken"));
        }

        //public static async Task<HttpResponseMessage> Run(HttpRequestMessage req)
        //{
        //    IEnumerable<WebhookEvent> events;
        //    try
        //    {
        //        //Parse Webhook-Events
        //        var channelSecret = System.Configuration.ConfigurationManager.AppSettings["ChannelSecret"];
        //        events = await req.GetWebhookEventsAsync(channelSecret);
        //    }
        //    catch (InvalidSignatureException e)
        //    {
        //        //Signature validation failed
        //        return req.CreateResponse(HttpStatusCode.Forbidden, new { Message = e.Message });
        //    }

        //    try
        //    {
        //        var connectionString = System.Configuration.ConfigurationManager.AppSettings["AzureWebJobsStorage"];
        //        var tableStorage = await LineBotTableStorage.CreateAsync(connectionString);
        //        var blobStorage = await BlobStorage.CreateAsync(connectionString, "linebotcontainer");
        //        //Process the webhook-events
        //        var app = new LineBotApp(lineMessagingClient, tableStorage, blobStorage, log);
        //        await app.RunAsync(events);
        //    }
        //    catch (Exception e)
        //    {
        //        log.Error(e.ToString());
        //    }

        //    return req.CreateResponse(HttpStatusCode.OK);
        //}
    }
}
