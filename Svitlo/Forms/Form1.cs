using System.Net.Http.Json;
using System.Windows;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Svitlo.Component;
using Svitlo.ObjectModels;
using Timer = System.Windows.Forms.Timer;
using Svitlo.Forms;
/*
  Сделать отписку и подписку text_change для texbox сity street house запрос лишний city //ok
  Подзсказка для елемента savebufferComboBox (выдает которко адрес когда наводишся указателем) // ok
  добавить кнопку роблокировка формы когда она висит на запросе от save  //ok
  сделать name в save как индификатор для дальшего поиска указателя доделать в Address совпадения по имени //ok
  сделать форму для удаления адресов (доп) найти способ перехвата правой кнопки мышки в combobox списке вызывать ContextStripMenu //не возможно простым путем 
  сделать delete //ok 
  посмотреть как сделать trail app / реализвовать увидомления windows если это возможно  (notify icon)   notify - 
  сделать форму настройки таймер c отключениям света туда добавить увидомления 
  перенести в dataloader cheak //ok
  изучить CancellationToken для запуска задачи для оповищения
  traking address CellValueChanged отследить изменения textboxcolumn (CurrentCellDirtyStateChanged) сделал по другому //ok 
  сохран даные сделать индикатор запроса 
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
        private List<TrackingAddress> currentTraking = new List<TrackingAddress>();
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
            notifyIcon1.BalloonTipText = "Svitlo звернуто";
            notifyIcon1.Text = "Svitlo";
            CancelSave.Visible = false;
            await SaveBufferComboBoxUpdate();

            CheakTrackingUpadate();
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
            if (readHouse.Text.Length >= 1)
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
                errorReadHouse.SetError(this.readHouse, "Довжина тексту повина будти більше 1-ох");
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
            var content = await dataLoderAPI.RequestDisconnectDataAsync(readCity.Text, idCity, readStreet.Text, idStreet, readHouse.Text, idHouse);
            richTextBox1.Text = content[2].data.ToString();
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
                await SaveBufferComboBoxUpdate();
            }
            else
            {
                //dont update
            }
        }

        private void SaveBufferComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            readCity.TextChanged -= readCity_TextChanged;
            readStreet.TextChanged -= readStreet_TextChanged;
            readHouse.TextChanged -= readHouse_TextChanged;
            ObjResidence data = (ObjResidence)SaveBufferComboBox.SelectedItem;
            if (data != null)
            {
                readCity.Enabled = false;
                readStreet.Enabled = false;
                readHouse.Enabled = false;
                readCity.Text = data.City;
                readStreet.Text = data.Street;
                readHouse.Text = data.House;
                idCity = data.IdCity;
                idStreet = data.IdStreet;
                idHouse = data.IdHouse;
                CancelSave.Visible = true;
            }
            readCity.TextChanged += readCity_TextChanged;
            readStreet.TextChanged += readStreet_TextChanged;
            readHouse.TextChanged += readHouse_TextChanged;
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
                readCity.Text = currentItem.City;
                readStreet.Text = currentItem.Street;
                readHouse.Text = currentItem.House;
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
            readCity.Text = "";
            readStreet.Text = "";
            readHouse.Text = "";
            readCity.TextChanged += readCity_TextChanged;
            readStreet.TextChanged += readStreet_TextChanged;
            readHouse.TextChanged += readHouse_TextChanged;
            hoverTimer.Stop();
        }

        private void CancelSave_Click(object sender, EventArgs e)
        {
            readCity.Text = "";
            readStreet.Text = "";
            readHouse.Text = "";
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

        private async void SaveBufferComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var data = (ObjResidence)SaveBufferComboBox.Items[SaveBufferComboBox.SelectedIndex];
                if (data != null)
                {
                    string message = $"Видалити:{data.Name}?";
                    string caption = "Видалення";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Warning;
                    DialogResult result = MessageBox.Show(message, caption, buttons, icon);
                    if (result == DialogResult.Yes)
                    {
                        dataObjResidence.Remove(data);
                        await dataObjResidence.LoadDataAsync();
                        await SaveBufferComboBoxUpdate();
                    }
                }
            }
        }
        private async Task SaveBufferComboBoxUpdate()
        {
            SaveBufferComboBox.Items.Clear();
            await dataObjResidence.ReadDataAsync();
            dataResidencesList = dataObjResidence.GetAll();
            if (dataResidencesList != null)
            {
                SaveBufferComboBox.BeginUpdate();
                foreach (var item in dataResidencesList)
                {
                    SaveBufferComboBox.Items.Add(item);
                }
                SaveBufferComboBox.EndUpdate();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void показатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void закритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            TrackingAddressSettings trackingAddressSettings = new TrackingAddressSettings();
            if (trackingAddressSettings.ShowDialog() == DialogResult.OK)
            {
                CheakTrackingUpadate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrackingAddress test = new TrackingAddress(dataResidencesList[1]);
            test.StartFollowing();
        }
        private void CheakTrackingUpadate()
        {
            foreach (var item in dataResidencesList)
            {
                if(item.IsFollowing == true)
                {
                    if (currentTraking.Any(x => x.Name == item.Name))
                    {

                    }
                    else
                    {
                        TrackingAddress trackingAddress = new TrackingAddress(item);
                        currentTraking.Add(trackingAddress);
                        trackingAddress.StartFollowing();
                    }
                    
                }
                else
                {
                    if(currentTraking.Any(x => x.Name == item.Name))
                    {
                        var temp = currentTraking.Find(x => x.Name == item.Name);
                        temp.StopFollowing();
                        currentTraking.Remove(temp);
                    }
                }
            }
            MessageBox.Show(currentTraking.Count.ToString());
        }
    }
}
