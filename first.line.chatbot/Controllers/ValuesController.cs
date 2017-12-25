using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Line.Messaging;
using Line.Messaging.Webhooks;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace first.line.chatbot.Controllers
{
    [Route("api")]
    public class ValuesController : Controller
    {
        // GET api/
        [HttpGet]
        public string Get()
        {
            //var dummy = ConfigurationManager.AppSettings["DummyVar"];
            var dummy = Environment.GetEnvironmentVariable("DummyVar")
            //return new string[] { "value1", "value2" };
            return "dummy: " + dummy;
        }

        // GET api/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value " + id;
        }

        // POST api/
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var lineBotApi = new LineMessagingClient("");
            
        }

       //[HttpPost]
       //public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
       //{
       //    //var events = await request.GetWebhookEventsAsync("");
       //    //var connectionString = ConfigurationManager<String>.AppSettings["StorageConnectionString"];
       //    //var blobStorage = await BlobStorage.CreateAsync(connectionString, "linebotcontainer");
       //    //var eventSourceState = await TableStorage<EventSourceState>.CreateAsync(connectionString, "eventsourcestate");
       //
       //    //var app = new LineBotApp(lineMessagingClient, eventSourceState, blobStorage);
       //    //await app.RunAsync(events);
       //
       //    var lineBotApi = new LineMessagingClient("");
       //
       //    foreach (WebhookEvent ev in events)
       //    {
       //        if (ev is MessageEvent && ev.Mess)
       //        lineBotApi.ReplyMessageAsync();
       //    }
       //
       //    //lineBotApi.ReplyMessageAsync(events)
       //
       //    return Request.CreateResponse(HttpStatusCode.OK);
       //}

        // PUT api/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
