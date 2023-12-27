using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCI_Main
{
    public partial class SignUp : Form
    {
        LoginCheck lgin = new LoginCheck();
        int ct1 = 0, ct2 = 0, ct3 = 0;
        FaceRec2 face = new FaceRec2();
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                face.CloseCamera();
                lgin.SaveCredentials(textBox1.Text, textBox2.Text);
                face.Save_IMAGE(textBox1.Text);
                MessageBox.Show("SignedUp", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 f = new Form1();
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please write your username and passowrd.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            face.openCamera(pictureBox1, pictureBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            face.CloseCamera();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
            Application.Exit();
        }
    }
}
