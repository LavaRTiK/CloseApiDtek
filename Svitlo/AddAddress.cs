using Svitlo.Component;
using Svitlo.ObjectModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Svitlo
{
    public partial class AddAddress : Form
    {
        private bool isChangeIndexReadCity = false;
        DataLoderAPI dataLoderAPI = new DataLoderAPI();
        Regex regex = new Regex(@"[0-9]+");
        private DataObjResidence dataObjResidence = new DataObjResidence(); 
        private int idCity = 0;
        private int idStreet = 0;
        private int idHouse = 0;
        private string? city { get; set; }
        private string? street { get; set; }
        private string? house { get; set; }
        private bool[] rule = { false, false, false, false};
        //rule простий спосіб перевірки валідності {name,city,street,house}
        //форма намє валідації
        public AddAddress()
        {
            InitializeComponent();
        }

        private void AddAddress_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private async void readCity_TextChanged(object sender, EventArgs e)
        {
            await SearchCityAsync();
        }
        private async Task SearchCityAsync()
        {
            if (readCity.Text.Length > 3)
            {
                errorReadCityComboBox.SetError(this.readCity, "Виконується запит");
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
                    errorReadCityComboBox.SetError(this.readCity, String.Empty);
                }
            }
            else
            {
                errorReadCityComboBox.SetError(this.readCity, "Довжина тексту повина будти більше 3-ох");
                rule[1] = false; //city
            }
        }

        private void readCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            readCity.TextChanged -= readCity_TextChanged;
        }
        private void readCity_SelectedValueChanged(object sender, EventArgs e)
        {
            City city = (City)readCity.SelectedItem;
            idCity = Convert.ToInt32(regex.Match(city.label).Value);
#if DEBUG
            MessageBox.Show("Вибраний item має айди" + idCity);
#endif
            rule[1] = true; //city
            readCity.TextChanged += readCity_TextChanged;
            CheakRule();
        }

        private async void readStreet_TextChanged(object sender, EventArgs e)
        {
            if (idCity == 0)
            {
                errorReadStreetComboBox.SetError(readStreet, "Заповніть спочатку місто");
                return;
            }
            await SearchStreetAsync();
        }
        private async Task SearchStreetAsync()
        {
            if (readStreet.Text.Length > 3)
            {
                errorReadStreetComboBox.SetError(this.readStreet, "Виконується запит");
                var content = await dataLoderAPI.SearchStreetAsync(idCity, readStreet.Text);
                if (content != null)
                {
                    readStreet.BeginUpdate();
                    readStreet.Items.Clear();
                    foreach (var item in content)
                    {
                        readStreet.Items.Add(item);
                    }
                    readStreet.EndUpdate();
                    errorReadStreetComboBox.SetError(this.readStreet, String.Empty);
                }
            }
            else
            {
                errorReadStreetComboBox.SetError(this.readStreet, "Довжина тексту повина будти більше 3-ох");
                rule[2] = false; //street
            }
        }

        private void readStreet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            readStreet.TextChanged -= readStreet_TextChanged;
        }

        private void readStreet_SelectedValueChanged(object sender, EventArgs e)
        {
            City city = (City)readStreet.SelectedItem;
            idStreet = Convert.ToInt32(regex.Match(city.label).Value);
#if DEBUG
            MessageBox.Show("Вибраний item має айди" + idStreet);
#endif
            rule[2] = true;
            readStreet.TextChanged += readStreet_TextChanged;
            CheakRule();
        }

        private async void readHouse_TextChanged(object sender, EventArgs e)
        {
            if (idStreet == 0)
            {
                errorReadHouseComboBox.SetError(this.readHouse, "заповніть спочатку вулицю");
            }
            await SearchHouseAsync();
        }
        private async Task SearchHouseAsync()
        {
            if (readStreet.Text.Length > 3)
            {
                errorReadHouseComboBox.SetError(this.readHouse, "Виконується запит");
                var content = await dataLoderAPI.SearchHouseAsync(idStreet, readHouse.Text);
                if (content != null)
                {
                    readHouse.BeginUpdate();
                    readHouse.Items.Clear();
                    foreach (var item in content)
                    {
                        readHouse.Items.Add(item);
                    }
                    readHouse.EndUpdate();
                    errorReadHouseComboBox.SetError(this.readHouse, String.Empty);
                }
            }
            else
            {
                errorReadHouseComboBox.SetError(this.readHouse, "Довжина тексту повина будти більше 3-ох");
                rule[3] = false; //house
            }
        }

        private void readHouse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            readHouse.TextChanged -= readHouse_TextChanged;
        }

        private void readHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            City city = (City)readHouse.SelectedItem;
            idHouse = Convert.ToInt32(regex.Match(city.label).Value);
#if DEBUG
            MessageBox.Show("Вибраний item має айди" + idHouse);
#endif
            rule[3] = true; //house
            readHouse.TextChanged += readHouse_TextChanged;
            CheakRule();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ObjResidence obj = new ObjResidence(textBoxName.Text, idCity, readCity.Text, idStreet, readStreet.Text, idHouse, readHouse.Text);
            dataObjResidence.Add(obj);
            await dataObjResidence.LoadData();
            DialogResult = DialogResult.OK;
        }
        //Перевірка вимог форми
        private void CheakRule()
        {
            if(rule.All(x => x == true))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled=false;
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length >= 4 && !string.IsNullOrWhiteSpace(textBoxName.Text) && textBoxName.Text.Trim(' ').Length >= 4)
            {
                errorName.SetError(this.textBoxName, string.Empty);
                rule[0] = true; //name
            }
            else
            {
                rule[0] = false; //name
                errorName.SetError(this.textBoxName, "назва повина містити більше 4 симловів");
            }
            CheakRule();
        }
    }
}
