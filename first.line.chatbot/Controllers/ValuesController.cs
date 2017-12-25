using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Line.Messaging;
using Line.Messaging.Webhooks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;

namespace first.line.chatbot.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
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


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
