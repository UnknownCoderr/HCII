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
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                lgin.SaveCredentials(textBox1.Text, textBox2.Text);
                Form1 f = new Form1();
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please write your username and passowrd.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
