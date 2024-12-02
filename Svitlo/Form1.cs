using System.Net.Http.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Svitlo.Component;
using Svitlo.ObjectModels;
using Timer = System.Windows.Forms.Timer;
/*
  Сделать отписку и подписку text_change для texbox сity street house запрос лишний city //ok
  Подзсказка для елемента savebufferComboBox (выдает которко адрес когда наводишся указателем) // ok
  добавить кнопку роблокировка формы когда она висит на запросе от save  //ok
  сделать name в save как индификатор для дальшего поиска указателя // ok
  сделать форму для удаления адресов (доп) найти способ перехвата правой кнопки мышки в combobox списке вызывать ContextStripMenu
  
 */
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
        //test
        private ObjResidence currentItem;
        private int hoverTime;
        //test
        private string? city { get; set; }
        private string? street { get; set; }
        private string? house { get; set; }
        private DataLoderAPI dataLoderAPI = new DataLoderAPI();

        private DataObjResidence dataObjResidence = new DataObjResidence();
        private List<ObjResidence> dataResidencesList;
        private async void Form1_Load(object sender, EventArgs e)
        {
            await dataObjResidence.ReadData();
            dataResidencesList = dataObjResidence.GetAll();
            if (dataResidencesList != null)
            {
                foreach (var item in dataResidencesList)
                {
                    SaveBufferComboBox.Items.Add(item);
                }
            }
        }
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

        private async void readCity_TextChanged(object sender, EventArgs e)
        {
            await SearchCity();
        }
        private async Task SearchCity()
        {
            if (readCity.Text.Length > 3)
            {
                errorReadCity.SetError(this.readCity, "Виконується запит");
                var content = await dataLoderAPI.SearchCityAsync(readCity.Text);
                if (content != null)
                {
                    readCity.BeginUpdate();
                    readCity.Items.Clear();
                    foreach (var item in content)
                    {
                        readCity.Items.Add(item);
                    }
                    readCity.EndUpdate();
                    errorReadCity.SetError(this.readCity, String.Empty);
                }
            }
            else
            {
                errorReadCity.SetError(this.readCity, "Довжина тексту повина будти більше 3-ох");
            }
        }

        private void readCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            City city = (City)readCity.SelectedItem;

            Regex regex = new Regex(@"[0-9]+");
            idCity = Convert.ToInt32(regex.Match(city.label).Value);
            readCity.TextChanged += readCity_TextChanged;
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
                var content = await dataLoderAPI.SearchStreetAsync(idCity, readStreet.Text);
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
                errorReadStreet.SetError(this.readStreet, "Довжина тексту повина будти більше 3-ох");
            }
        }

        private void readStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            City city = (City)readStreet.SelectedItem;

            Regex regex = new Regex(@"[0-9]+");
            idStreet = Convert.ToInt32(regex.Match(city.label).Value);
            readStreet.TextChanged += readStreet_TextChanged;
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
                errorReadHouse.SetError(this.readHouse, "Довжина тексту повина будти більше 3-ох");
            }
        }
        private void readHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            City city = (City)readHouse.SelectedItem;

            Regex regex = new Regex(@"[0-9]+");
            idHouse = Convert.ToInt32(regex.Match(city.label).Value);
            readHouse.TextChanged += readHouse_TextChanged;
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
        private void labelStreet_Click(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            AddAddress addForm = new AddAddress();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await dataObjResidence.ReadData();
                dataResidencesList = dataObjResidence.GetAll();
                foreach (var item in dataResidencesList)
                {
                    SaveBufferComboBox.Items.Add(item.name);
                }
            }
            else
            {
                //dont update
            }
        }

        private void SaveBufferComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjResidence data = (ObjResidence)SaveBufferComboBox.SelectedItem;
            readCity.Enabled = false;
            readStreet.Enabled = false;
            readHouse.Enabled = false;
            readCity.Text = data.city;
            readStreet.Text = data.street;
            readHouse.Text = data.house;
            idCity = data.idCity;
            idStreet = data.idStreet;
            idHouse = data.idHouse;
            CancelSave.Visible = true;
        }
        private void HoverTimer_Tick(object sender, EventArgs e)
        {
            var hoveredIndex = SaveBufferComboBox.SelectedIndex;
            if (hoveredIndex < 0 || hoveredIndex >= SaveBufferComboBox.Items.Count) return;

            ObjResidence hoveredItem = (ObjResidence)SaveBufferComboBox.Items[hoveredIndex];

            if (!hoveredItem.Equals(currentItem))
            {
                currentItem = hoveredItem;
                hoverTime = 0;
            }

            hoverTime += hoverTimer.Interval;

            if (hoverTime >= 2000)
            {
                readCity.Text = currentItem.city;
                readStreet.Text = currentItem.street;
                readHouse.Text = currentItem.house;
                testlabel.Text = $"Selected: {currentItem}";
                hoverTime = 0;
            }
        }

        private void SaveBufferComboBox_DropDown(object sender, EventArgs e)
        {
            hoverTimer.Start();
            readCity.TextChanged -= readCity_TextChanged;
            readStreet.TextChanged -= readStreet_TextChanged;
            readHouse.TextChanged -= readHouse_TextChanged;
        }

        private void SaveBufferComboBox_DropDownClosed(object sender, EventArgs e)
        {
            readCity.TextChanged += readCity_TextChanged;
            readStreet.TextChanged += readStreet_TextChanged;
            readHouse.TextChanged += readHouse_TextChanged;
            readCity.Text = "";
            readStreet.Text = "";
            readHouse.Text = "";
            hoverTimer.Stop();
        }

        private void CancelSave_Click(object sender, EventArgs e)
        {
            readCity.Text = "";
            readHouse.Text = "";
            readStreet.Text = "";
            readCity.Enabled = true;
            readStreet.Enabled = true;
            readHouse.Enabled = true;
            CancelSave.Visible = false;
            SaveBufferComboBox.Text = "";
        }

        private void readCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            readCity.TextChanged -= readCity_TextChanged;
        }

        private void readStreet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            readStreet.TextChanged -= readStreet_TextChanged;
        }

        private void readHouse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            readHouse.TextChanged -= readHouse_TextChanged;
        }

        private void SaveBufferComboBox_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
