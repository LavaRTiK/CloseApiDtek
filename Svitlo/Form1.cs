using System.Net.Http.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Svitlo.Component;
using Svitlo.ObjectModels;

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
        private string? city { get; set; }
        private string? street { get; set; }
        private string? house { get; set; }
        private DataLoderAPI dataLoderAPI = new DataLoderAPI();
        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            using HttpResponseMessage reponse = await client.GetAsync(@$"https://www.voe.com.ua/disconnection/detailed/autocomplete/read_city?q=Â³í");
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
            if(readCity.Text.Length > 3)
            {
                errorReadCity.SetError(this.readCity, "Виконується запит");
                var content = await dataLoderAPI.SearchCityAsync(readCity.Text);
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
                errorReadCity.SetError(this.readCity, "Длина тексту больше 3");
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
                errorReadStreet.SetError(readStreet, "Заповніть спочатку місто");
                return;
            }
            await SearchStreet();

        }
        private async Task SearchStreet()
        {
            if (readStreet.Text.Length > 3)
            {
                errorReadStreet.SetError(this.readStreet, "Виконується запит");
                var content = await dataLoderAPI.SearchStreetAsync(idCity,readStreet.Text);
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
                errorReadStreet.SetError(this.readStreet, "Длина тексту больше 3");
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
                errorReadHouse.SetError(readHouse, "Заповніть спочатку вулицю");
                return;
            }
            await SearchHouse();
        }
        private async Task SearchHouse()
        {
            if (readStreet.Text.Length > 3)
            {
                errorReadHouse.SetError(this.readHouse, "Виконується запит");
                var content = await dataLoderAPI.SearchHouseAsync(idStreet, readHouse.Text);
                if (content != null)
                {
                    readHouse.Items.Clear();
                    foreach (var item in content)
                    {
                        readHouse.Items.Add(item);
                    }
                    errorReadHouse.SetError(this.readHouse, String.Empty);
                }
            }
            else
            {
                errorReadHouse.SetError(this.readHouse, "Длина тексту больше 3");
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
                { "city", $"{readCity.Text}" },
                { "city_id", $"{idCity}" },
                { "street", $"{readStreet.Text}" },
                { "street_id", $"{idStreet}" },
                { "house", $"{readHouse.Text}" },
                { "house_id", $"{idHouse}" },
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
            HttpClient client = new HttpClient();
            using HttpResponseMessage reponse = await client.PostAsync($@"https://www.voe.com.ua/disconnection/detailed?ajax_form=1&_wrapper_format=drupal_ajax&_wrapper_format=drupal_ajax", data);
            reponse.EnsureSuccessStatusCode();
            var content = await reponse.Content.ReadFromJsonAsync<List<Test>>();
            richTextBox1.Text = content.ToString();
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(content[2].data.ToString());

            var messageNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='disconnection-detailed-table-message']");
            if (messageNode != null)
            {
                richTextBox2.Text += ("\nMessage about disconnections:");
                richTextBox2.Text += $"\n{(messageNode.InnerText.Trim())}";
                //Console.WriteLine();
            }

            var tableNode = htmlDocument.DocumentNode.SelectNodes("//div[@class='disconnection-detailed-table-cell cell  no_disconnection current_day' or @class='disconnection-detailed-table-cell cell  has_disconnection confirm_1 current_day' or @class='disconnection-detailed-table-cell cell  has_disconnection confirm_0 current_day']");
            if (tableNode == null)
            {
                richTextBox2.Text += "\nTable node not found.";
                return;
            }
            else
            {
                richTextBox2.Text += "\nTable node found.";
            }
            TimeOnly time = new TimeOnly(00, 00);
            for (int i = 0; i < tableNode.Count; i++)
            {
                if (tableNode[i].Attributes[0].Value == "disconnection-detailed-table-cell cell  no_disconnection current_day")
                {
                    dataGridView1.Rows.Add(time.ToString("HH:mm"), "-");
                }
                else if (tableNode[i].Attributes[0].Value == "disconnection-detailed-table-cell cell  has_disconnection confirm_1 current_day")
                {
                    dataGridView1.Rows.Add(time.ToString("HH:mm"), "+");
                }
                else
                {
                    dataGridView1.Rows.Add(time.ToString("HH:mm"), "+-");
                }
                time = time.AddHours(1);
            }
            //Ñâîéñòî contains íå ñòðîãîå è èùåò êëàñ äàæå åñëè â åãî ïîä ñòðîêå èùå åñòü êàêîé-òî êëàñ
            //var rows = tableNode.SelectNodes(".//div[contains(@class, 'disconnection-detailed-table-cell')]");
            MessageBox.Show("ëÿ îòðàáîòàë");

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //label1.Text = $"id={idCity};idstreet={idStreet}idhouse={idHouse}";
            await check();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void labelStreet_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddAddress addForm = new AddAddress();
            addForm.ShowDialog();
        }
    }
}
