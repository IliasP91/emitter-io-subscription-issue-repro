using Emitter;
using Emitter.Messages;
using System;

namespace EmitterBroadcaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Broadcaster started");

            var channelKey = "XmWrMFJ3HobqVPE6mzlt1cu28241c56p";
            var channel = "test/";

            // Creating a connection to emitter.io service.
            var emitter = new Connection(channelKey, "127.0.0.1", 8080, false);

            // Connect to emitter.io service
            emitter.Connect();

            emitter.Error += (object sender, Exception e) =>
            {
                Console.WriteLine("Error:" + e.Message);
            };

            emitter.Disconnected += (object sender, EventArgs e) =>
            {
                Console.WriteLine("Disconnected:" + e.ToString());
            };

            // Handle events

            emitter.PresenceSubscribe(channelKey, channel, true, (PresenceEvent e) =>
           {
               Console.WriteLine("Presence event " + e.Event + ".");
               Console.WriteLine("NO clients connected: " + e.Who.Count + ".");

               Console.WriteLine("clients start::");

               foreach (var presenceInfo in e.Who)
               {
                   Console.WriteLine($"id: {presenceInfo.Id} username: {presenceInfo.Username}");
               }

               Console.WriteLine("clients end::");
           });

            // Publish messages to the channel
            string text = "";
            Console.WriteLine("Type to chat or 'q' to exit...");
            do
            {
                text = Console.ReadLine();
                emitter.Publish(channelKey, channel, text);

                emitter.PresenceStatus(channelKey, channel, (e) => {/*no op*/});
            }
            while (text != "q");

            emitter.Disconnect();
        }
    }
}
