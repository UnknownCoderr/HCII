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
            string videoPath = "D:\\HCI\\HCI---project2\\v1.mp4";

            axWindowsMediaPlayer1.URL = videoPath;


            axWindowsMediaPlayer1.settings.autoStart = true;


            axWindowsMediaPlayer2.URL = videoPath;
            axWindowsMediaPlayer2.settings.autoStart = true;

            axWindowsMediaPlayer3.URL = videoPath;
            axWindowsMediaPlayer3.settings.autoStart = true;


            axWindowsMediaPlayer4.URL = videoPath;
            axWindowsMediaPlayer4.settings.autoStart = true;

            axWindowsMediaPlayer5.URL = videoPath;
            axWindowsMediaPlayer5.settings.autoStart = true;

            axWindowsMediaPlayer6.URL = videoPath;
            axWindowsMediaPlayer6.settings.autoStart = true;
        }
    }
}
