using SvitloServerApi.Interface;
using Telegram.Bot;

namespace SvitloServerApi.Service
{
    public class TelegramBotService : ITelegramBotService
    {
        private readonly ITelegramBotClient _botClient;
        public TelegramBotService(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }
        public async Task SendMessage(long chatId, string text)
        {
            await _botClient.SendMessage(chatId, text);
        }
    }
}
