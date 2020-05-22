using System;
using System.Threading.Tasks;

namespace Chatbot.ConsoleUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Basic_Usage_Custom.Run().GetAwaiter().GetResult();
            Basic_Usage_Custom2.Run().GetAwaiter().GetResult();
            Console.ReadLine();
        }
    }
}
