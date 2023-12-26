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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HCI_Main
{
    public partial class View_Assigned_training : Form
    {
        public static ClientC c = new ClientC();
        Timer tt = new Timer();
        int count = 0;
        int count2 = 0;
        public View_Assigned_training()
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
            if (c.data == "'right'")
            {
                if (count == 0)
                {
                    OpenForm(new Camera_Screen());
                    count++;
                }
            }
            if (c.data == "'left'")
            {
                if (count == 0)
                {
                    OpenForm(new Add_swimmer());
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
        private void View_Assigned_training_Load(object sender, EventArgs e)
        {
            string filePath = "D:\\HCI\\HCII\\HCI Main - CopyYolo\\HCI Main\\bin\\Debug\\SwimmerExcercise.txt";
            
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
