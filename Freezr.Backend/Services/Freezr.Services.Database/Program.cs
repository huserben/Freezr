using Freezr.Messaging;
using Freezr.Messaging.Messages.Events;
using Freezr.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Freezr.Services.Database
{
    public class Program
    {
        private static ManualResetEvent _ResetEvent = new ManualResetEvent(false);
        private static DbContextOptionsBuilder<FreezrContext> dbOptions;
        private const string QueueGroup = "database-service";

        static void Main(string[] args)
        {
            dbOptions = new DbContextOptionsBuilder<FreezrContext>();
            dbOptions.UseNpgsql(Core.Config.Get("PostgresDocker"));

            using (var connection = MessageQueue.CreateConnection())
            {
                var subscription = connection.SubscribeAsync(FridgeAddedEvent.MessageSubject, QueueGroup);
                subscription.MessageHandler += OnFridgeAdded;
                subscription.Start();

                _ResetEvent.WaitOne();
                connection.Close();
            }
        }

        private static void OnFridgeAdded(object sender, NATS.Client.MsgHandlerEventArgs evt)
        {
            var eventMessage = MessageHelper.FromData<FridgeAddedEvent>(evt.Message.Data);
            var fridge = eventMessage.Fridge;

            using (var context = new FreezrContext(dbOptions.Options))
            {
                context.Fridges.Add(fridge);
                context.SaveChanges();
            }
        }
    }
}
