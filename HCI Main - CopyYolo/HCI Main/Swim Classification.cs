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
                     
        public Swim_Classification()
        {
            InitializeComponent();                        
            this.Load += Swim_Classification_Load;                       
        }

        private void Swim_Classification_Load(object sender, EventArgs e)
        {
            if (Form2.c.isConnected)
            {
                if (Form2.c.classify == "None")
                {
                    label1.Visible = true;
                    label1.Text = Form2.c.classify;
                    PictureBox img = new PictureBox();
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    this.pictureBox1.Image = new Bitmap("none.png");
                }
                if (Form2.c.classify == "'Butterfly'")
                {                    
                    label1.Visible = true;
                    label1.Text = Form2.c.classify;
                    PictureBox img = new PictureBox();
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    this.pictureBox1.Image = new Bitmap("butterfly.jpg");
                }               

                if (Form2.c.classify == "'backstroke'")
                {                    
                    label1.Visible = true;
                    label1.Text = Form2.c.classify;
                    PictureBox img = new PictureBox();
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    this.pictureBox1.Image = new Bitmap("backstroke.jpg");
                }               

                if (Form2.c.accuracy <= 10)
                {
                    label2.Visible = true;
                    label2.Text = Form2.c.accuracy.ToString();
                    PictureBox img = new PictureBox();
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    this.pictureBox2.Image = new Bitmap("waning.png");
                }
                else
                {
                    label2.Visible = true;
                    label2.Text = Form2.c.accuracy.ToString();
                    PictureBox img = new PictureBox();
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    this.pictureBox2.Image = new Bitmap("check.png");
                }
            }
        }
    }
}
