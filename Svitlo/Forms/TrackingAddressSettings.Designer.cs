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
            Save = new Button();
            checkBoxAutoStartUp = new CheckBox();
            label1 = new Label();
            AddressName = new DataGridViewTextBoxColumn();
            City = new DataGridViewTextBoxColumn();
            Street = new DataGridViewTextBoxColumn();
            House = new DataGridViewTextBoxColumn();
            Following = new DataGridViewCheckBoxColumn();
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
            dataGridView1.Location = new Point(12, 81);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(579, 177);
            dataGridView1.TabIndex = 0;
            // 
            // Save
            // 
            Save.Location = new Point(516, 264);
            Save.Name = "Save";
            Save.Size = new Size(75, 23);
            Save.TabIndex = 1;
            Save.Text = "Зберегти";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // checkBoxAutoStartUp
            // 
            checkBoxAutoStartUp.AutoSize = true;
            checkBoxAutoStartUp.Location = new Point(12, 40);
            checkBoxAutoStartUp.Name = "checkBoxAutoStartUp";
            checkBoxAutoStartUp.Size = new Size(128, 19);
            checkBoxAutoStartUp.TabIndex = 2;
            checkBoxAutoStartUp.Text = "Автозавантаження";
            checkBoxAutoStartUp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(248, 19);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 3;
            label1.Text = "Налаштування";
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
            Following.HeaderText = "Слідкувати";
            Following.Name = "Following";
            Following.Resizable = DataGridViewTriState.True;
            Following.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // TrackingAddressSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 299);
            Controls.Add(label1);
            Controls.Add(checkBoxAutoStartUp);
            Controls.Add(Save);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TrackingAddressSettings";
            Text = "TrackingAddressSettings";
            Load += TrackingAddressSettings_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button Save;
        private CheckBox checkBoxAutoStartUp;
        private Label label1;
        private DataGridViewTextBoxColumn AddressName;
        private DataGridViewTextBoxColumn City;
        private DataGridViewTextBoxColumn Street;
        private DataGridViewTextBoxColumn House;
        private DataGridViewCheckBoxColumn Following;
    }
}