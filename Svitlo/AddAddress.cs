using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Svitlo
{
    public partial class AddAddress : Form
    {
        private bool isChangeIndexReadCity = false;
        public AddAddress()
        {
            InitializeComponent();
        }

        private void AddAddress_Load(object sender, EventArgs e)
        {
            readCity.Items.Add("1");
            readCity.Items.Add("2");
            readCity.Items.Add("3");
            readCity.Items.Add("4");
            readCity.Items.Add("5");
            readCity.Items.Add("6");
        }

        private void readCity_TextChanged(object sender, EventArgs e)
        {
            readCity.BeginUpdate();
            //запрос 
            for (int i = 0; i < 3; i++)
            {
                readCity.Items.Add(i);
            }
            readCity.EndUpdate();
            MessageBox.Show("text change");
        }

        private void readCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            readCity.TextChanged -= readCity_TextChanged;
            MessageBox.Show("вызвало " + readCity.SelectedItem);
        }
        private void readCity_SelectedValueChanged(object sender, EventArgs e)
        {
            readCity.TextChanged += readCity_TextChanged;
        }
    }
}
