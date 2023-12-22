using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace HCI_Main
{
    public partial class Assign_training : Form
    {
        public List<string> exercise = new List<string>();

        public Assign_training()
        {
            InitializeComponent();
        }


        private void Assign_training_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Swimmer1");
            comboBox1.Items.Add("Swimmer2");
            comboBox1.Items.Add("Swimmer3");
            comboBox1.Items.Add("Swimmer4");
            comboBox1.Items.Add("Swimmer5");
            comboBox1.Items.Add("Swimmer6");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label7.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label7.Text = "FreeSyle Swimming";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            label7.Text = "Backstroke Swimming";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label7.Text = "Butterfly Swimming";
        }

        private void button1_Click(object sender, EventArgs e)
        {    
            if(comboBox1.Text!="" && textBox1.Text!="" && label7.Text != "")
            {
                string fileName = "SwimmerExcercise.txt";
                string filePath = Path.Combine("D:\\HCII\\HCI Main\\HCI Main\\bin\\Debug", fileName);

                exercise.Add(comboBox1.Text + " , " + textBox1.Text + " , " + label7.Text);

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    foreach (string line in exercise)
                    {
                        writer.WriteLine(line);
                    }
                }
                MessageBox.Show("Assigned" , "Done" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fill the missing boxes ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
