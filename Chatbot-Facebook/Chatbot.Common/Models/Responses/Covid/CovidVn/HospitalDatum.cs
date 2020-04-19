﻿using Newtonsoft.Json;

namespace Chatbot.Common.Models.Responses.Covid.CovidVn
{
    public class HospitalDatum
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}