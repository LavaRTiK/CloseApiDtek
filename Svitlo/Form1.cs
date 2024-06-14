using System.Net.Http.Json;
using System.Text.RegularExpressions;

namespace Svitlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int idCity = 0;
        private int idStreet = 0;
        private int idHouse = 0;
        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            using HttpResponseMessage reponse = await client.GetAsync(@$"https://www.voe.com.ua/disconnection/detailed/autocomplete/read_city?q=Він");
            reponse.EnsureSuccessStatusCode();
            var content = await reponse.Content.ReadFromJsonAsync<List<City>>();
            //richTextBox1.Text = content;
            foreach (var item in content)
            {
                richTextBox1.Text += $"\n {item.value} + {item.label}";
            }
        }

        private async void comboBox1_TextChanged(object sender, EventArgs e)
        {
            await SearchCity();
        }
        private async Task SearchCity()
        {
            if (readCity.Text.Length > 3)
            {
                HttpClient client = new HttpClient();
                using HttpResponseMessage reponse = await client.GetAsync(@$"https://www.voe.com.ua/disconnection/detailed/autocomplete/read_city?q={readCity.Text}");
                reponse.EnsureSuccessStatusCode();
                var content = await reponse.Content.ReadFromJsonAsync<List<City>>();
                if (content != null)
                {
                    readCity.Items.Clear();
                    foreach (var item in content)
                    {
                        readCity.Items.Add(item);
                    }
                    errorReadCity.SetError(this.readCity, String.Empty);
                }
            }
            else
            {
                errorReadCity.SetError(this.readCity, "Довжина повина бути більше 3");
            }
        }

        private void readCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            City city = (City)readCity.SelectedItem;

            Regex regex = new Regex(@"[0-9]+");
            idCity = Convert.ToInt32(regex.Match(city.label).Value);
        }

        private async void readStreet_TextChanged(object sender, EventArgs e)
        {
            if (idCity == 0)
            {
                errorReadStreet.SetError(readStreet, "Зповніть місто");
                return;
            }
            await SearchStreet();

        }
        private async Task SearchStreet()
        {
            if (readStreet.Text.Length > 3)
            {
                HttpClient client = new HttpClient();
                using HttpResponseMessage reponse = await client.GetAsync(@$"https://www.voe.com.ua/disconnection/detailed/autocomplete/read_street/{idCity}?q={readStreet.Text}");
                reponse.EnsureSuccessStatusCode();
                var content = await reponse.Content.ReadFromJsonAsync<List<City>>();
                if (content != null)
                {
                    readStreet.Items.Clear();
                    foreach (var item in content)
                    {
                        readStreet.Items.Add(item);
                    }
                    errorReadStreet.SetError(this.readStreet, String.Empty);
                }
            }
            else
            {
                errorReadStreet.SetError(this.readStreet, "Довжина повина бути більше 3");
            }
        }

        private void readStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            City city = (City)readStreet.SelectedItem;

            Regex regex = new Regex(@"[0-9]+");
            idStreet = Convert.ToInt32(regex.Match(city.label).Value);
        }

        private async void readHouse_TextChanged(object sender, EventArgs e)
        {
            if (idHouse == 0)
            {
                errorProvider1.SetError(readHouse, "Зповніть вуллицю");
                return;
            }
            await SearchCity();
        }
        private async Task SearchHouse()
        {
            if (readHouse.Text.Length > 3)
            {
                HttpClient client = new HttpClient();
                using HttpResponseMessage reponse = await client.GetAsync(@$"https://www.voe.com.ua/disconnection/detailed/autocomplete/read_house/{idStreet}?q={readHouse}");
                reponse.EnsureSuccessStatusCode();
                var content = await reponse.Content.ReadFromJsonAsync<List<City>>();
                if (content != null)
                {
                    readHouse.Items.Clear();
                    foreach (var item in content)
                    {
                        readHouse.Items.Add(item);
                    }
                    errorProvider1.SetError(this.readHouse, String.Empty);
                }
            }
            else
            {
                errorProvider1.SetError(this.readHouse, "Довжина повина бути більше 3");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = $"id={idCity};idstreet={idStreet}idhouse={idHouse}";
        }
    }
}
