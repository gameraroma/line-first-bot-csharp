using Line.Messaging.Webhooks;
using System.Collections.Generic;

namespace first.line.chatbot.Models
{
    public class WebhookEventBody
    {
        public List<MessageEvent> Events { get; set; }
    }
}
