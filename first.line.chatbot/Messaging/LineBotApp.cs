using Line.Messaging;
using Line.Messaging.Webhooks;
using System;
using System.Threading.Tasks;

namespace first.line.chatbot.Messaging
{
    class LineBotApp : WebhookApplication
    {
        private LineMessagingClient MessagingClient { get; }

        public LineBotApp(LineMessagingClient lineMessagingClient)
        {
            MessagingClient = lineMessagingClient;
        }

        protected override async Task OnMessageAsync(MessageEvent ev)
        {
            switch (ev.Message.Type)
            {
                case EventMessageType.Text:
                    //await MessagingClient.ReplyMessageAsync(ev.ReplyToken, ((TextEventMessage)ev.Message).Text);
                    await MessagingClient.ReplyMessageAsync(ev.ReplyToken, "สวัสดีจร้า...", ((TextEventMessage)ev.Message).Text);
                    break;

                case EventMessageType.Image:
                case EventMessageType.Audio:
                case EventMessageType.Video:
                case EventMessageType.File:
                case EventMessageType.Location:
                case EventMessageType.Sticker:
                    break;

            }
        }

        protected override async Task OnFollowAsync(FollowEvent ev)
        {
            throw new NotImplementedException();
        }

        protected override async Task OnUnfollowAsync(UnfollowEvent ev)
        {
            throw new NotImplementedException();
        }

        protected override async Task OnJoinAsync(JoinEvent ev)
        {
            throw new NotImplementedException();
        }

        protected override async Task OnLeaveAsync(LeaveEvent ev)
        {
            throw new NotImplementedException();
        }

        protected override Task OnBeaconAsync(BeaconEvent ev)
        {
            throw new NotImplementedException();
        }

        protected override async Task OnPostbackAsync(PostbackEvent ev)
        {
            throw new NotImplementedException();
        }

    }
}
