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
    public partial class Camera_Screen : Form
    {
        public static ClientC c = new ClientC();
        public Camera_Screen()
        {
            InitializeComponent();
            c.connectToSocket("localhost", 3333);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string videoPath1 = "D:\\HCI\\HCI\\HCI\\Videos\backstroke 2 .mp4";
            

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
            Assign_training f = new Assign_training();
            f.ShowDialog();
        }
    }
}
