using Newtonsoft.Json;

namespace Chatbot.Common.Models.Responses.Covid.CovidWorld
{
    public class TableCountry
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_vn")]
        public string CountryVn { get; set; }

        [JsonProperty("new_cases")]
        public string NewCases { get; set; }

        [JsonProperty("new_deaths")]
        public string NewDeaths { get; set; }

        [JsonProperty("total_cases")]
        public string TotalCases { get; set; }

        [JsonProperty("total_deaths")]
        public string TotalDeaths { get; set; }

        [JsonProperty("total_recovered")]
        public string TotalRecovered { get; set; }
    }
}