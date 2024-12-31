namespace Svitlo
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            SaveBuffer = new Label();
            SaveBufferComboBox = new ComboBox();
            SaveBufferContextMenuStrip = new ContextMenuStrip(components);
            редагуватиToolStripMenuItem = new ToolStripMenuItem();
            видалитиToolStripMenuItem = new ToolStripMenuItem();
            button3 = new Button();
            testlabel = new Label();
            hoverTimer = new System.Windows.Forms.Timer(components);
            CancelSave = new Button();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStripNotify = new ContextMenuStrip(components);
            показатиToolStripMenuItem = new ToolStripMenuItem();
            закритиToolStripMenuItem = new ToolStripMenuItem();
            buttonSettings = new Button();
            button4 = new Button();
            labelIndicatorCheck = new Label();
            dataGridViewTest = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)errorReadCity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorReadStreet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorReadHouse).BeginInit();
            SaveBufferContextMenuStrip.SuspendLayout();
            contextMenuStripNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTest).BeginInit();
            SuspendLayout();
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
            testlabel.Location = new Point(653, 5);
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
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStripNotify;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStripNotify
            // 
            contextMenuStripNotify.Items.AddRange(new ToolStripItem[] { показатиToolStripMenuItem, закритиToolStripMenuItem });
            contextMenuStripNotify.Name = "contextMenuStripNotify";
            contextMenuStripNotify.Size = new Size(126, 48);
            // 
            // показатиToolStripMenuItem
            // 
            показатиToolStripMenuItem.Name = "показатиToolStripMenuItem";
            показатиToolStripMenuItem.Size = new Size(125, 22);
            показатиToolStripMenuItem.Text = "Показати";
            показатиToolStripMenuItem.Click += показатиToolStripMenuItem_Click;
            // 
            // закритиToolStripMenuItem
            // 
            закритиToolStripMenuItem.Name = "закритиToolStripMenuItem";
            закритиToolStripMenuItem.Size = new Size(125, 22);
            закритиToolStripMenuItem.Text = "Закрити";
            закритиToolStripMenuItem.Click += закритиToolStripMenuItem_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.Image = Properties.Resources.rb_6328__2_;
            buttonSettings.Location = new Point(756, 5);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(32, 30);
            buttonSettings.TabIndex = 18;
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // button4
            // 
            button4.Location = new Point(562, 94);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 19;
            button4.Text = "test";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // labelIndicatorCheck
            // 
            labelIndicatorCheck.AutoSize = true;
            labelIndicatorCheck.Location = new Point(284, 75);
            labelIndicatorCheck.Name = "labelIndicatorCheck";
            labelIndicatorCheck.Size = new Size(38, 15);
            labelIndicatorCheck.TabIndex = 20;
            labelIndicatorCheck.Text = "label2";
            // 
            // dataGridViewTest
            // 
            dataGridViewTest.AllowUserToAddRows = false;
            dataGridViewTest.AllowUserToDeleteRows = false;
            dataGridViewTest.BackgroundColor = SystemColors.Control;
            dataGridViewTest.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTest.Location = new Point(12, 141);
            dataGridViewTest.Name = "dataGridViewTest";
            dataGridViewTest.Size = new Size(776, 216);
            dataGridViewTest.TabIndex = 21;
            dataGridViewTest.CellPainting += DataGridView_CellPainting;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(798, 451);
            Controls.Add(dataGridViewTest);
            Controls.Add(labelIndicatorCheck);
            Controls.Add(button4);
            Controls.Add(buttonSettings);
            Controls.Add(CancelSave);
            Controls.Add(testlabel);
            Controls.Add(button3);
            Controls.Add(SaveBufferComboBox);
            Controls.Add(SaveBuffer);
            Controls.Add(button2);
            Controls.Add(readHouse);
            Controls.Add(labelHouse);
            Controls.Add(readStreet);
            Controls.Add(labelStreet);
            Controls.Add(labelCity);
            Controls.Add(readCity);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Main";
            Text = "Svitlo";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)errorReadCity).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorReadStreet).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorReadHouse).EndInit();
            SaveBufferContextMenuStrip.ResumeLayout(false);
            contextMenuStripNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTest).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox readCity;
        private Label labelCity;
        private ErrorProvider errorReadCity;
        private ComboBox readStreet;
        private Label labelStreet;
        private ErrorProvider errorReadStreet;
        private ComboBox readHouse;
        private Label labelHouse;
        private ErrorProvider errorReadHouse;
        private Button button2;
        private ComboBox SaveBufferComboBox;
        private Label SaveBuffer;
        private Button button3;
        private Label testlabel;
        private System.Windows.Forms.Timer hoverTimer;
        private Button CancelSave;
        private ContextMenuStrip SaveBufferContextMenuStrip;
        private ToolStripMenuItem редагуватиToolStripMenuItem;
        private ToolStripMenuItem видалитиToolStripMenuItem;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStripNotify;
        private ToolStripMenuItem показатиToolStripMenuItem;
        private ToolStripMenuItem закритиToolStripMenuItem;
        private Button buttonSettings;
        private Button button4;
        private Label labelIndicatorCheck;
        private DataGridView dataGridViewTest;
    }
}
