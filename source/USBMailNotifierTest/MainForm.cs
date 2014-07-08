using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using USBMailNotifier;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Net;
using System.IO;
using System.Xml;
using Ini;
using System.Security.Cryptography;

namespace USBMailNotifierTest
{
    public partial class MainForm : Form
    {
        private USBConnector usb = null;
        private bool light = false;
        private bool pulse = false;
        IniFile ini;

        public MainForm()
        {
            InitializeComponent();
            try
            {
                this.usb = new USBConnector();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            this.RefreshRate.Interval = 10;
            try
            {
                if (this.usb.hidDevice.IsOpen)
                {
                    usbStatus.Image = Properties.Resources.usb_ok;
                    this.RefreshRate.Start();
                }
            }
            catch
            {
                MessageBox.Show("Could not connect to device!\nClick status icon to reconnect!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Environment.Exit(0);
            }
            this.ModeBox.SelectedIndex = 0;
            this.mailCheckInterval.SelectedIndex = 0;
            try
            {
                if (!File.Exists(Application.StartupPath + "\\Settings.ini"))
                {
                    ini = new IniFile(Application.StartupPath + "\\Settings.ini");
                }
                else
                {
                    ini = new IniFile(Application.StartupPath + "\\Settings.ini");
                    if (ini.IniReadValue("Settings", "User") != string.Empty)
                        txtUserName.Text = Decrypt(ini.IniReadValue("Settings", "User"), true);
                    if (ini.IniReadValue("Settings", "Pass") != string.Empty)
                        txtUserPassword.Text = Decrypt(ini.IniReadValue("Settings", "Pass"), true);
                    if (ini.IniReadValue("Settings", "R") != string.Empty)
                        R.Value = Convert.ToInt32(ini.IniReadValue("Settings", "R"));
                    if (ini.IniReadValue("Settings", "G") != string.Empty)
                        G.Value = Convert.ToInt32(ini.IniReadValue("Settings", "G"));
                    if (ini.IniReadValue("Settings", "B") != string.Empty)
                        B.Value = Convert.ToInt32(ini.IniReadValue("Settings", "B"));
                    if (ini.IniReadValue("Settings", "Speed") != string.Empty)
                        Speed.Value = Convert.ToInt32(ini.IniReadValue("Settings", "Speed"));
                    if (ini.IniReadValue("Settings", "PulseMode") != string.Empty)
                        ModeBox.SelectedIndex = Convert.ToInt32(ini.IniReadValue("Settings", "PulseMode"));
                    if (ini.IniReadValue("Settings", "MailInterval") != string.Empty)
                        mailCheckInterval.SelectedIndex = Convert.ToInt32(ini.IniReadValue("Settings", "MailInterval"));
                    if (ini.IniReadValue("Settings", "UnreadCount") != string.Empty)
                        EnableUnreadCount.Checked = Convert.ToBoolean(ini.IniReadValue("Settings", "UnreadCount"));
                }
            }
            catch
            {
                MessageBox.Show("Settings read error!\nCheck settings file!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            if (!this.usb.hidDevice.IsOpen)
            {
                usbStatus.Image = Properties.Resources.usb_error;
                if (RefreshRate.Enabled)
                    this.RefreshRate.Stop();
            }
            this.labelR.Text = this.R.Value.ToString();
            this.labelG.Text = this.G.Value.ToString();
            this.labelB.Text = this.B.Value.ToString();
            this.SpeedLabel.Text = this.Speed.Value.ToString();
            if (this.PulseTimer.Interval != Speed.Value * 200 && this.PulseTimer.Interval != 1)
            {
                this.PulseTimer.Interval = Speed.Value * 200;
                usb.IntervalChange(Speed.Value);
            }
            if (light)
            {
                byte r = (byte)this.R.Value;
                byte g = (byte)this.G.Value;
                byte b = (byte)this.B.Value;
                if (this.usb != null)
                    this.usb.SetRGB(r, g, b);
            }
            else if (!pulse)
            {
                if (this.usb != null)
                    this.usb.SetRGB(0x00, 0x00, 0x00);
            }
            try
            {
                if (EnableUnreadCount.Checked && Convert.ToInt64(lblTotalUnreadNum.Text) > 0 && !PulseTimer.Enabled)
                {
                    Pulse.Enabled = true;
                    Pulse.PerformClick();
                    Pulse.Enabled = false;
                }
                else if (EnableUnreadCount.Checked && Convert.ToInt64(lblTotalUnreadNum.Text) == 0 && PulseTimer.Enabled)
                {
                    Pulse.Enabled = true;
                    Pulse.PerformClick();
                    Pulse.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void EnableUnreadCount_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableUnreadCount.Checked)
            {
                pulse = true;
                Pulse.ForeColor = Color.DodgerBlue;
                Pulse.Enabled = false;
                light = false;
                Light.ForeColor = Color.Gray;
                Light.Enabled = false;
                if (PulseTimer.Enabled)
                    PulseTimer.Stop();
                if (!MailTimer.Enabled)
                    MailTimer.Start();
            }
            else
            {
                pulse = false;
                Pulse.ForeColor = Color.Gray;
                Pulse.Enabled = true;
                light = false;
                Light.ForeColor = Color.Gray;
                Light.Enabled = true;
                if (usb.colortimer.Enabled)
                    usb.colortimer.Stop();
                if (usb.colorchanger.Enabled)
                    usb.colorchanger.Stop();
                if (PulseTimer.Enabled)
                    PulseTimer.Stop();
                if (MailTimer.Enabled)
                    MailTimer.Stop();
            }
        }

        private void mailCheckInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            MailTimer.Interval = Convert.ToInt32(mailCheckInterval.Text) * 60000;
        }

        private void MailTimer_Tick(object sender, EventArgs e)
        {
            CheckMail();
        }

        private void CheckMail()
        {
            try
            {
                int NewUnreadMail = 0;
                DateTime LastUnreadMailDate = DateTime.MinValue;
                Collection<UnreadMails> clUnreadMails = GetNewMails();
                for (int i = 0; i < clUnreadMails.Count; i++)
                {
                    if (clUnreadMails[i].MailModify > LastCheck)
                    {
                        NewUnreadMail++;
                    }
                    if (clUnreadMails[i].MailModify > LastUnreadMailDate)
                        LastUnreadMailDate = clUnreadMails[i].MailModify;
                }
                LastCheck = LastUnreadMailDate;
                lblTotalUnreadNum.Text = clUnreadMails.Count.ToString();
                lblLastUnreadNum.Text = NewUnreadMail.ToString();
            }
            catch
            {
                if (MailTimer.Enabled)
                    MailTimer.Stop();
                MessageBox.Show("Error retrieving unread count!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        struct UnreadMails
        {
            public string From { get; set; }
            public string Subject { get; set; }
            public DateTime MailModify { get; set; }
        }

        DateTime LastCheck = DateTime.MinValue;
        Collection<UnreadMails> GetNewMails()
        {
            WebRequest webGmailRequest = WebRequest.Create(@"https://mail.google.com/mail/feed/atom");
            webGmailRequest.PreAuthenticate = true;

            NetworkCredential loginCredentials = new NetworkCredential(txtUserName.Text.Trim(), txtUserPassword.Text.Trim());
            webGmailRequest.Credentials = loginCredentials;

            WebResponse webGmailResponse = webGmailRequest.GetResponse();
            Stream strmUnreadMailInfo = webGmailResponse.GetResponseStream();

            StringBuilder sbUnreadMailInfo = new StringBuilder(); byte[] buffer = new byte[8192]; int byteCount = 0;

            while ((byteCount = strmUnreadMailInfo.Read(buffer, 0, buffer.Length)) > 0)
                sbUnreadMailInfo.Append(System.Text.Encoding.ASCII.GetString(buffer, 0, byteCount));

            XmlDocument UnreadMailXmlDoc = new XmlDocument();
            UnreadMailXmlDoc.LoadXml(sbUnreadMailInfo.ToString());
            XmlNodeList UnreadMailEntries = UnreadMailXmlDoc.GetElementsByTagName("entry");

            UnreadMails oUnreadMails = new UnreadMails();
            Collection<UnreadMails> clUnreadMails = new Collection<UnreadMails>();

            for (int _i = 0; _i < UnreadMailEntries.Count; ++_i)
            {
                oUnreadMails.Subject = (UnreadMailEntries[_i]["title"]).InnerText;
                oUnreadMails.From = (UnreadMailEntries[_i]["author"])["name"].InnerText + " <" + (UnreadMailEntries[_i]["author"])["email"].InnerText + ">";
                oUnreadMails.MailModify = DateTime.Parse((UnreadMailEntries[_i]["modified"]).InnerText);
                clUnreadMails.Add(oUnreadMails);
            }
            return clUnreadMails;
        }

        private void SaveLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ini.IniWriteValue("Settings", "User", Encrypt(txtUserName.Text, true));
                ini.IniWriteValue("Settings", "Pass", Encrypt(txtUserPassword.Text, true));
            }
            catch
            {
                MessageBox.Show("Error saving user data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckNow_Click(object sender, EventArgs e)
        {
            CheckMail();
        }

        private void Pulse_Click(object sender, EventArgs e)
        {
            pulse = !pulse;
            if (pulse)
            {
                Pulse.ForeColor = Color.DodgerBlue;
                if (this.ModeBox.SelectedIndex == 0)
                    PulseTimer.Interval = 1;
                if (this.ModeBox.SelectedIndex == 1)
                    PulseTimer.Interval = 1;
                PulseTimer.Start();
                light = false;
                Light.ForeColor = Color.Gray;
            }
            else
            {
                Pulse.ForeColor = Color.Gray;
                if (usb.colortimer.Enabled)
                    usb.colortimer.Stop();
                if (usb.colorchanger.Enabled)
                    usb.colorchanger.Stop();
                if (PulseTimer.Enabled)
                    PulseTimer.Stop();
            }
        }

        private void PulseTimer_Tick(object sender, EventArgs e)
        {
            light = false;
            Light.ForeColor = Color.Gray;
            this.labelR.Text = this.R.Value.ToString();
            this.labelG.Text = this.G.Value.ToString();
            this.labelB.Text = this.B.Value.ToString();
            byte r = (byte)this.R.Value;
            byte g = (byte)this.G.Value;
            byte b = (byte)this.B.Value;
            if (this.usb != null)
            {
                if (ModeBox.SelectedIndex == 0)
                    this.usb.PulseMono(r, g, b);
                if (ModeBox.SelectedIndex == 1)
                    this.usb.PulseChanger();
            }
            if (PulseTimer.Interval == 1)
                PulseTimer.Interval = Speed.Value * 200;
        }

        private void Light_Click(object sender, EventArgs e)
        {
            light = !light;
            if (light)
            {
                Light.ForeColor = Color.DodgerBlue;
                if (PulseTimer.Enabled)
                    PulseTimer.Stop();
                if (usb.colortimer.Enabled)
                    usb.colortimer.Stop();
                if (usb.colorchanger.Enabled)
                    usb.colorchanger.Stop();
                pulse = false;
                Pulse.ForeColor = Color.Gray;
            }
            else
                Light.ForeColor = Color.Gray;
        }

        private void usbStatus_Click(object sender, EventArgs e)
        {
            try
            {
                this.usb.Connect();
                if (usb.hidDevice.IsOpen)
                {
                    usbStatus.Image = Properties.Resources.usb_ok;
                    if (!RefreshRate.Enabled)
                        RefreshRate.Start();
                    MessageBox.Show("Connection established!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Could not connect to device!\nClick status icon to reconnect!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Could not connect to device!\nClick status icon to reconnect!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (RefreshRate.Enabled)
                    RefreshRate.Stop();
            }
        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright © jeusnik.com", "Copyright", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void HideForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrayIcon.Visible = true;
        }

        private void TrayIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            TrayIcon.Visible = false;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ini.IniWriteValue("Settings", "R", R.Value.ToString());
                ini.IniWriteValue("Settings", "G", G.Value.ToString());
                ini.IniWriteValue("Settings", "B", B.Value.ToString());
                ini.IniWriteValue("Settings", "Speed", Speed.Value.ToString());
                ini.IniWriteValue("Settings", "PulseMode", ModeBox.SelectedIndex.ToString());
                ini.IniWriteValue("Settings", "MailInterval", mailCheckInterval.SelectedIndex.ToString());
                ini.IniWriteValue("Settings", "UnreadCount", EnableUnreadCount.Checked.ToString());
            }
            catch
            {
            }
            this.R.Value = 0;
            this.G.Value = 0;
            this.B.Value = 0;
            byte r = (byte)this.R.Value;
            byte g = (byte)this.G.Value;
            byte b = (byte)this.B.Value;
            if (this.usb != null)
                this.usb.SetRGB(r, g, b);
        }

        public static string Encrypt(string ToEncrypt, bool useHasing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(ToEncrypt);
            string Key = "y68V.\"9@$2}+";
            if (useHasing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(Key);
            }
            TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
            tDes.Key = keyArray;
            tDes.Mode = CipherMode.ECB;
            tDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tDes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tDes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cypherString, bool useHasing)
        {
            byte[] keyArray;
            byte[] toDecryptArray = Convert.FromBase64String(cypherString);
            string Key = "y68V.\"9@$2}+";
            if (useHasing)
            {
                MD5CryptoServiceProvider hashmd = new MD5CryptoServiceProvider();
                keyArray = hashmd.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                hashmd.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(Key);
            }
            TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
            tDes.Key = keyArray;
            tDes.Mode = CipherMode.ECB;
            tDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tDes.CreateDecryptor();
            try
            {
                byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);

                tDes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
