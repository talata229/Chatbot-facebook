using Newtonsoft.Json;

namespace Chatbot.Common.Models.Responses.Covid.CovidWorld
{
    public class TableWorld
    {
        [JsonProperty("deaths_1m_pop")]
        public string Deaths1MPop { get; set; }

        [JsonProperty("new_cases")]
        public string NewCases { get; set; }

        [JsonProperty("new_deaths")]
        public string NewDeaths { get; set; }

        [JsonProperty("new_recovered")]
        public string NewRecovered { get; set; }

        [JsonProperty("tot_cases_1m_pop")]
        public string TotCases1MPop { get; set; }

        [JsonProperty("total_cases")]
        public string TotalCases { get; set; }

        [JsonProperty("total_country")]
        public string TotalCountry { get; set; }

        [JsonProperty("total_deaths")]
        public string TotalDeaths { get; set; }

        [JsonProperty("total_recovered")]
        public string TotalRecovered { get; set; }
    }
}