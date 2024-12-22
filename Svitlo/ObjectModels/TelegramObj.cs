using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svitlo.ObjectModels
{
    public class TelegramObj
    {
        public long ?chatId {  get; set; }
        public TelegramObj()
        {
            chatId = null;
        }
        public TelegramObj(long chatId) {
            this.chatId = chatId;
        }
    }
}
