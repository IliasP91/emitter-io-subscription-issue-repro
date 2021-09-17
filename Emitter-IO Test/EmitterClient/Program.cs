using Emitter;
using System;
using System.Text;

namespace EmitterClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client started");

            var channelKey = "XmWrMFJ3HobqVPE6mzlt1cu28241c56p";
            var channel = "test/";

            // Creating a connection to emitter.io service.
            var emitter = new Connection(channelKey, "127.0.0.1", 8080, false);

            // Connect to emitter.io service
            emitter.Connect("client1");

            emitter.Error += (object sender, Exception e) =>
            {
                Console.WriteLine("Error:" + e.Message);

            };

            emitter.Disconnected += (object sender, EventArgs e) =>
            {
                Console.WriteLine("Disconnected:" + e.ToString());
            };


            // Handle chat messages
            emitter.Subscribe(channelKey, channel, (channel, msg) =>
            {
                Console.WriteLine($"Message:: {channel} :: {Encoding.UTF8.GetString(msg)}");
            });

            Console.ReadLine();

            //emitter.Disconnect();
        }
    }
}
