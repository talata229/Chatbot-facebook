using Chatbot.Common.Models.Requests;
using Chatbot.Common.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Common.Helper
{
    public class SimsimiHelper
    {
        public static List<string> listAPIKey = new List<string>
        {
            //"YnaQrO3/OY8eN3rlYZQejKv8sPsFaa8OC9q5i3nb",
            //"6Z71R8yzBuhCui8X4W8tABqW+GlrfObJA4enwVs+",
            //"YZh8vKVwsL4L0bB/STI46UDY/QOBeYPLoI1aPWJa",
            "FP4-_bvambFCy1IJy4PXEWm~iceuVjBU-.VcfkCI", //muathudep105
            "Ol_zRLJ2Cpiva0QB30UkvZZmaAcpHNyKggxGnRQV", //muathudep106
            "mQg6ZZqqwpfMY7sZ2XZRqqI-MIMD-eihD_98W-6r" //muathudep107
        };

        public static string RandomAPIKey(List<string> list)
        {
            Random rd = new Random();
            return list[rd.Next(list.Count)];
        }

        public static async Task<string> SendSimsimi(string question)
        {
            int countTried = 0;
            try
            {
                do
                {
                    var http = new HttpClient();
                    http.DefaultRequestHeaders.Clear();
                    http.DefaultRequestHeaders.Add("x-api-key", RandomAPIKey(listAPIKey));
                    string url = "https://wsapi.simsimi.com/190410/talk";
                    SimsimiRequest request = new SimsimiRequest
                    {
                        Utext = question,
                        Lang = "vn"
                    };
                    string json = JsonConvert.SerializeObject(request);
                    HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await http.PostAsync(url, httpContent);
                    var result = await response.Content.ReadAsStringAsync();
                    SimsimiResponse simsimi = JsonConvert.DeserializeObject<SimsimiResponse>(result);
                    if (simsimi.Status == 200)
                    {
                        return simsimi.Atext;
                    }
                    else
                    {
                        countTried++;
                    }
                } while (countTried > 3);

            }
            catch (Exception e)
            {
            }
            return "";
        }
    }

}
