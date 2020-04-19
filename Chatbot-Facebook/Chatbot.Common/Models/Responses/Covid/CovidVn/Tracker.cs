using Newtonsoft.Json;

namespace Chatbot.Common.Models.Responses.Covid.CovidVn
{
    public class Tracker
    {
        [JsonProperty("cases")]
        public long Cases { get; set; }

        [JsonProperty("day", NullValueHandling = NullValueHandling.Ignore)]
        public string Day { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("recovered")]
        public long Recovered { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}