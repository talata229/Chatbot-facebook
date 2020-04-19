using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Chatbot.Common.Enums;
using Chatbot.Common.Models.Responses;
using FireSharp.Interfaces;

namespace Chatbot.Common.Helper
{
    public class ChatHelper
    {
        public static async Task<EnumSpecialChatText> CheckSpecialChat(IFirebaseClient client, string message, string thread_id, string myselfId = "100001578994326")
        {
            if (message.Equals(EnumSpecialChatText.StopAll.GetEnumDescription(),
                StringComparison.InvariantCultureIgnoreCase))
            {
                await client.SetAsync("ListBlockUser/" + thread_id, new
                {
                    Id = thread_id,
                    BlockAll = true
                });
                return EnumSpecialChatText.StopAll;
            }

            if (message.Equals(EnumSpecialChatText.StopHour.GetEnumDescription(),
                StringComparison.InvariantCultureIgnoreCase))
            {
                await client.SetAsync("ListUser/" + thread_id, new
                {
                    BlockUntil = DateTime.UtcNow.AddHours(1)
                });
                return EnumSpecialChatText.StopHour;
            }

            if (message.Equals(EnumSpecialChatText.RemoveStopAll.GetEnumDescription(),
                StringComparison.InvariantCultureIgnoreCase))
            {
                await client.DeleteAsync("ListBlockUser/" + thread_id);
                return EnumSpecialChatText.RemoveStopAll;
            }

            if (thread_id == myselfId)
            {
                await client.SetAsync("ListBlockUser/" + myselfId, new MessageFirsebase
                {
                    Id = myselfId,
                    BlockAll = true
                });
                return EnumSpecialChatText.SameAccount;
            }
            if (message.Equals(EnumSpecialChatText.TroLyAo.GetEnumDescription(),
                StringComparison.InvariantCultureIgnoreCase))
            {
                await client.SetAsync("ListSimsimiUser/" + thread_id, new MessageFirsebase
                {
                    Id = thread_id
                });
                return EnumSpecialChatText.TroLyAo;
            }

            if (message.Equals(EnumSpecialChatText.CovidVN.GetEnumDescription(),
                StringComparison.InvariantCultureIgnoreCase))
            {
                return EnumSpecialChatText.CovidVN;
            }
            if (message.Equals(EnumSpecialChatText.CovidWorld.GetEnumDescription(),
                StringComparison.InvariantCultureIgnoreCase))
            {
                return EnumSpecialChatText.CovidWorld;
            }

            if (message.Equals(EnumSpecialChatText.Covid.GetEnumDescription(),
                StringComparison.InvariantCultureIgnoreCase))
            {
                return EnumSpecialChatText.Covid;
            }
            if (message.Equals(EnumSpecialChatText.GirlXinh.GetEnumDescription(),
                StringComparison.InvariantCultureIgnoreCase))
            {
                return EnumSpecialChatText.GirlXinh;
            }
            return EnumSpecialChatText.Unknown;
        }
    }
}
