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
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //2 метода запрос делать когда меняем ичейку 2 когда делаем уже само сохранения
        }
    }
}
