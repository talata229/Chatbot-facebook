using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chatbot.Common.Models.Responses.Covid.CovidWorld
{
    public class DataWorld
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("data")]
        public List<DatumWorld> DataData { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}