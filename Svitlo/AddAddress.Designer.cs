namespace Svitlo
{
    partial class AddAddress
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
            components = new System.ComponentModel.Container();
            readHouse = new ComboBox();
            labelHouse = new Label();
            readStreet = new ComboBox();
            labelStreet = new Label();
            labelCity = new Label();
            readCity = new ComboBox();
            textBoxName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            errorReadCityComboBox = new ErrorProvider(components);
            errorReadStreetComboBox = new ErrorProvider(components);
            errorReadHouseComboBox = new ErrorProvider(components);
            errorName = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorReadCityComboBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorReadStreetComboBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorReadHouseComboBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorName).BeginInit();
            SuspendLayout();
            // 
            // readHouse
            // 
            readHouse.FormattingEnabled = true;
            readHouse.Location = new Point(12, 244);
            readHouse.Name = "readHouse";
            readHouse.Size = new Size(137, 23);
            readHouse.TabIndex = 20;
            readHouse.SelectedIndexChanged += readHouse_SelectedIndexChanged;
            readHouse.SelectionChangeCommitted += readHouse_SelectionChangeCommitted;
            readHouse.TextChanged += readHouse_TextChanged;
            // 
            // labelHouse
            // 
            labelHouse.AutoSize = true;
            labelHouse.Location = new Point(12, 226);
            labelHouse.Name = "labelHouse";
            labelHouse.Size = new Size(53, 15);
            labelHouse.TabIndex = 19;
            labelHouse.Text = "Будинок";
            // 
            // readStreet
            // 
            readStreet.FormattingEnabled = true;
            readStreet.Location = new Point(12, 185);
            readStreet.Name = "readStreet";
            readStreet.Size = new Size(177, 23);
            readStreet.TabIndex = 18;
            readStreet.SelectionChangeCommitted += readStreet_SelectionChangeCommitted;
            readStreet.SelectedValueChanged += readStreet_SelectedValueChanged;
            readStreet.TextChanged += readStreet_TextChanged;
            // 
            // labelStreet
            // 
            labelStreet.AutoSize = true;
            labelStreet.Location = new Point(12, 167);
            labelStreet.Name = "labelStreet";
            labelStreet.Size = new Size(54, 15);
            labelStreet.TabIndex = 17;
            labelStreet.Text = "Вуллиця";
            // 
            // labelCity
            // 
            labelCity.AutoSize = true;
            labelCity.Location = new Point(12, 106);
            labelCity.Name = "labelCity";
            labelCity.Size = new Size(39, 15);
            labelCity.TabIndex = 16;
            labelCity.Text = "Місто";
            // 
            // readCity
            // 
            readCity.FormattingEnabled = true;
            readCity.Location = new Point(12, 124);
            readCity.Name = "readCity";
            readCity.Size = new Size(171, 23);
            readCity.TabIndex = 15;
            readCity.SelectionChangeCommitted += readCity_SelectionChangeCommitted;
            readCity.SelectedValueChanged += readCity_SelectedValueChanged;
            readCity.TextChanged += readCity_TextChanged;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 66);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Home";
            textBoxName.Size = new Size(171, 23);
            textBoxName.TabIndex = 21;
            textBoxName.TextChanged += textBoxName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 48);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 22;
            label1.Text = "Назва";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 9);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 23;
            label2.Text = "Форма Добавлення";
            // 
            // button1
            // 
            button1.Location = new Point(72, 297);
            button1.Name = "button1";
            button1.Size = new Size(99, 27);
            button1.TabIndex = 24;
            button1.Text = "Зберегти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // errorReadCityComboBox
            // 
            errorReadCityComboBox.ContainerControl = this;
            // 
            // errorReadStreetComboBox
            // 
            errorReadStreetComboBox.ContainerControl = this;
            // 
            // errorReadHouseComboBox
            // 
            errorReadHouseComboBox.ContainerControl = this;
            // 
            // errorName
            // 
            errorName.ContainerControl = this;
            // 
            // AddAddress
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(239, 385);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Controls.Add(readHouse);
            Controls.Add(labelHouse);
            Controls.Add(readStreet);
            Controls.Add(labelStreet);
            Controls.Add(labelCity);
            Controls.Add(readCity);
            Name = "AddAddress";
            Text = "AddAddress";
            Load += AddAddress_Load;
            ((System.ComponentModel.ISupportInitialize)errorReadCityComboBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorReadStreetComboBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorReadHouseComboBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorName).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox readHouse;
        private Label labelHouse;
        private ComboBox readStreet;
        private Label labelStreet;
        private Label labelCity;
        private ComboBox readCity;
        private TextBox textBoxName;
        private Label label1;
        private Label label2;
        private Button button1;
        private ErrorProvider errorReadCityComboBox;
        private ErrorProvider errorReadStreetComboBox;
        private ErrorProvider errorReadHouseComboBox;
        private ErrorProvider errorName;
    }
}