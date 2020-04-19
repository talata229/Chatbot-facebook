using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Chatbot.Common.Models.Responses.Covid;
using Chatbot.Common.Models.Responses.Covid.CovidVn;
using Chatbot.Common.Models.Responses.Covid.CovidWorld;
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
            CovidVnRoot covidRoot = JsonConvert.DeserializeObject<CovidVnRoot>(result);
            var listCity = covidRoot.Data.DataData[0].TrackerByProvince;
            string source = String.Empty;
            foreach (var city in listCity)
            {
                source += $"<tr><td class=\"city\">{city.Name}</td><td class=\"cases\">{city.Cases}</td><td class=\"deaths\">{city.Deaths}</td><td class=\"recovered\">{city.Recovered}</td></tr>";
            }
            string html = @"  
                <!DOCTYPE html>  
                    <html>  
                        <head>  
                            <style>
                                h2,h3 {
                                    text-align:center;
                                }

                                table {  
                                  font-family: arial, sans-serif;  
                                  border-collapse: collapse;  
                                
                                }  
                                  .city { color:black}
                                  .cases { color:red}
                                  .deaths { color:black}
                                  .recovered { color:#2b880f}

                                td, th {  
                                  border: 1px solid #dddddd;  
                                  text-align: center;  
                                  padding: 8px;  
                                }  
                                  
                                tr:nth-child(even) {  
                                  background-color: #dddddd;  
                                }  
                          </style>  
                         </head>  
                    <body>  
                        <h2>Thống kê dịch Covid-19 tại Việt Nam</h2>  
                        <h3>Cập nhật lúc " + DateTime.Now.ToString("dd/MM/yyy hh:mm:ss", CultureInfo.InvariantCulture) + @" theo giờ VN</h3>  
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
        public static async Task<string> GetDetailWorld()
        {
            var html = String.Empty;
            try
            {
                var http = new HttpClient();
                string urlGetCovidWorld = "https://gw.vnexpress.net/cr/?name=world_coronavirus";
                var response = await http.GetAsync(urlGetCovidWorld);
                var result = await response.Content.ReadAsStringAsync();
                CovidWorldRoot covidWorldRoot = JsonConvert.DeserializeObject<CovidWorldRoot>(result);

                var sumary = covidWorldRoot.Data.DataData[0].TableWorld;
                var listCity = covidWorldRoot.Data.DataData[0].TableCountry;
                int numberOfTake = 15;
                var table1 = listCity.Take(numberOfTake);
                var table2 = listCity.Skip(numberOfTake).Take(numberOfTake);
                var table3 = listCity.Skip(numberOfTake * 2);

                string source1 = String.Empty;
                foreach (var city in table1)
                {
                    source1 += $"<tr><td class='nation'>{city.CountryVn}</td>  <td class='infected'>{city.TotalCases}</td>     <td class='newcase'>{city.NewCases}</td>    <td class='dead'>{city.TotalDeaths}</td><td class='recovered'>{city.TotalRecovered}</td></tr>";
                }

                string source2 = String.Empty;
                foreach (var city in table2)
                {
                    source2 += $"<tr><td class='nation'>{city.CountryVn}</td>  <td class='infected'>{city.TotalCases}</td>     <td class='newcase'>{city.NewCases}</td>    <td class='dead'>{city.TotalDeaths}</td><td class='recovered'>{city.TotalRecovered}</td></tr>";
                }

                string source3 = String.Empty;
                foreach (var city in table3)
                {
                    source3 += $"<tr><td class='nation'>{city.CountryVn}</td>  <td class='infected'>{city.TotalCases}</td>     <td class='newcase'>{city.NewCases}</td>    <td class='dead'>{city.TotalDeaths}</td><td class='recovered'>{city.TotalRecovered}</td></tr>";
                }

                html = @"
<!DOCTYPE html>
<html>

<head>
    <style>
        h2,
        h3,p {
            text-align: center;
        }

        .item {
            width: 33.33%;
        }

        .covid {
            display: flex;
        }

        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;

        }

        .city {
            color: black
        }

        .cases {
            color: red
        }

        .deaths {
            color: black
        }

        .recovered {
            color: #2b880f
        }

        td,
        th {
            border: 1px solid #dddddd;
            text-align: ce;
            padding: 8px;
        }

        tr:nth-child(even) {
            background-color: #dddddd;
        }

        .world-corona-detail__statistical1 {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            position: relative;
            z-index: 2;
            background: #fcede8;
            padding: 10px;
            margin-bottom: 15px;
        }

        .world-corona-detail__statistical1 .item2 {
            display: inline-block;
            text-align: center;
            margin: 0 10px;
        }

        .infected {
            color: red;
        }

        .newcase {
            color: blueviolet
        }

        .recovered {
            color: #2b880f;
        }

        td {
            text-align: center;
        }
    </style>
</head>

<body>
    <h2>Thống kê dịch Covid-19 trên thế giới</h2>
    <h3>Cập nhật lúc " + DateTime.Now.ToString("dd/MM/yyy hh:mm:ss", CultureInfo.InvariantCulture) + @" theo giờ VN</h3>
<p>Nhiễm bệnh: " + sumary.TotalCases + @"</p>
<p>Tử vong: " + sumary.TotalDeaths + @"</p>
<p>Bình phục: " + sumary.TotalRecovered + @"</p>
    <table class='table'>
                <tbody>
                    <tr>
                        <td class='nation'>&nbsp;</td>
                        <td class='infected'>Nhiễm bệnh</td>
                        <td class='newcase'>Số ca nhiễm mới</td>
                        <td class='dead'>Tử vong</td>
                        <td class='recovered'>Bình phục</td>
                    </tr>
                   " + source1 + @"
                 </tbody>
            </table>


</body>

</html>";
            }
            catch (Exception e)
            {
                var test = true;
            }

            return html;
        }
    }
}
