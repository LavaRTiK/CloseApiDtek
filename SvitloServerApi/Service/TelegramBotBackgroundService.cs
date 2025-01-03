﻿using System.Diagnostics.Tracing;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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
                if(message.Text == "/start")
                {
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithUrl("GitHub","https://github.com/LavaRTiK/CloseApiDtek"),
                            InlineKeyboardButton.WithCallbackData("Sivitlo Connect","connect-app-svitlo"),
                        }
                    });
                    await botClient.SendMessage(
                        chatId:message.Chat.Id,
                        text:"Цей бот працює із кліентом Svitlo",
                        replyMarkup: inlineKeyboard,
                        cancellationToken:cancellationToken
                        
                    ); 
                }
            }
            if (update.CallbackQuery is { } callbackQuery)
            {
                if (callbackQuery.Data == "connect-app-svitlo")
                {
                    await botClient.AnswerCallbackQuery(
                        callbackQuery.Id,
                        "Ви натиснули кнопку Sivitlo Connect!",
                        cancellationToken: cancellationToken
                    );
                    await botClient.SendMessage(
                        chatId: callbackQuery.Message.Chat.Id,
                        text: $"Уведіть у додаток код:{callbackQuery.Message.Chat.Id}",
                        cancellationToken: cancellationToken
                    );
                }
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
