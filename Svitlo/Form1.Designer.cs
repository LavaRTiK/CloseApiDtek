﻿namespace Svitlo
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
            errorReadHouse = new ErrorProvider(components);
            button2 = new Button();
            label1 = new Label();
            richTextBox2 = new RichTextBox();
            dataGridView1 = new DataGridView();
            Date = new DataGridViewTextBoxColumn();
            test = new DataGridViewTextBoxColumn();
            SaveBuffer = new Label();
            SaveBufferComboBox = new ComboBox();
            SaveBufferContextMenuStrip = new ContextMenuStrip(components);
            редагуватиToolStripMenuItem = new ToolStripMenuItem();
            видалитиToolStripMenuItem = new ToolStripMenuItem();
            button3 = new Button();
            testlabel = new Label();
            hoverTimer = new System.Windows.Forms.Timer(components);
            CancelSave = new Button();
            ((System.ComponentModel.ISupportInitialize)errorReadCity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorReadStreet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorReadHouse).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SaveBufferContextMenuStrip.SuspendLayout();
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
            richTextBox1.Location = new Point(33, 122);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(449, 224);
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
            readCity.SelectionChangeCommitted += readCity_SelectionChangeCommitted;
            readCity.TextChanged += readCity_TextChanged;
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
            labelStreet.Click += labelStreet_Click;
            // 
            // readStreet
            // 
            readStreet.FormattingEnabled = true;
            readStreet.Location = new Point(227, 38);
            readStreet.Name = "readStreet";
            readStreet.Size = new Size(177, 23);
            readStreet.TabIndex = 6;
            readStreet.SelectedIndexChanged += readStreet_SelectedIndexChanged;
            readStreet.SelectionChangeCommitted += readStreet_SelectionChangeCommitted;
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
            readHouse.SelectedIndexChanged += readHouse_SelectedIndexChanged;
            readHouse.SelectionChangeCommitted += readHouse_SelectionChangeCommitted;
            readHouse.TextChanged += readHouse_TextChanged;
            // 
            // errorReadHouse
            // 
            errorReadHouse.ContainerControl = this;
            // 
            // button2
            // 
            button2.Location = new Point(267, 94);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "По Адресу";
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
            // richTextBox2
            // 
            richTextBox2.Location = new Point(476, 140);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(301, 227);
            richTextBox2.TabIndex = 11;
            richTextBox2.Text = "";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Date, test });
            dataGridView1.Location = new Point(215, 123);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(439, 271);
            dataGridView1.TabIndex = 12;
            // 
            // Date
            // 
            Date.HeaderText = "Date";
            Date.Name = "Date";
            // 
            // test
            // 
            test.HeaderText = "test";
            test.Name = "test";
            // 
            // SaveBuffer
            // 
            SaveBuffer.AutoSize = true;
            SaveBuffer.Location = new Point(653, 20);
            SaveBuffer.Name = "SaveBuffer";
            SaveBuffer.Size = new Size(65, 15);
            SaveBuffer.TabIndex = 13;
            SaveBuffer.Text = "Збережені";
            // 
            // SaveBufferComboBox
            // 
            SaveBufferComboBox.ContextMenuStrip = SaveBufferContextMenuStrip;
            SaveBufferComboBox.FormattingEnabled = true;
            SaveBufferComboBox.Location = new Point(630, 38);
            SaveBufferComboBox.Name = "SaveBufferComboBox";
            SaveBufferComboBox.Size = new Size(121, 23);
            SaveBufferComboBox.TabIndex = 14;
            SaveBufferComboBox.DropDown += SaveBufferComboBox_DropDown;
            SaveBufferComboBox.SelectedIndexChanged += SaveBufferComboBox_SelectedIndexChanged;
            SaveBufferComboBox.DropDownClosed += SaveBufferComboBox_DropDownClosed;
            SaveBufferComboBox.KeyDown += SaveBufferComboBox_KeyDown;
            // 
            // SaveBufferContextMenuStrip
            // 
            SaveBufferContextMenuStrip.AllowMerge = false;
            SaveBufferContextMenuStrip.AutoClose = false;
            SaveBufferContextMenuStrip.DropShadowEnabled = false;
            SaveBufferContextMenuStrip.Items.AddRange(new ToolStripItem[] { редагуватиToolStripMenuItem, видалитиToolStripMenuItem });
            SaveBufferContextMenuStrip.Name = "contextMenuStrip2";
            SaveBufferContextMenuStrip.Size = new Size(135, 48);
            // 
            // редагуватиToolStripMenuItem
            // 
            редагуватиToolStripMenuItem.Enabled = false;
            редагуватиToolStripMenuItem.Name = "редагуватиToolStripMenuItem";
            редагуватиToolStripMenuItem.Size = new Size(134, 22);
            редагуватиToolStripMenuItem.Text = "Редагувати";
            редагуватиToolStripMenuItem.TextImageRelation = TextImageRelation.TextBeforeImage;
            // 
            // видалитиToolStripMenuItem
            // 
            видалитиToolStripMenuItem.Name = "видалитиToolStripMenuItem";
            видалитиToolStripMenuItem.Size = new Size(134, 22);
            видалитиToolStripMenuItem.Text = "Видалити";
            // 
            // button3
            // 
            button3.Location = new Point(643, 67);
            button3.Name = "button3";
            button3.Size = new Size(108, 23);
            button3.TabIndex = 15;
            button3.Text = "Добавити адресу";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // testlabel
            // 
            testlabel.AutoSize = true;
            testlabel.Location = new Point(519, 9);
            testlabel.Name = "testlabel";
            testlabel.Size = new Size(38, 15);
            testlabel.TabIndex = 16;
            testlabel.Text = "label2";
            // 
            // hoverTimer
            // 
            hoverTimer.Tick += HoverTimer_Tick;
            // 
            // CancelSave
            // 
            CancelSave.Location = new Point(756, 38);
            CancelSave.Name = "CancelSave";
            CancelSave.Size = new Size(32, 23);
            CancelSave.TabIndex = 17;
            CancelSave.Text = "X";
            CancelSave.UseVisualStyleBackColor = true;
            CancelSave.Click += CancelSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CancelSave);
            Controls.Add(testlabel);
            Controls.Add(button3);
            Controls.Add(SaveBufferComboBox);
            Controls.Add(SaveBuffer);
            Controls.Add(dataGridView1);
            Controls.Add(richTextBox2);
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
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)errorReadCity).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorReadStreet).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorReadHouse).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            SaveBufferContextMenuStrip.ResumeLayout(false);
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
        private ErrorProvider errorReadHouse;
        private Label label1;
        private Button button2;
        private RichTextBox richTextBox2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn test;
        private ComboBox SaveBufferComboBox;
        private Label SaveBuffer;
        private Button button3;
        private Label testlabel;
        private System.Windows.Forms.Timer hoverTimer;
        private Button CancelSave;
        private ContextMenuStrip SaveBufferContextMenuStrip;
        private ToolStripMenuItem редагуватиToolStripMenuItem;
        private ToolStripMenuItem видалитиToolStripMenuItem;
    }
}
