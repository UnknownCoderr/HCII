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
        public List<string> swimmers = new List<string>();
        public Add_swimmer()
        {
            InitializeComponent();
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
