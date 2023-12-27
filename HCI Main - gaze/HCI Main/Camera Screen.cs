using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HCI_Main
{
    public partial class Camera_Screen : Form
    {
        static ClientC c = new ClientC();
        System.Windows.Forms.Timer tt = new System.Windows.Forms.Timer();

        Bitmap off;
        public Camera_Screen()
        {
            InitializeComponent();
            tt.Tick += Tt_Tick;
            tt.Start();
            c.connectToSocket("localhost",5555);
          
            this.Load += Camera_Screen_Load;
            this.Paint += Camera_Screen_Paint;

            Thread thread1 = new Thread(threadReceive);
            thread1.Start();            
            thread1.Join();
            Console.WriteLine("Main Thread: Both threads completed.");
            Console.ReadLine();
        }

        private void Camera_Screen_Paint(object sender, PaintEventArgs e)
        {
            DrawScene(e.Graphics);
        }

        private void Camera_Screen_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

      

        private void Tt_Tick(object sender, EventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }
       
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
        void DrawScene(Graphics g)
        {
            
            SolidBrush brs = new SolidBrush(Color.Red);

       
            for (int i = 0; i < c.data.Length; i++)
            {
                g.FillEllipse(brs, int.Parse(c.x), int.Parse(c.y), 20, 20);
                
            }

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
        static void threadReceive()
        {
            while (true)
            {
                c.recieveMessage();
            }
           
        }
        
    }

}

