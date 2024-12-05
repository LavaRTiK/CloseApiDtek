namespace Svitlo.Forms
{
    partial class TrackingAddressSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            AddressName = new DataGridViewTextBoxColumn();
            City = new DataGridViewTextBoxColumn();
            Street = new DataGridViewTextBoxColumn();
            House = new DataGridViewTextBoxColumn();
            Following = new DataGridViewCheckBoxColumn();
            Save = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { AddressName, City, Street, House, Following });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(579, 177);
            dataGridView1.TabIndex = 0;
            // 
            // AddressName
            // 
            AddressName.HeaderText = "Назва";
            AddressName.Name = "AddressName";
            AddressName.ReadOnly = true;
            // 
            // City
            // 
            City.HeaderText = "Город";
            City.Name = "City";
            City.ReadOnly = true;
            // 
            // Street
            // 
            Street.HeaderText = "Вулиця";
            Street.Name = "Street";
            Street.ReadOnly = true;
            // 
            // House
            // 
            House.HeaderText = "Будинок";
            House.Name = "House";
            House.ReadOnly = true;
            // 
            // Following
            // 
            Following.HeaderText = "Отслеживать";
            Following.Name = "Following";
            Following.Resizable = DataGridViewTriState.True;
            Following.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Save
            // 
            Save.Location = new Point(516, 361);
            Save.Name = "Save";
            Save.Size = new Size(75, 23);
            Save.TabIndex = 1;
            Save.Text = "Зберегти";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // TrackingAddressSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 396);
            Controls.Add(Save);
            Controls.Add(dataGridView1);
            Name = "TrackingAddressSettings";
            Text = "TrackingAddressSettings";
            Load += TrackingAddressSettings_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn AddressName;
        private DataGridViewTextBoxColumn City;
        private DataGridViewTextBoxColumn Street;
        private DataGridViewTextBoxColumn House;
        private DataGridViewCheckBoxColumn Following;
        private Button Save;
    }
}