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
        public Camera_Screen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string videoPath1 = "C:\\Users\\Ammar Wael\\Desktop\\HCI\\Videos\\backstroke 2 .mp4";
            string videoPath2= "C:\\Users\\Ammar Wael\\Desktop\\HCI\\Videos\\Backstroke.mp4";
            string videoPath3 = "C:\\Users\\Ammar Wael\\Desktop\\HCI\\Videos\\Butterfly 2 .mp4";
            string videoPath4 = "C:\\Users\\Ammar Wael\\Desktop\\HCI\\Videos\\Butterfly.mp4"; 
            string videoPath5 = "C:\\Users\\Ammar Wael\\Desktop\\HCI\\Videos\\Freestyle.mp4";
            string videoPath6 = "C:\\Users\\Ammar Wael\\Desktop\\HCI\\Videos\\swim (3).mp4";

            axWindowsMediaPlayer1.URL = videoPath1;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.settings.volume = 0;
            axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            axWindowsMediaPlayer2.URL = videoPath2;
            axWindowsMediaPlayer2.settings.setMode("loop", true);
            axWindowsMediaPlayer2.settings.volume = 0;
            axWindowsMediaPlayer2.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            axWindowsMediaPlayer3.URL = videoPath3;
            axWindowsMediaPlayer3.settings.setMode("loop", true);
            axWindowsMediaPlayer3.settings.volume = 0;
            axWindowsMediaPlayer3.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            axWindowsMediaPlayer4.URL = videoPath4;
            axWindowsMediaPlayer4.settings.setMode("loop", true);
            axWindowsMediaPlayer4.settings.volume = 0;
            axWindowsMediaPlayer4.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            axWindowsMediaPlayer5.URL = videoPath5;
            axWindowsMediaPlayer5.settings.setMode("loop", true);
            axWindowsMediaPlayer5.settings.volume = 0;
            axWindowsMediaPlayer5.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            axWindowsMediaPlayer6.URL = videoPath6;
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
