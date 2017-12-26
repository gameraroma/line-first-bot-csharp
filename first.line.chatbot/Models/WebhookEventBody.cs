using System.Collections.Generic;

namespace first.line.chatbot.Models
{
    public class WebhookEventBody
    {
        public List<WebhookEventWithToken> Events { get; set; }
    }
}
