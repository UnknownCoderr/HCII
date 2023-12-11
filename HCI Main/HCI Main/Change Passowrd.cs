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
    public partial class Change_Passowrd : Form
    {
        LoginCheck lgin = new LoginCheck();
        public Change_Passowrd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lgin.LoadCredentials();
            lgin.ChangePassword(textBox1.Text, textBox2.Text);
        }
    }
}
