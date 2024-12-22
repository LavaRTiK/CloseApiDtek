using Svitlo.Component;
using Svitlo.ObjectModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Svitlo.Forms
{
    public partial class ConnectToTelegram : Form
    {
        TelegramAPI telegramAPI = new TelegramAPI();
        DataObjTelegram dataObjTelegram = new DataObjTelegram();
        public ConnectToTelegram()
        {
            InitializeComponent();
        }

        private void ConnectToTelegram_Load(object sender, EventArgs e)
        {
            buttonConnect.Enabled = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (long.TryParse(textBox1.Text,out long chatId))
            {
                telegramAPI.SendMessage(chatId, $"Додаток Svitlo на пк {Environment.UserName}");
            }
            DialogResult result = MessageBox.Show("Ви отримали повідомлення?", "Перевірка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dataObjTelegram.Insert(new TelegramObj(chatId));
                await dataObjTelegram.LoadDataAsync();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Cталася помилка спробуйте пізніше");
                DialogResult = DialogResult.Cancel;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                buttonConnect.Enabled = false;
            }
            else
            {
                buttonConnect.Enabled = true;
            }
        }
    }
}
