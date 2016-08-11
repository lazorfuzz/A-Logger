using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Fun_Logger
{
    public partial class emailForm : Form
    {
        public emailForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.arclab.com/products/amlc/list-of-smtp-and-pop3-servers-mailserver-list.html");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void emailForm_Load(object sender, EventArgs e)
        {
            this.FormClosing += emailForm_FormClosing;
        }

        void emailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sendtest(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
        }

        void Sendtest(string username, string password, string server, string port)
        {
            //try
            //{
                NetworkCredential creds = new NetworkCredential(username, password);
                MailMessage mail = new MailMessage();
                mail.To.Add(username);
                mail.From = new MailAddress(username);
                mail.Subject = "A Logger";
                mail.Body = "SMTP settings configured successfully.";

                SmtpClient client = new SmtpClient(server, Convert.ToInt32(port));
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = creds;
                client.EnableSsl = true;
                client.Send(mail);
                GC.Collect();
                MessageBox.Show("Message sent to email. Check it to see if it worked");
            //}
            //catch { MessageBox.Show("Email failed"); }

        }
    }
}
