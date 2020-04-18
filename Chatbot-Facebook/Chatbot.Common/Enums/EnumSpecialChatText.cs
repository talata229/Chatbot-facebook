using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Common.Enums
{
    public enum EnumSpecialChatText
    {
        [Description("stopall")]
        StopAll,
        [Description("stophour")]
        StopHour,
        [Description("removestopall")]
        RemoveStopAll,
        [Description("sameaccount")]
        SameAccount,
        [Description("trolyao")]
        TroLyAo,
        [Description("covidvn")]
        CovidVN,
        [Description("unknown")]
        Unknown
    }
}
