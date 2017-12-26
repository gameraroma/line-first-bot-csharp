using Line.Messaging.Webhooks;

namespace first.line.chatbot.Models
{
    public class WebhookEventWithToken : WebhookEvent
    {
        public WebhookEventWithToken(WebhookEventType type, WebhookEventSource source, long timestamp) : base(type, source, timestamp)
        {
        }

        public string ReplyToken { get; set; }
    }
}
