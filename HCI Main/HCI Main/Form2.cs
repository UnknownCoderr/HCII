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
        int ct3 = 0;
        int ct4 = 0;

        public Form2()
        {
            InitializeComponent();
            this.Paint += Form2_Paint;
            this.Load += Form2_Load;
            tt.Tick += Tt_Tick;
            tt.Start();
            c.connectToSocket("localhost", 5000);
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
            ct3 = 0;
            ct4 = 0;
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
            ct3 = 0;
            ct4 = 0;
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
            ct3 = 0;
            ct4 = 0;
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
            string email = "ammarwael73@gmail.com";
            string mailtoUri = $"mailto:{email}";

            try
            {
                Process.Start(new ProcessStartInfo(mailtoUri));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening email client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Account_Settings f = new Account_Settings();            
            f.ShowDialog();            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Account_Settings f = new Account_Settings();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ctClassify = 0;
            ctCamera = 0;
            ct2 = 0;
            ct3 = 0;
            ct4++;
            if (ct4 == 1)
            {
                OpenForm(new View_Assigned_training());
            }
            else
            {
                MessageBox.Show("You are already in assigned training");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ctClassify = 0;
            ctCamera = 0;
            ct2 = 0;
            ct3++;
            ct4 = 0;
            if (ct3 == 1)
            {
                OpenForm(new Add_swimmer());
            }
            else
            {
                MessageBox.Show("You are already in add swimmer form");
            }
        }
    }
}
