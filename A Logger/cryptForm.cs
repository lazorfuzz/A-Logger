using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fun_Logger
{
    public partial class cryptForm : Form
    {
        public cryptForm()
        {
            InitializeComponent();
        }

        private void cryptForm_Load(object sender, EventArgs e)
        {
            initializeGUI();
        }

        void initializeGUI()
        {
            panel2.Location = new Point(138, 12);
            panel1.Visible = true;
            panel2.Visible = false;
            this.Size = new Size(150, 132);
            this.MaximumSize = new Size(322, 132);
        }

        void switchPanel(Panel p)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            p.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LicenseGlobal.Seal.Initialize("4C280000");
            label2.Text = "Welcome " + LicenseGlobal.Seal.Username;
            switchPanel(panel2);
            for (int i = 150; i < 322; i++)
            {
                this.Size = new Size(i, 132);
                System.Threading.Thread.Sleep(1);
            }
            textBox1.Text = RandomString(12);
        }

        Random Rand = new Random();
        public string RandomString(int size)
        {
            string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string final = string.Empty;
            for (int i = 0; i < size; i++)
            {
                int penis = Rand.Next(52);
                final = final + pool[penis];
            }

            return final;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switchPanel(panel1);
            for (int i = 150; i < 322; i++)
            {
                this.Size = new Size(i, 132);
                System.Threading.Thread.Sleep(1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = RandomString(12);
        }

    }
}
