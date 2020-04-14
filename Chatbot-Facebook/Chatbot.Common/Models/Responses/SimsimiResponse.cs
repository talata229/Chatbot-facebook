using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatbot.Common.Models.Requests;
using Newtonsoft.Json;

namespace Chatbot.Common.Models.Responses
{
    public class SimsimiResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("statusMessage")]
        public string StatusMessage { get; set; }

        [JsonProperty("request")]
        public SimsimiRequest Request { get; set; }

        [JsonProperty("atext")]
        public string Atext { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

}
