using Newtonsoft.Json;

namespace Chatbot.Common.Models.Responses.Covid.CovidVn
{
    public class CovidVnRoot
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
