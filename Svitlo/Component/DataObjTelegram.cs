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
            if (!File.Exists("telegram.json"))
            {
                File.Create("telegram.json").Close();
            }
            using (StreamReader sr = new StreamReader("telegram.json"))
            {
                //MessageBox.Show(telegramObj.chatId.ToString());
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
            if (!File.Exists("telegram.json"))
            {
                File.Create("telegram.json").Close();
            }
            using (StreamWriter sw = new StreamWriter("telegram.json"))
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                };
                string data = JsonSerializer.Serialize(telegramObj, options);
                await sw.WriteAsync(data);  
            }
        }
        public void Remove()
        {
            telegramObj = null;
        }
        public void Insert(TelegramObj obj)
        {
            telegramObj = obj;
        }
        public TelegramObj GetTelegram()
        {
            return telegramObj;
        }
    }
}
