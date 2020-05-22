using Chatbot.Client;
using Chatbot.Client.API;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chatbot.ConsoleUI
{
    public class Basic_Usage_Custom2
    {
        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);

        public static async Task Run()
        {
            // Instantiate FBClient
            MessengerClient client = new FBClientCustom();

            try
            {
                // Try logging in from saved session
                await client.TryLogin();
            }
            catch
            {
                // Read email and pw from console
                Console.WriteLine("Insert Facebook email:");
                var email = Console.ReadLine();
                Console.WriteLine("Insert Facebook password:");
                var password = Console.ReadLine();

                // Login with username and password
                await client.DoLogin(email, password);
            }

            List<string> listUserReceived = new List<string>
            {
                "100001578994326"
            };
            List<string> listMessage = new List<string>
            {
                "Chào",
                "Dạo này khỏe không?"
            };
            for (int i = 0; i < listUserReceived.Count; i++)
            {
                Random rd = new Random();
                string s = await client.send(new FB_Message(listMessage[rd.Next(listMessage.Count)]), listUserReceived[i], ThreadType.USER);
                Console.WriteLine($"Send to: {listUserReceived[i]} \tContent = {listMessage[rd.Next(listMessage.Count)]}");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Done!!!!");
        }
    }
}
