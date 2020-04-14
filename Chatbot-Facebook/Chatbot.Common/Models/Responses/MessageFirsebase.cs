using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Common.Models.Responses
{
    public class MessageFirsebase
    {
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime? TimeReceived { get; set; }

        public DateTime? BlockUntil { get; set; }
        public bool? BlockAll { get; set; }
    }
}
