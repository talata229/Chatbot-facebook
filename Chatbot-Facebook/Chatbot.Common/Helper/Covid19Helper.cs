using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Chatbot.Common.Models.Responses.Covid;
using Newtonsoft.Json;

namespace Chatbot.Common.Helper
{
    public class Covid19Helper
    {
        public static async Task<string> GetDetailVN()
        {
            var http = new HttpClient();
            string urlGetCovid = "https://gw.vnexpress.net/cr/?name=tracker_coronavirus";
            var response = await http.GetAsync(urlGetCovid);
            var result = await response.Content.ReadAsStringAsync();
            CovidRoot covidRoot = JsonConvert.DeserializeObject<CovidRoot>(result);
            var listCity = covidRoot.Data.DataData[0].TrackerByProvince;
            string source = String.Empty;
            foreach (var city in listCity)
            {
                source += $"<tr><td>{city.Name}</td><td>{city.Cases}</td><td>{city.Deaths}</td><td>{city.Recovered}</td></tr>";
            }
            string html = @"  
                <!DOCTYPE html>  
                    <html>  
                        <head>  
                            <style>  
                                table {  
                                  font-family: arial, sans-serif;  
                                  border-collapse: collapse;  
                                
                                }  
                                  
                                td, th {  
                                  border: 1px solid #dddddd;  
                                  text-align: left;  
                                  padding: 8px;  
                                }  
                                  
                                tr:nth-child(even) {  
                                  background-color: #dddddd;  
                                }  
                          </style>  
                         </head>  
                    <body>  
                      
                        <h2>Thống kê dịch Covid-19 Việt Nam</h2>  
                        <h3>Cập nhật</h3>  
                        <table>  
                          <tr>  
                            <th>Tỉnh/Thành phố</th>  
                            <th>Số ca nhiễm</th>  
                            <th>Tử vong</th>  
                            <th>Bình phục</th>  
                          </tr>  " + source + @"
                        </table>  
                     </body>  
                    </html> ";
            return html;
        }
    }
}
