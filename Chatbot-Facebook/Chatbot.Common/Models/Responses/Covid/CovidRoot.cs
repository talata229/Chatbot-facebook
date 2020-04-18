using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Chatbot.Common.Models.Responses.Covid
{
    public class CovidRoot
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
