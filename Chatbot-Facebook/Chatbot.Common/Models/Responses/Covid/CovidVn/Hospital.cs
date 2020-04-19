using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chatbot.Common.Models.Responses.Covid.CovidVn
{
    public class Hospital
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("data")]
        public List<HospitalDatum> Data { get; set; }
    }
}