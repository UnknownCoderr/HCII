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
    public partial class Swim_Classification : Form
    {
        ClientC c = new ClientC();

        public Swim_Classification()
        {
            InitializeComponent();                        
            this.Load += Swim_Classification_Load;
            c.connectToSocket("localhost", 5000);
            c.ct = 0;
        }

        private void Swim_Classification_Load(object sender, EventArgs e)
        {
            c.recieveMessage();
            if (c.isConnected)
            {
                if (c.classify == "None")
                {
                    label1.Visible = true;
                    label1.Text = c.classify;
                    PictureBox img = new PictureBox();
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    this.pictureBox1.Image = new Bitmap("none.png");
                }
                if (c.classify == "'Butterfly'")
                {                    
                    label1.Visible = true;
                    label1.Text = c.classify;
                    PictureBox img = new PictureBox();
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    this.pictureBox1.Image = new Bitmap("butterfly.jpg");
                }               

                if (c.classify == "'backstroke'")
                {                    
                    label1.Visible = true;
                    label1.Text = c.classify;
                    PictureBox img = new PictureBox();
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    this.pictureBox1.Image = new Bitmap("backstroke.jpg");
                }               

                if (c.accuracy <= 10)
                {
                    label2.Visible = true;
                    label2.Text = c.accuracy.ToString();
                    PictureBox img = new PictureBox();
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    this.pictureBox2.Image = new Bitmap("waning.png");
                }
                else
                {
                    label2.Visible = true;
                    label2.Text = c.accuracy.ToString();
                    PictureBox img = new PictureBox();
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    this.pictureBox2.Image = new Bitmap("check.png");
                }
            }
        }
    }
}
