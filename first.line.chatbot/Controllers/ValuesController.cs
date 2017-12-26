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
            var dummy = Environment.GetEnvironmentVariable("DummyVar");
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
