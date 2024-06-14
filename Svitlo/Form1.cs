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
            if (idStreet == 0)
            {
                errorProvider1.SetError(readHouse, "Зповніть вуллицю");
                return;
            }
            await SearchHouse();
        }
        private async Task SearchHouse()
        {
            if (readHouse.Text.Length > 0)
            {
                HttpClient client = new HttpClient();
                using HttpResponseMessage reponse = await client.GetAsync(@$"https://www.voe.com.ua/disconnection/detailed/autocomplete/read_house/{idStreet}?q={readHouse.Text}");
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
        private void readHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            City city = (City)readHouse.SelectedItem;

            Regex regex = new Regex(@"[0-9]+");
            idHouse = Convert.ToInt32(regex.Match(city.label).Value);
        }
        private async Task check()
        {
            var values = new Dictionary<string, string>
            {
                { "ajax_form", "1" },
                { "_wrapper_format", "drupal_ajax" },
                { "city", "м. Вінниця (Вінницька Область/М.Вінниця)" },
                { "city_id", "510100000" },
                { "street", "вулиця В.Порика" },
                { "street_id", "1147" },
                { "house", "33" },
                { "house_id", "48440" },
                { "form_build_id", "form-EFDfea_so3Y5mQ-JvwI3zwkyv-5zihfkWDo38QPy3is" },
                { "form_id", "disconnection_detailed_search_form" },
                { "_triggering_element_name", "op" },
                { "_triggering_element_value", "Show" },
                { "_drupal_ajax", "1" },
                { "ajax_page_state[theme]", "personal" },
                { "ajax_page_state[theme_token]", "" },
                { "ajax_page_state[libraries]", "ajax_forms/main,classy/base,classy/messages,core/drupal.autocomplete,core/internal.jquery.form,core/normalize,custom/custom,drupal_noty_messages/drupal_noty_messages,extlink/drupal.extlink,filter/caption,paragraphs/drupal.paragraphs.unpublished,personal/global-styling,personal/sticky,personal/toggle_info,personal/type_navigation_unit,poll/drupal.poll-links,search_block/search_block.styles,styling_form_errors/styling_form_errors,system/base" }
            };

            var data = new FormUrlEncodedContent(values);
            HttpClient client= new HttpClient();
            using HttpResponseMessage reponse = await client.PostAsync($@"https://www.voe.com.ua/disconnection/detailed?ajax_form=1&_wrapper_format=drupal_ajax&_wrapper_format=drupal_ajax",data);
            reponse.EnsureSuccessStatusCode();
            var content = await reponse.Content.ReadAsStringAsync();
            richTextBox1.Text = content.ToString();

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //label1.Text = $"id={idCity};idstreet={idStreet}idhouse={idHouse}";
            await check();
        }
    }
}
