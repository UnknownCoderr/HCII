using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HCI_Main
{
    public partial class View_Assigned_training : Form
    {
        public View_Assigned_training()
        {
            InitializeComponent();
        }

        private void View_Assigned_training_Load(object sender, EventArgs e)
        {
            string filePath = "D:\\HCII\\HCI Main\\HCI Main\\bin\\Debug\\SwimmerExcercise.txt";
            
            try
            {                
                string fileContent = File.ReadAllText(filePath);                
                label1.Text = fileContent;
            }
            catch (Exception ex)
            {                
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
