using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Line.Messaging;
using Line.Messaging.Webhooks;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.Net;

namespace first.line.chatbot.Controllers
{
    [Route("api")]
    public class ValuesController : Controller
    {
        // GET api/
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var dummy = Environment.GetEnvironmentVariable("DummyVar");

            var key = "The key";
            var value = "This is value!!!";

            var content = JsonConvert.SerializeObject(new { key, value }, new CamelCaseJsonSerializerSettings());
            var Content = new StringContent(content, Encoding.UTF8, "application/json");
            
            HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.OK);
            responseMsg.Content = new StringContent(content, Encoding.UTF8, "application/json");

            //return "dummy: สวัสดีจ้า " + dummy;
            return responseMsg;
        }

        internal class CamelCaseJsonSerializerSettings : JsonSerializerSettings
        {
            public CamelCaseJsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver();
                Converters.Add(new StringEnumConverter { CamelCaseText = true });
            }
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
