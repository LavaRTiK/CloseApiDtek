using Telegram.Bot.Types;

namespace SvitloServerApi.Object
{
    public class TelegramSendMessangeDTO
    {
        public long chatId {  get; set; }
        public string message {  get; set; }
    }
}
