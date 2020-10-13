namespace Freezr.Messaging
{
    public class Config
    {
        public static string MessageQueueUrl { get { return Core.Config.Get("MESSAGE_QUEUE_URL"); } }
    }
}