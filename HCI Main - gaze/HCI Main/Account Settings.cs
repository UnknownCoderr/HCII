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
    public partial class Account_Settings : Form
    {
        public Account_Settings()
        {
            InitializeComponent();
        }
        private void Display_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClassifyBTN_Click(object sender, EventArgs e)
        {
            //username
            OpenForm(new Change_Pass());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenForm(new Change_Passowrd());
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
    }
}
