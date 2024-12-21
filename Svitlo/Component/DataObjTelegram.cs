using Svitlo.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Svitlo.Component
{
    public class DataObjTelegram
    {
        private static TelegramObj telegramObj = new TelegramObj();
        public async Task ReadDataAsync()
        {
            if (!File.Exists("telegram.txt"))
            {
                File.Create("telegram.txt").Close();
            }
            using (StreamReader sr = new StreamReader("telegram.txt"))
            {
                string data = await sr.ReadToEndAsync();
                if (!string.IsNullOrWhiteSpace(data))
                {
                    try
                    {
                        telegramObj = JsonSerializer.Deserialize<TelegramObj>(data);
                    }
                    catch (Exception ex)
                    {
                        telegramObj = new TelegramObj();
                    }
                }
                else
                {
                    telegramObj = new TelegramObj();
                }
            }
        }
        public async Task LoadDataAsync()
        {
            if (!File.Exists("telegram.txt"))
            {
                File.Create("telegram.txt").Close();
            }
            using (StreamWriter sw = new StreamWriter("telegram.txt"))
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                };
                string data = JsonSerializer.Serialize(telegramObj, options);
                await sw.WriteAsync(data);  
            }
        }
    }
}
