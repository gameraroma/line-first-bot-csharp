using Line.Messaging.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first.line.chatbot.Models
{
    public class EventRequestBody : WebhookEvent
    {
        public EventRequestBody(WebhookEventType type, WebhookEventSource source, long timestamp) : base(type, source, timestamp)
        {

        }

        public string ReplyToken { get; set; }
    }
}
