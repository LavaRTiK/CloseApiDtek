using System.Diagnostics.Tracing;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;

namespace SvitloServerApi.Service
{
    public class TelegramBotBackgroundService : BackgroundService
    {
        private readonly ITelegramBotClient _botClient;
        public TelegramBotBackgroundService(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                errorHandler: HandleErrorAsync,
                cancellationToken: stoppingToken
            );
            Console.WriteLine("Бот запущений");
            await Task.Delay(-1, stoppingToken);
        }
        private async Task HandleUpdateAsync(ITelegramBotClient botClient,Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            if(update.Message is { } message && message.Text is { })
            {
                Console.WriteLine($"Користувач написав {message.Text}");

                await botClient.SendMessage(
                    chatId: message.Chat.Id,
                    text: $"Привіт! Ви написали:{message.Text} ваш id : {message.Chat.Id}",
                    cancellationToken: cancellationToken
                );
            }
        }
        private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,CancellationToken cancellationToken)
        {
            if(exception is ApiRequestException apiException)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine("Erorr");
            }
            return Task.CompletedTask;
        }
    }
}
