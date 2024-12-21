using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svitlo.Component
{
    internal class TelegramAPI
    {
        public async Task SendMessage(long id,string message)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                using HttpResponseMessage responsse = await httpClient.PostAsync($"https://localhost:7231/api/FromToTelegram?chatId={id}&message={message}", null);
                responsse.EnsureSuccessStatusCode();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
