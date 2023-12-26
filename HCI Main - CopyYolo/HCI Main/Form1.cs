using HCI_Main.TUIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HCI_Main
{
    public partial class Form1 : Form
    {
        public static ClientC c = new ClientC();
        LoginCheck lgin = new LoginCheck();
        FaceRec2 face = new FaceRec2();
        Timer tt = new Timer();
        int ct = 0;
        int count = 0;
        int count2 = 0;
        public Form1()
        {
            InitializeComponent();
            tt.Tick += Tt_Tick;
            tt.Interval = 2000;
            tt.Start();
            //c.connectToSocket("localhost", 3344);
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            if (face.check == true && ct==0)
            {
                ct++;
                face.CloseCamera();
                PieMenu f = new PieMenu();
                this.Hide();
                f.ShowDialog();
                tt.Stop();                
            }
            if(c.isConnected)
            {
                if(count2==0)
                {
                    c.recieveMessage();
                    count2++;
                }
            }
            check();
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            //lgin.LoadCredentials();
            //if (lgin.CheckCredentials(textBox1.Text, textBox2.Text))
            //{
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Sign up please");
            //}
        }
        public void check()
        {
            if (c.data == "'start'")
            {
                if (count == 0)
                {

                    Form2 f = new Form2();
                    this.Close();
                    f.ShowDialog();
                    count++;
                }

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SignUp f = new SignUp();
            this.Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            face.openCamera(pictureBox2,pictureBox3);
            face.isTrained = true;
        }
    }
}
