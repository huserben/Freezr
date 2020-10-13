using Freezr.Entities;

namespace Freezr.Messaging.Messages.Events
{
    public class FridgeAddedEvent : Message
    {
        public override string Subject => MessageSubject;

        public Fridge Fridge { get; set; }

        public static string MessageSubject = "events.fridge.added";
    }
}
