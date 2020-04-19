using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatbot.Common.Models.Responses.Covid.CovidVn;
using Newtonsoft.Json;

namespace Chatbot.Common.Models.Responses.Covid.CovidWorld
{
    public class CovidWorldRoot
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("data")]
        public DataWorld Data { get; set; }
    }
}
