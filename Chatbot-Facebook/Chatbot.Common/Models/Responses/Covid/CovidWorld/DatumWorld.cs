using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chatbot.Common.Models.Responses.Covid.CovidWorld
{
    public class DatumWorld
    {
        //[JsonProperty("chart")]
        //public Chart Chart { get; set; }

        [JsonProperty("table_country")]
        public List<TableCountry> TableCountry { get; set; }

        //[JsonProperty("table_patient")]
        //public TablePatient TablePatient { get; set; }

        [JsonProperty("table_world")]
        public TableWorld TableWorld { get; set; }

        //[JsonProperty("topics")]
        //public string[] Topics { get; set; }
    }
}