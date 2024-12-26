using SvitloServerApi.Interface;
using SvitloServerApi.Service;
using System.Text;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var botToken = builder.Configuration["TelegramBot:Token"];
if (string.IsNullOrWhiteSpace(botToken))
{
    botToken = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN");
    if (string.IsNullOrWhiteSpace(botToken))
    {
        throw new InvalidOperationException("Miss telegram bot token");
    }
}
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(botToken));
builder.Services.AddHostedService<TelegramBotBackgroundService>();
builder.Services.AddSingleton<ITelegramBotService, TelegramBotService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Console.OutputEncoding = Encoding.UTF8;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
