using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svitlo.Component
{
    internal class TelegramAPI
    {
        private readonly static string TelegramUrl = "https://closeapidtek-production.up.railway.app/api/FromToTelegram";
        public async Task SendMessage(long ?id,string message)
        {
            if(id == null)
            {
                return;
            }
            HttpClient httpClient = new HttpClient();
            try
            {
                using HttpResponseMessage responsse = await httpClient.PostAsync($"{TelegramUrl}?chatId={id}&message={message}", null);
                responsse.EnsureSuccessStatusCode();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
