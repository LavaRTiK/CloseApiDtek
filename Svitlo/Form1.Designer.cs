namespace Svitlo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            readCity = new ComboBox();
            labelCity = new Label();
            errorReadCity = new ErrorProvider(components);
            labelStreet = new Label();
            readStreet = new ComboBox();
            errorReadStreet = new ErrorProvider(components);
            labelHouse = new Label();
            readHouse = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            button2 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorReadCity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorReadStreet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(349, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(111, 180);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(449, 135);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // readCity
            // 
            readCity.FormattingEnabled = true;
            readCity.Location = new Point(33, 38);
            readCity.Name = "readCity";
            readCity.Size = new Size(171, 23);
            readCity.TabIndex = 3;
            readCity.SelectedIndexChanged += readCity_SelectedIndexChanged;
            readCity.TextChanged += comboBox1_TextChanged;
            // 
            // labelCity
            // 
            labelCity.AutoSize = true;
            labelCity.Location = new Point(33, 20);
            labelCity.Name = "labelCity";
            labelCity.Size = new Size(39, 15);
            labelCity.TabIndex = 4;
            labelCity.Text = "Місто";
            // 
            // errorReadCity
            // 
            errorReadCity.ContainerControl = this;
            // 
            // labelStreet
            // 
            labelStreet.AutoSize = true;
            labelStreet.Location = new Point(227, 20);
            labelStreet.Name = "labelStreet";
            labelStreet.Size = new Size(54, 15);
            labelStreet.TabIndex = 5;
            labelStreet.Text = "Вуллиця";
            // 
            // readStreet
            // 
            readStreet.FormattingEnabled = true;
            readStreet.Location = new Point(227, 38);
            readStreet.Name = "readStreet";
            readStreet.Size = new Size(177, 23);
            readStreet.TabIndex = 6;
            readStreet.SelectedIndexChanged += readStreet_SelectedIndexChanged;
            readStreet.TextChanged += readStreet_TextChanged;
            // 
            // errorReadStreet
            // 
            errorReadStreet.ContainerControl = this;
            // 
            // labelHouse
            // 
            labelHouse.AutoSize = true;
            labelHouse.Location = new Point(439, 20);
            labelHouse.Name = "labelHouse";
            labelHouse.Size = new Size(53, 15);
            labelHouse.TabIndex = 7;
            labelHouse.Text = "Будинок";
            // 
            // readHouse
            // 
            readHouse.FormattingEnabled = true;
            readHouse.Location = new Point(439, 38);
            readHouse.Name = "readHouse";
            readHouse.Size = new Size(137, 23);
            readHouse.TabIndex = 8;
            readHouse.TextChanged += readHouse_TextChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // button2
            // 
            button2.Location = new Point(253, 100);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(267, 143);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 10;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(readHouse);
            Controls.Add(labelHouse);
            Controls.Add(readStreet);
            Controls.Add(labelStreet);
            Controls.Add(labelCity);
            Controls.Add(readCity);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)errorReadCity).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorReadStreet).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private RichTextBox richTextBox1;
        private ComboBox readCity;
        private Label labelCity;
        private ErrorProvider errorReadCity;
        private ComboBox readStreet;
        private Label labelStreet;
        private ErrorProvider errorReadStreet;
        private ComboBox readHouse;
        private Label labelHouse;
        private ErrorProvider errorProvider1;
        private Label label1;
        private Button button2;
    }
}
