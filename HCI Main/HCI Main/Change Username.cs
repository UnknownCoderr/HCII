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
    public partial class Change_Pass : Form
    {
        LoginCheck lgin = new LoginCheck();
        public Change_Pass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            lgin.LoadCredentials();            
            lgin.ChangeUsername(textBox1.Text, textBox2.Text);
        }
    }
}
