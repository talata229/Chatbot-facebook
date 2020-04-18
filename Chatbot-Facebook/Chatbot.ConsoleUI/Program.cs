using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatbot.Common.Helper;

namespace Chatbot.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Basic_Usage_Custom.Run().GetAwaiter().GetResult();
            HtmlHelper.ConvertHtmlToImage("test");
        }
    }
}
