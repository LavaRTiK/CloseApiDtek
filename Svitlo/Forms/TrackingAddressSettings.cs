using Svitlo.Component;
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
    public partial class TrackingAddressSettings : Form
    {
        AutoStartUp autoStartUp = new AutoStartUp();
        DataObjResidence dataObjResidence = new DataObjResidence();
        public TrackingAddressSettings()
        {
            InitializeComponent();
        }

        private void TrackingAddressSettings_Load(object sender, EventArgs e)
        {
            foreach (var item in dataObjResidence.GetAll())
            {
                dataGridView1.Rows.Add(item.Name, item.City, item.Street, item.House, item.IsFollowing);
            }
            if (autoStartUp.CheckShortcut())
            {
                checkBoxAutoStartUp.Checked = true;
            }
            else
            {
                checkBoxAutoStartUp.Checked = false;
            }
        }

        private async void Save_Click(object sender, EventArgs e)
        {
            //2 метода запрос делать когда меняем ичейку 2 когда делаем уже само сохранения
            //MessageBox.Show(dataGridView1.Rows[0].Cells[4].Value.ToString());
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[4].Value.ToString().Trim()) != dataObjResidence.GetAll().Find(x => x.Name == dataGridView1.Rows[i].Cells[0].Value).IsFollowing)
                {
                    dataObjResidence.EditIsFollowing(dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToBoolean(dataGridView1.Rows[i].Cells[4].Value));
                }
            }
            await dataObjResidence.LoadDataAsync();
            if (checkBoxAutoStartUp.Checked)
            {
                if (autoStartUp.CheckShortcut())
                {

                }
                else
                {
                    autoStartUp.CreateShortcut();
                }
            }
            else
            {
                autoStartUp.DeleteShortcut();
            }
            DialogResult = DialogResult.OK;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
