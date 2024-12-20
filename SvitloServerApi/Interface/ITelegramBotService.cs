namespace SvitloServerApi.Interface
{
    public interface ITelegramBotService
    {
        Task SendMessage(long chatId, string text);
    }
}
