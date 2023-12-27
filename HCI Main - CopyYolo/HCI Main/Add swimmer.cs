using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HCI_Main
{
    public partial class Add_swimmer : Form
    {
        public static ClientC c = new ClientC();
        Timer tt=new Timer();
        int count = 0;
        int count2 = 0;
        public List<string> swimmers = new List<string>();
        public Add_swimmer()
        {
            InitializeComponent();
            tt.Tick += Tt_Tick;    
            tt.Start();
            c.connectToSocket("localhost", 3344);
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            if (c.isConnected)
            {
                if (count2 == 0)
                {
                    c.recieveMessage();
                    count2++;
                }

                check();
            }
        }
        public void check()
        {
            if (c.data == "'left'")
            {
                if (count == 0)
                {
                    OpenForm(new Form2());
                    count++;
                }
            }
        }
        private void OpenForm(Form NewForm)
        {
            NewForm.TopLevel = false;
            NewForm.FormBorderStyle = FormBorderStyle.None;
            NewForm.Dock = DockStyle.Fill;
            //this.Display.Controls.Add(NewForm);
            //this.Display.Tag = NewForm;
            NewForm.BringToFront();
            NewForm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text != "")
            {
                string fileName = "Swimmers.txt";
                string filePath = Path.Combine("D:\\HCII\\HCI Main\\HCI Main\\bin\\Debug", fileName);

                swimmers.Add(textBox1.Text + " , " + textBox2.Text);

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    foreach (string line in swimmers)
                    {
                        writer.WriteLine(line);
                    }
                }
                MessageBox.Show("Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fill the missing boxes ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
