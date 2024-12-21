namespace Svitlo.Forms
{
    partial class ConnectToTelegram
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            buttonConnect = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(258, 15);
            label1.TabIndex = 0;
            label1.Text = "1)Перейдіть в телеграм бота @Your_Svitlo_bot";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.TelegramQR;
            pictureBox1.Location = new Point(12, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(248, 205);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 255);
            label2.Name = "label2";
            label2.Size = new Size(196, 15);
            label2.TabIndex = 2;
            label2.Text = "2)Нажміть кнопку \"Svitlo Connect\"";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 280);
            label3.Name = "label3";
            label3.Size = new Size(161, 15);
            label3.TabIndex = 3;
            label3.Text = "Та веддіть код нижче у поле";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 312);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 4;
            label4.Text = "Код";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(45, 309);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(99, 347);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(87, 23);
            buttonConnect.TabIndex = 6;
            buttonConnect.Text = "Підключити";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += button1_Click;
            // 
            // ConnectToTelegram
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 382);
            Controls.Add(buttonConnect);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConnectToTelegram";
            Text = "Connect to Telegram";
            Load += ConnectToTelegram_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Button buttonConnect;
    }
}