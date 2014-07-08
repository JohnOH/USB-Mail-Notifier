namespace USBMailNotifierTest
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.R = new System.Windows.Forms.TrackBar();
            this.B = new System.Windows.Forms.TrackBar();
            this.G = new System.Windows.Forms.TrackBar();
            this.RefreshRate = new System.Windows.Forms.Timer(this.components);
            this.Pulse = new System.Windows.Forms.Button();
            this.CloseForm = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.GmailLabel = new System.Windows.Forms.Label();
            this.EnableUnreadCount = new System.Windows.Forms.CheckBox();
            this.CheckNow = new System.Windows.Forms.Button();
            this.SaveLogin = new System.Windows.Forms.Button();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblNewUnreadMailCount = new System.Windows.Forms.Label();
            this.lblTotalUnreadMailCount = new System.Windows.Forms.Label();
            this.MoveForm = new System.Windows.Forms.Button();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.TrackBar();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.ModeBox = new System.Windows.Forms.ComboBox();
            this.usbStatus = new System.Windows.Forms.PictureBox();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.Light = new System.Windows.Forms.Button();
            this.labelB = new System.Windows.Forms.Label();
            this.labelG = new System.Windows.Forms.Label();
            this.labelR = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.HideForm = new System.Windows.Forms.Button();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.PulseTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblTotalUnreadNum = new System.Windows.Forms.Label();
            this.lblLastUnreadNum = new System.Windows.Forms.Label();
            this.mailCheckInterval = new System.Windows.Forms.ComboBox();
            this.MailTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G)).BeginInit();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usbStatus)).BeginInit();
            this.Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // R
            // 
            this.R.AutoSize = false;
            this.R.Location = new System.Drawing.Point(15, 49);
            this.R.Maximum = 64;
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(300, 20);
            this.R.TabIndex = 0;
            this.R.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip.SetToolTip(this.R, "Red");
            // 
            // B
            // 
            this.B.AutoSize = false;
            this.B.Location = new System.Drawing.Point(15, 111);
            this.B.Maximum = 64;
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(300, 20);
            this.B.TabIndex = 2;
            this.B.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip.SetToolTip(this.B, "Blue");
            // 
            // G
            // 
            this.G.AutoSize = false;
            this.G.Location = new System.Drawing.Point(15, 80);
            this.G.Maximum = 64;
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(300, 20);
            this.G.TabIndex = 1;
            this.G.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip.SetToolTip(this.G, "Green");
            // 
            // RefreshRate
            // 
            this.RefreshRate.Tick += new System.EventHandler(this.Refresh_Tick);
            // 
            // Pulse
            // 
            this.Pulse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pulse.FlatAppearance.BorderSize = 0;
            this.Pulse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pulse.Font = new System.Drawing.Font("Buxton Sketch", 14F);
            this.Pulse.ForeColor = System.Drawing.Color.Gray;
            this.Pulse.Location = new System.Drawing.Point(0, 0);
            this.Pulse.Margin = new System.Windows.Forms.Padding(0);
            this.Pulse.Name = "Pulse";
            this.Pulse.Size = new System.Drawing.Size(176, 32);
            this.Pulse.TabIndex = 11;
            this.Pulse.Text = "Pulse";
            this.toolTip.SetToolTip(this.Pulse, "Pulse");
            this.Pulse.UseVisualStyleBackColor = true;
            this.Pulse.Click += new System.EventHandler(this.Pulse_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseForm.FlatAppearance.BorderSize = 0;
            this.CloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseForm.Font = new System.Drawing.Font("Broadway", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.ForeColor = System.Drawing.Color.DodgerBlue;
            this.CloseForm.Location = new System.Drawing.Point(329, 0);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(24, 24);
            this.CloseForm.TabIndex = 0;
            this.CloseForm.TabStop = false;
            this.CloseForm.Text = "X";
            this.toolTip.SetToolTip(this.CloseForm, "Close");
            this.CloseForm.UseVisualStyleBackColor = true;
            this.CloseForm.Click += new System.EventHandler(this.Close_Click);
            // 
            // Panel
            // 
            this.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel.Controls.Add(this.mailCheckInterval);
            this.Panel.Controls.Add(this.lblLastUnreadNum);
            this.Panel.Controls.Add(this.lblTotalUnreadNum);
            this.Panel.Controls.Add(this.GmailLabel);
            this.Panel.Controls.Add(this.EnableUnreadCount);
            this.Panel.Controls.Add(this.CheckNow);
            this.Panel.Controls.Add(this.SaveLogin);
            this.Panel.Controls.Add(this.txtUserPassword);
            this.Panel.Controls.Add(this.txtUserName);
            this.Panel.Controls.Add(this.lblNewUnreadMailCount);
            this.Panel.Controls.Add(this.lblTotalUnreadMailCount);
            this.Panel.Controls.Add(this.MoveForm);
            this.Panel.Controls.Add(this.SpeedLabel);
            this.Panel.Controls.Add(this.Speed);
            this.Panel.Controls.Add(this.ModeLabel);
            this.Panel.Controls.Add(this.ModeBox);
            this.Panel.Controls.Add(this.usbStatus);
            this.Panel.Controls.Add(this.Table);
            this.Panel.Controls.Add(this.labelB);
            this.Panel.Controls.Add(this.labelG);
            this.Panel.Controls.Add(this.labelR);
            this.Panel.Controls.Add(this.TitleLabel);
            this.Panel.Controls.Add(this.HideForm);
            this.Panel.Controls.Add(this.R);
            this.Panel.Controls.Add(this.CloseForm);
            this.Panel.Controls.Add(this.B);
            this.Panel.Controls.Add(this.G);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(355, 325);
            this.Panel.TabIndex = 0;
            // 
            // GmailLabel
            // 
            this.GmailLabel.AutoSize = true;
            this.GmailLabel.Font = new System.Drawing.Font("Britannic Bold", 14F);
            this.GmailLabel.Location = new System.Drawing.Point(14, 204);
            this.GmailLabel.Name = "GmailLabel";
            this.GmailLabel.Size = new System.Drawing.Size(179, 21);
            this.GmailLabel.TabIndex = 0;
            this.GmailLabel.Text = "Gmail Unread Count";
            // 
            // EnableUnreadCount
            // 
            this.EnableUnreadCount.AutoSize = true;
            this.EnableUnreadCount.Location = new System.Drawing.Point(215, 208);
            this.EnableUnreadCount.Name = "EnableUnreadCount";
            this.EnableUnreadCount.Size = new System.Drawing.Size(59, 17);
            this.EnableUnreadCount.TabIndex = 5;
            this.EnableUnreadCount.Text = "Enable";
            this.toolTip.SetToolTip(this.EnableUnreadCount, "Enable");
            this.EnableUnreadCount.UseVisualStyleBackColor = true;
            this.EnableUnreadCount.CheckedChanged += new System.EventHandler(this.EnableUnreadCount_CheckedChanged);
            // 
            // CheckNow
            // 
            this.CheckNow.Font = new System.Drawing.Font("Buxton Sketch", 10F);
            this.CheckNow.Location = new System.Drawing.Point(133, 256);
            this.CheckNow.Name = "CheckNow";
            this.CheckNow.Size = new System.Drawing.Size(75, 25);
            this.CheckNow.TabIndex = 10;
            this.CheckNow.Text = "Check";
            this.toolTip.SetToolTip(this.CheckNow, "Check");
            this.CheckNow.UseVisualStyleBackColor = true;
            this.CheckNow.Click += new System.EventHandler(this.CheckNow_Click);
            // 
            // SaveLogin
            // 
            this.SaveLogin.Font = new System.Drawing.Font("Buxton Sketch", 10F);
            this.SaveLogin.Location = new System.Drawing.Point(133, 228);
            this.SaveLogin.Name = "SaveLogin";
            this.SaveLogin.Size = new System.Drawing.Size(75, 25);
            this.SaveLogin.TabIndex = 9;
            this.SaveLogin.Text = "Save";
            this.toolTip.SetToolTip(this.SaveLogin, "Save");
            this.SaveLogin.UseVisualStyleBackColor = true;
            this.SaveLogin.Click += new System.EventHandler(this.SaveLogin_Click);
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserPassword.Font = new System.Drawing.Font("Buxton Sketch", 10F);
            this.txtUserPassword.Location = new System.Drawing.Point(18, 257);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = 'o';
            this.txtUserPassword.Size = new System.Drawing.Size(100, 24);
            this.txtUserPassword.TabIndex = 8;
            this.toolTip.SetToolTip(this.txtUserPassword, "Password");
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.Font = new System.Drawing.Font("Buxton Sketch", 10F);
            this.txtUserName.Location = new System.Drawing.Point(18, 229);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 24);
            this.txtUserName.TabIndex = 7;
            this.toolTip.SetToolTip(this.txtUserName, "Login");
            // 
            // lblNewUnreadMailCount
            // 
            this.lblNewUnreadMailCount.Font = new System.Drawing.Font("Buxton Sketch", 10F);
            this.lblNewUnreadMailCount.Location = new System.Drawing.Point(214, 260);
            this.lblNewUnreadMailCount.Name = "lblNewUnreadMailCount";
            this.lblNewUnreadMailCount.Size = new System.Drawing.Size(115, 21);
            this.lblNewUnreadMailCount.TabIndex = 0;
            this.lblNewUnreadMailCount.Text = "Last Unread Count:";
            // 
            // lblTotalUnreadMailCount
            // 
            this.lblTotalUnreadMailCount.Font = new System.Drawing.Font("Buxton Sketch", 10F);
            this.lblTotalUnreadMailCount.Location = new System.Drawing.Point(214, 232);
            this.lblTotalUnreadMailCount.Name = "lblTotalUnreadMailCount";
            this.lblTotalUnreadMailCount.Size = new System.Drawing.Size(115, 21);
            this.lblTotalUnreadMailCount.TabIndex = 0;
            this.lblTotalUnreadMailCount.Text = "Total Unread Count:";
            // 
            // MoveForm
            // 
            this.MoveForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveForm.FlatAppearance.BorderSize = 0;
            this.MoveForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveForm.Font = new System.Drawing.Font("Broadway", 9.75F, System.Drawing.FontStyle.Bold);
            this.MoveForm.ForeColor = System.Drawing.Color.DodgerBlue;
            this.MoveForm.Location = new System.Drawing.Point(280, 0);
            this.MoveForm.Name = "MoveForm";
            this.MoveForm.Size = new System.Drawing.Size(24, 24);
            this.MoveForm.TabIndex = 0;
            this.MoveForm.TabStop = false;
            this.MoveForm.Text = "+";
            this.toolTip.SetToolTip(this.MoveForm, "Move");
            this.MoveForm.UseVisualStyleBackColor = true;
            this.MoveForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Font = new System.Drawing.Font("Mistral", 12F);
            this.SpeedLabel.ForeColor = System.Drawing.Color.Black;
            this.SpeedLabel.Location = new System.Drawing.Point(321, 174);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(16, 19);
            this.SpeedLabel.TabIndex = 0;
            this.SpeedLabel.Text = "0";
            this.toolTip.SetToolTip(this.SpeedLabel, "Pulse Speed");
            // 
            // Speed
            // 
            this.Speed.AutoSize = false;
            this.Speed.Location = new System.Drawing.Point(15, 174);
            this.Speed.Maximum = 40;
            this.Speed.Minimum = 20;
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(300, 20);
            this.Speed.TabIndex = 4;
            this.Speed.TickFrequency = 200;
            this.Speed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip.SetToolTip(this.Speed, "Pulse Speed");
            this.Speed.Value = 20;
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Font = new System.Drawing.Font("Britannic Bold", 14F);
            this.ModeLabel.Location = new System.Drawing.Point(39, 142);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(109, 21);
            this.ModeLabel.TabIndex = 0;
            this.ModeLabel.Text = "Pulse Mode:";
            this.toolTip.SetToolTip(this.ModeLabel, "Pulse Mode");
            // 
            // ModeBox
            // 
            this.ModeBox.BackColor = System.Drawing.SystemColors.Window;
            this.ModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeBox.Font = new System.Drawing.Font("Buxton Sketch", 12F);
            this.ModeBox.FormattingEnabled = true;
            this.ModeBox.Items.AddRange(new object[] {
            "Monochrome",
            "Colorchanger"});
            this.ModeBox.Location = new System.Drawing.Point(150, 138);
            this.ModeBox.Name = "ModeBox";
            this.ModeBox.Size = new System.Drawing.Size(146, 28);
            this.ModeBox.TabIndex = 3;
            this.toolTip.SetToolTip(this.ModeBox, "Pulse Mode");
            // 
            // usbStatus
            // 
            this.usbStatus.Image = global::USBMailNotifierTest.Properties.Resources.usb_error;
            this.usbStatus.Location = new System.Drawing.Point(0, 0);
            this.usbStatus.Name = "usbStatus";
            this.usbStatus.Padding = new System.Windows.Forms.Padding(1);
            this.usbStatus.Size = new System.Drawing.Size(24, 24);
            this.usbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.usbStatus.TabIndex = 10;
            this.usbStatus.TabStop = false;
            this.toolTip.SetToolTip(this.usbStatus, "Status");
            this.usbStatus.Click += new System.EventHandler(this.usbStatus_Click);
            // 
            // Table
            // 
            this.Table.ColumnCount = 2;
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table.Controls.Add(this.Light, 1, 0);
            this.Table.Controls.Add(this.Pulse, 0, 0);
            this.Table.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Table.Location = new System.Drawing.Point(0, 291);
            this.Table.Name = "Table";
            this.Table.RowCount = 1;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table.Size = new System.Drawing.Size(353, 32);
            this.Table.TabIndex = 5;
            // 
            // Light
            // 
            this.Light.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Light.FlatAppearance.BorderSize = 0;
            this.Light.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Light.Font = new System.Drawing.Font("Buxton Sketch", 14F);
            this.Light.ForeColor = System.Drawing.Color.Gray;
            this.Light.Location = new System.Drawing.Point(176, 0);
            this.Light.Margin = new System.Windows.Forms.Padding(0);
            this.Light.Name = "Light";
            this.Light.Size = new System.Drawing.Size(177, 32);
            this.Light.TabIndex = 12;
            this.Light.Text = "Light";
            this.toolTip.SetToolTip(this.Light, "Light");
            this.Light.UseVisualStyleBackColor = true;
            this.Light.Click += new System.EventHandler(this.Light_Click);
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Font = new System.Drawing.Font("Mistral", 12F);
            this.labelB.ForeColor = System.Drawing.Color.Blue;
            this.labelB.Location = new System.Drawing.Point(321, 111);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(16, 19);
            this.labelB.TabIndex = 0;
            this.labelB.Text = "0";
            this.toolTip.SetToolTip(this.labelB, "Blue");
            // 
            // labelG
            // 
            this.labelG.AutoSize = true;
            this.labelG.Font = new System.Drawing.Font("Mistral", 12F);
            this.labelG.ForeColor = System.Drawing.Color.Green;
            this.labelG.Location = new System.Drawing.Point(321, 80);
            this.labelG.Name = "labelG";
            this.labelG.Size = new System.Drawing.Size(16, 19);
            this.labelG.TabIndex = 0;
            this.labelG.Text = "0";
            this.toolTip.SetToolTip(this.labelG, "Green");
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Font = new System.Drawing.Font("Mistral", 12F);
            this.labelR.ForeColor = System.Drawing.Color.Red;
            this.labelR.Location = new System.Drawing.Point(321, 49);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(16, 19);
            this.labelR.TabIndex = 0;
            this.labelR.Text = "0";
            this.toolTip.SetToolTip(this.labelR, "Red");
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Broadway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TitleLabel.Location = new System.Drawing.Point(47, 8);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(227, 27);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "LightBox Control";
            this.toolTip.SetToolTip(this.TitleLabel, "Click Me!");
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // HideForm
            // 
            this.HideForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HideForm.FlatAppearance.BorderSize = 0;
            this.HideForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HideForm.Font = new System.Drawing.Font("Broadway", 9.75F, System.Drawing.FontStyle.Bold);
            this.HideForm.ForeColor = System.Drawing.Color.DodgerBlue;
            this.HideForm.Location = new System.Drawing.Point(305, 0);
            this.HideForm.Name = "HideForm";
            this.HideForm.Size = new System.Drawing.Size(24, 24);
            this.HideForm.TabIndex = 0;
            this.HideForm.TabStop = false;
            this.HideForm.Text = "O";
            this.toolTip.SetToolTip(this.HideForm, "Hide");
            this.HideForm.UseVisualStyleBackColor = true;
            this.HideForm.Click += new System.EventHandler(this.HideForm_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "LightBox Control";
            this.TrayIcon.Click += new System.EventHandler(this.TrayIcon_Click);
            // 
            // PulseTimer
            // 
            this.PulseTimer.Interval = 1500;
            this.PulseTimer.Tick += new System.EventHandler(this.PulseTimer_Tick);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // lblTotalUnreadNum
            // 
            this.lblTotalUnreadNum.Font = new System.Drawing.Font("Buxton Sketch", 10F);
            this.lblTotalUnreadNum.Location = new System.Drawing.Point(317, 232);
            this.lblTotalUnreadNum.Name = "lblTotalUnreadNum";
            this.lblTotalUnreadNum.Size = new System.Drawing.Size(25, 20);
            this.lblTotalUnreadNum.TabIndex = 0;
            this.lblTotalUnreadNum.Text = "0";
            // 
            // lblLastUnreadNum
            // 
            this.lblLastUnreadNum.Font = new System.Drawing.Font("Buxton Sketch", 10F);
            this.lblLastUnreadNum.Location = new System.Drawing.Point(312, 260);
            this.lblLastUnreadNum.Name = "lblLastUnreadNum";
            this.lblLastUnreadNum.Size = new System.Drawing.Size(25, 20);
            this.lblLastUnreadNum.TabIndex = 0;
            this.lblLastUnreadNum.Text = "0";
            // 
            // mailCheckInterval
            // 
            this.mailCheckInterval.BackColor = System.Drawing.SystemColors.Window;
            this.mailCheckInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mailCheckInterval.Font = new System.Drawing.Font("Buxton Sketch", 10F);
            this.mailCheckInterval.FormattingEnabled = true;
            this.mailCheckInterval.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "15",
            "30",
            "60"});
            this.mailCheckInterval.Location = new System.Drawing.Point(280, 204);
            this.mailCheckInterval.Name = "mailCheckInterval";
            this.mailCheckInterval.Size = new System.Drawing.Size(47, 24);
            this.mailCheckInterval.TabIndex = 6;
            this.toolTip.SetToolTip(this.mailCheckInterval, "Interval [min]");
            this.mailCheckInterval.SelectedIndexChanged += new System.EventHandler(this.mailCheckInterval_SelectedIndexChanged);
            // 
            // MailTimer
            // 
            this.MailTimer.Interval = 60000;
            this.MailTimer.Tick += new System.EventHandler(this.MailTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 325);
            this.Controls.Add(this.Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USBMailNotiferTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G)).EndInit();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usbStatus)).EndInit();
            this.Table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar R;
        private System.Windows.Forms.TrackBar B;
        private System.Windows.Forms.TrackBar G;
        private System.Windows.Forms.Timer RefreshRate;
        private System.Windows.Forms.Button Pulse;
        private System.Windows.Forms.Button CloseForm;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.Button HideForm;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelG;
        private System.Windows.Forms.TableLayoutPanel Table;
        private System.Windows.Forms.Button Light;
        private System.Windows.Forms.PictureBox usbStatus;
        private System.Windows.Forms.Timer PulseTimer;
        private System.Windows.Forms.ComboBox ModeBox;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.TrackBar Speed;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Button MoveForm;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblTotalUnreadMailCount;
        private System.Windows.Forms.Label lblNewUnreadMailCount;
        private System.Windows.Forms.CheckBox EnableUnreadCount;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button CheckNow;
        private System.Windows.Forms.Button SaveLogin;
        private System.Windows.Forms.Label GmailLabel;
        private System.Windows.Forms.Label lblLastUnreadNum;
        private System.Windows.Forms.Label lblTotalUnreadNum;
        private System.Windows.Forms.ComboBox mailCheckInterval;
        private System.Windows.Forms.Timer MailTimer;
    }
}

