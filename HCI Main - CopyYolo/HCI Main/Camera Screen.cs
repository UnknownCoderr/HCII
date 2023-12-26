using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HCI_Main
{
    public partial class Camera_Screen : Form
    {
        public static ClientC c = new ClientC();
        Timer tt=new Timer();
        Bitmap off;
        int count = 0;
        int count2 = 0;
        public Camera_Screen()
        {
            InitializeComponent();
            this.Load += Camera_Screen_Load;
            tt.Tick += Tt_Tick;
            tt.Start();
            c.connectToSocket("localhost", 3344);
        }

        private void Camera_Screen_Load(object sender, EventArgs e)
        {
            this.Text = "camera screen";
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
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
            if (c.data == "'start'")
            {

                if (count == 0)
                {
                    start();
                    count++;
                }

            }
            if (c.data == "'right'")
            {
                if (count == 0)
                {
                    OpenForm(new Add_swimmer());
                    count++;
                }
            }
            if (c.data == "'left'")
            {
                if (count == 0)
                {
                    OpenForm(new Drowning_detect());
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
        void start()
        {
            string videoPath1 = "D:\\HCI\\HCI\\HCI\\Videos\\backstroke 2 .mp4";


            axWindowsMediaPlayer1.URL = videoPath1;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.settings.volume = 0;
            axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            axWindowsMediaPlayer2.URL = videoPath1;
            axWindowsMediaPlayer2.settings.setMode("loop", true);
            axWindowsMediaPlayer2.settings.volume = 0;
            axWindowsMediaPlayer2.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            axWindowsMediaPlayer3.URL = videoPath1;
            axWindowsMediaPlayer3.settings.setMode("loop", true);
            axWindowsMediaPlayer3.settings.volume = 0;
            axWindowsMediaPlayer3.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            axWindowsMediaPlayer4.URL = videoPath1;
            axWindowsMediaPlayer4.settings.setMode("loop", true);
            axWindowsMediaPlayer4.settings.volume = 0;
            axWindowsMediaPlayer4.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            axWindowsMediaPlayer5.URL = videoPath1;
            axWindowsMediaPlayer5.settings.setMode("loop", true);
            axWindowsMediaPlayer5.settings.volume = 0;
            axWindowsMediaPlayer5.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            axWindowsMediaPlayer6.URL = videoPath1;
            axWindowsMediaPlayer6.settings.setMode("loop", true);
            axWindowsMediaPlayer6.settings.volume = 0;
            axWindowsMediaPlayer6.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;
        }
        public void assign()
        {
            Assign_training f = new Assign_training();
            f.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            start();
        }

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {            
            if (e.newState == 8) 
            {                
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = 0;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assign();
        }
    }
}
