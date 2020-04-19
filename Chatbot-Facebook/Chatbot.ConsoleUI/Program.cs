using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chatbot.Common.Helper;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Chatbot.ConsoleUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Basic_Usage_Custom.Run().GetAwaiter().GetResult();
            //HtmlHelper.ConvertHtmlToImage("test");
            //HtmlHelper.ConvertHtmlToImageVersion2();
            //Console.ReadLine();
            //await FunctionTest();
           // DownloadHelper.DownloadImageFromUrl("quang");
            Console.WriteLine("done");
        }
    }
}
