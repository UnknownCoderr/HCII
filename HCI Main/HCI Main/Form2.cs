using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HCI_Main
{
    public partial class Form2 : Form
    {
        public static ClientC c = new ClientC();
        Bitmap off;
        Timer tt = new Timer();
        int ctClassify = 0;
        int ctCamera = 0;
        int ct2 = 0;

        public Form2()
        {
            InitializeComponent();
            this.Paint += Form2_Paint;
            this.Load += Form2_Load;
            tt.Tick += Tt_Tick;
            tt.Start();
            c.connectToSocket("localhost", 9000);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Swimming system";
            if (c.isConnected)
            {
                c.recieveMessage();
            }
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            DrawScene(e.Graphics);
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
        }

        private void OpenForm(Form NewForm)
        {
            NewForm.TopLevel = false;
            NewForm.FormBorderStyle = FormBorderStyle.None;
            NewForm.Dock = DockStyle.Fill;
            this.Display.Controls.Add(NewForm);
            this.Display.Tag = NewForm;
            NewForm.BringToFront();
            NewForm.Show();
        }       

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            SolidBrush brs = new SolidBrush(Color.Red);
        }


        private void ClassifyBTN_Click_1(object sender, EventArgs e)
        {
            ct2 = 0;
            ctCamera = 0;
            ctClassify++;
            if (ctClassify == 1)
            {
                OpenForm(new Swim_Classification());
            }
            else
            {
                MessageBox.Show("You are already in Classify Form");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ctClassify = 0;
            ctCamera = 0;
            ct2++;
            if (ct2 == 1)
            {
                OpenForm(new Drowning_detect());
            }
            else
            {
                MessageBox.Show("You are already in Person Detection");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ctClassify = 0;
            ct2 = 0;
            ctCamera++;
            if (ctCamera == 1)
            {
                OpenForm(new Camera_Screen());
            }
            else
            {
                MessageBox.Show("You are already in Camera Screen");
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://mail.google.com/");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Account_Settings f = new Account_Settings();            
            f.ShowDialog();            
        }
    }
}
