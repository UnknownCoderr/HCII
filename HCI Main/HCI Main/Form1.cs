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
    public partial class Form1 : Form
    {
        LoginCheck lgin = new LoginCheck();
        public Form1()
        {
            InitializeComponent();            
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            SignUp f = new SignUp();
            this.Hide();
            f.ShowDialog();
        }
    }
}
