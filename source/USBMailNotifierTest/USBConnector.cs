using System;
using System.Threading;
using HIDLibrary;

namespace USBMailNotifier
{
    public class USBConnector
    {
        public HidDevice hidDevice;
        private Boolean dreamCheeky = true;
        public System.Windows.Forms.Timer colortimer = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer colorchanger = new System.Windows.Forms.Timer();
        int tr = 0;
        int tg = 0;
        int tb = 0;
        int or = 0;
        int og = 0;
        int ob = 0;
        int iu = 0;
        int id = 62;
        string lastcolor = "red";

        public USBConnector()
        {
            Connect();
            colortimer.Tick += new EventHandler(colortimer_Tick);
            colortimer.Interval = 20;
            colorchanger.Tick += new EventHandler(colorchanger_Tick);
            colorchanger.Interval = 20;
        }

        public void IntervalChange(int duration)
        {
            colortimer.Interval = duration;
            colorchanger.Interval = duration;
        }

        public void Connect()
        {
            HIDLibrary.HidDevice[] hidDeviceList = HidDevices.Enumerate(0x1D34, 0x0004);
            if (hidDeviceList.Length == 0)
            {
                hidDeviceList = HidDevices.Enumerate(0x1294, 0x1320);
                if (hidDeviceList.Length > 0)
                {
                    dreamCheeky = false;
                }
            }
            if (hidDeviceList.Length > 0)
            {
                hidDevice = hidDeviceList[0];
                hidDevice.Open();
                while (!hidDevice.IsConnected || !hidDevice.IsOpen) { }
                if (dreamCheeky)
                {
                    hidDevice.Write(new byte[9] { 0x00, 0x1F, 0x01, 0x29, 0x00, 0xB8, 0x54, 0x2C, 0x03 });
                    hidDevice.Write(new byte[9] { 0x00, 0x00, 0x01, 0x29, 0x00, 0xB8, 0x54, 0x2C, 0x04 });
                }
            }
            SetRGB(0x00, 0x00, 0x00);
        }

        public void SetRGB(byte r, byte g, byte b)
        {
            if (hidDevice != null)
            {
                if (dreamCheeky)
                {
                    hidDevice.Write(new byte[9] { 0x00, r, g, b, 0x00, 0x00, 0x54, 0x2C, 0x05 });
                }
                else
                {
                    if (r == 0x00 && g == 0x00 && b == 0x00)
                    {
                        hidDevice.Write(new byte[6] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                    }
                    if (r > 0x00 && g == 0x00 && b == 0x00)
                    {
                        hidDevice.Write(new byte[6] { 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 });
                    }
                    if (r == 0x00 && g > 0x00 && b == 0x00)
                    {
                        hidDevice.Write(new byte[6] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 });
                    }
                    if (r == 0x00 && g == 0x00 && b > 0x00)
                    {
                        hidDevice.Write(new byte[6] { 0x00, 0x03, 0x00, 0x00, 0x00, 0x00 });
                    }
                    if (r > 0x00 && g > 0x00 && b == 0x00)
                    {
                        hidDevice.Write(new byte[6] { 0x00, 0x05, 0x00, 0x00, 0x00, 0x00 });
                    }
                    if (r > 0x00 && g == 0x00 && b > 0x00)
                    {
                        hidDevice.Write(new byte[6] { 0x00, 0x06, 0x00, 0x00, 0x00, 0x00 });
                    }
                    if (r == 0x00 && g > 0x00 && b > 0x00)
                    {
                        hidDevice.Write(new byte[6] { 0x00, 0x04, 0x00, 0x00, 0x00, 0x00 });
                    }
                    if (r > 0x00 && g > 0x00 && b > 0x00)
                    {
                        hidDevice.Write(new byte[6] { 0x00, 0x07, 0x00, 0x00, 0x00, 0x00 });
                    }
                }
            }            
        }

        public void PulseMono(byte r, byte g, byte b)
        {
            or = r;
            og = g;
            ob = b;
            iu = 0;
            id = 62;
            colortimer.Start();
        }

        private void colortimer_Tick(object sender, EventArgs e)
        {
            if (dreamCheeky)
            {
                if (iu < 64)
                {
                    if (iu <= or)
                        tr = iu;
                    if (iu <= og)
                        tg = iu;
                    if (iu <= ob)
                        tb = iu;
                    SetRGB((byte)tr, (byte)tg, (byte)tb);
                    iu++;
                }
                else if (id > 0)
                {
                    if (tr > id)
                        tr = id;
                    if (tg > id)
                        tg = id;
                    if (tb > id)
                        tb = id;
                    SetRGB((byte)tr, (byte)tg, (byte)tb);
                    id--;
                }
            }
            else
            {
                SetRGB(0x00, 0x00, 0x01);
                Thread.Sleep(1000);
                SetRGB(0x00, 0x00, 0x00);
                Thread.Sleep(500);
            }
            if (id == 0)
            {
                SetRGB(0x00, 0x00, 0x00);
                colortimer.Stop();
            }
        }

        public void PulseChanger()
        {
            iu = 0;
            id = 62;
            if (lastcolor == "red")
            {
                or = 64;
                og = 0;
                ob = 64;
                lastcolor = "violet";
            }
            else if (lastcolor == "violet")
            {
                or = 0;
                og = 0;
                ob = 64;
                lastcolor = "blue";
            }
            else if (lastcolor == "blue")
            {
                or = 0;
                og = 64;
                ob = 64;
                lastcolor = "cyan";
            }
            else if (lastcolor == "cyan")
            {
                or = 0;
                og = 64;
                ob = 0;
                lastcolor = "green";
            }
            else if (lastcolor == "green")
            {
                or = 64;
                og = 64;
                ob = 0;
                lastcolor = "yellow";
            }
            else if (lastcolor == "yellow")
            {
                or = 64;
                og = 0;
                ob = 0;
                lastcolor = "red";
            }
            colorchanger.Start();
        }

        private void colorchanger_Tick(object sender, EventArgs e)
        {
            if (dreamCheeky)
            {
                if (iu < 64)
                {
                    if (iu <= or)
                        tr = iu;
                    if (iu <= og)
                        tg = iu;
                    if (iu <= ob)
                        tb = iu;
                    SetRGB((byte)tr, (byte)tg, (byte)tb);
                    iu++;
                }
                else if (id > 0)
                {
                    if (tr > id)
                        tr = id;
                    if (tg > id)
                        tg = id;
                    if (tb > id)
                        tb = id;
                    SetRGB((byte)tr, (byte)tg, (byte)tb);
                    id--;
                }
            }
            else
            {
                SetRGB(0x00, 0x00, 0x01);
                Thread.Sleep(1000);
                SetRGB(0x00, 0x00, 0x00);
                Thread.Sleep(500);
            }
            if (id == 0)
            {
                SetRGB(0x00, 0x00, 0x00);
                colorchanger.Stop();
            }
        }

        public void PulseRGB(int n, byte r, byte g, byte b)
        {
            int j = 0;
            while (j < n)
            {
                if (dreamCheeky)
                {
                    for (int i = 0; i < 64; i++)
                    {
                        if (i <= r)
                            tr = i;
                        if (i <= g)
                            tg = i;
                        if (i <= b)
                            tb = i;
                        SetRGB((byte)tr, (byte)tg, (byte)tb);
                        Thread.Sleep(5);
                    }
                    for (int i = 62; i >= 0; i--)
                    {
                        if (tr > i)
                            tr = i;
                        if (tg > i)
                            tg = i;
                        if (tb > i)
                            tb = i;
                        SetRGB((byte)tr, (byte)tg, (byte)tb);
                        Thread.Sleep(5);
                    }
                }
                else
                {
                    SetRGB(0x00, 0x00, 0x01);
                    Thread.Sleep(1000);
                    SetRGB(0x00, 0x00, 0x00);
                    Thread.Sleep(500);
                }
                j++;
            }
        }
    }
}
