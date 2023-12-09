using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUIO;

namespace HCI_Main
{
    public partial class Drowning_detect : Form, TuioListener
    {
        private TuioClient client;
        private Dictionary<long, TuioObject> objectList;
        private Dictionary<long, TuioCursor> cursorList;
        private Dictionary<long, TuioBlob> blobList;
        public Dictionary<long, TuioObject> newobject;
        private bool verbose;
        bool msg = false;
        bool msg2 = false;

        public Drowning_detect()
        {
            InitializeComponent();
            verbose = false;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                            ControlStyles.UserPaint |
                            ControlStyles.DoubleBuffer, true);

            objectList = new Dictionary<long, TuioObject>(128);
            cursorList = new Dictionary<long, TuioCursor>(128);
            blobList = new Dictionary<long, TuioBlob>(128);

            client = new TuioClient(3333);
            client.addTuioListener(this);
            this.Load += Drowning_detect_Load;
            client.connect();
        }

        private void Drowning_detect_Load(object sender, EventArgs e)
        {
            Process.Start("C:/Users/Ammar Wael/Desktop/HCI/HCI Main/HCI Main/bin/Debug/reacTIVision.exe");
        }

        public void addTuioObject(TuioObject o)
        {
            lock (objectList)
            {
                objectList.Add(o.SessionID, o);
            }
            if (verbose) Console.WriteLine("add obj " + o.SymbolID + " (" + o.SessionID + ") " + o.X + " " + o.Y + " " + o.Angle);
        }

        public void updateTuioObject(TuioObject o)
        {
            int rotationangel = (int)Math.Round(o.Angle) * 10;

            if (o.SymbolID.Equals(0))
            {

                o.Name = "momen";

            }
            if (rotationangel == 10 && !msg)
            {
                MessageBox.Show("next");
                msg = true;
                msg2 = false;
            }
            if (rotationangel == 50 && !msg2)
            {
                MessageBox.Show("previous");
                msg2 = true;
                msg = false;
            }
        }

        public void removeTuioObject(TuioObject o)
        {
            lock (objectList)
            {
                objectList.Remove(o.SessionID);
            }
            if (verbose) Console.WriteLine("del obj " + o.SymbolID + " (" + o.SessionID + ")");
        }

        public void addTuioCursor(TuioCursor c)
        {
            lock (cursorList)
            {
                cursorList.Add(c.SessionID, c);
            }
            if (verbose) Console.WriteLine("add cur " + c.CursorID + " (" + c.SessionID + ") " + c.X + " " + c.Y);
        }

        public void updateTuioCursor(TuioCursor c)
        {
            if (verbose) Console.WriteLine("set cur " + c.CursorID + " (" + c.SessionID + ") " + c.X + " " + c.Y + " " + c.MotionSpeed + " " + c.MotionAccel);
        }

        public void removeTuioCursor(TuioCursor c)
        {
            lock (cursorList)
            {
                cursorList.Remove(c.SessionID);
            }
            if (verbose) Console.WriteLine("del cur " + c.CursorID + " (" + c.SessionID + ")");
        }

        public void addTuioBlob(TuioBlob b)
        {
            lock (blobList)
            {
                blobList.Add(b.SessionID, b);
            }
            if (verbose) Console.WriteLine("add blb " + b.BlobID + " (" + b.SessionID + ") " + b.X + " " + b.Y + " " + b.Angle + " " + b.Width + " " + b.Height + " " + b.Area);
        }

        public void updateTuioBlob(TuioBlob b)
        {

            if (verbose) Console.WriteLine("set blb " + b.BlobID + " (" + b.SessionID + ") " + b.X + " " + b.Y + " " + b.Angle + " " + b.Width + " " + b.Height + " " + b.Area + " " + b.MotionSpeed + " " + b.RotationSpeed + " " + b.MotionAccel + " " + b.RotationAccel);
            
        }

        public void removeTuioBlob(TuioBlob b)
        {
            lock (blobList)
            {
                blobList.Remove(b.SessionID);
            }
            if (verbose) Console.WriteLine("del blb " + b.BlobID + " (" + b.SessionID + ")");
        }

        public void refresh(TuioTime frameTime)
        {
            Invalidate();
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Getting the graphics object
            
            // draw the cursor path
            if (cursorList.Count > 0)
            {
                lock (cursorList)
                {
                    foreach (TuioCursor tcur in cursorList.Values)
                    {
                        List<TuioPoint> path = tcur.Path;
                        TuioPoint current_point = path[0];

                        for (int i = 0; i < path.Count; i++)
                        {
                            TuioPoint next_point = path[i];                           
                            current_point = next_point;
                        }                                                
                    }
                }
            }

            // draw the objects
            if (objectList.Count > 0)
            {
                lock (objectList)
                {
                    foreach (TuioObject tobj in objectList.Values)
                    {
                        int ox = tobj.getScreenX(this.ClientSize.Width);
                        int oy = tobj.getScreenY(this.ClientSize.Height);
                        int size = this.ClientSize.Height / 10;
/*
                        if (tobj.SymbolID.Equals(0))
                        {
                            tobj.Name = "momen";
                            tobj.Age = "21";
                            tobj.Nationality = "Egyption";
                            label1.Visible = true;
                            label1.Text = tobj.Name;
                            label3.Visible = true;
                            label3.Text = "Age: "+tobj.Age ;
                            label4.Visible = true;
                            label4.Text = "Nationality: " + tobj.Nationality;
                            Swimm.Visible = true;
                            Swimm.Text = "Swim: 2 Backstroke , 1 Butterfly";
                            PictureBox img = new PictureBox();
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            this.pictureBox1.Image = new Bitmap("Momen.jpg");
                        }
                        if (tobj.SymbolID.Equals(1))
                        {
                            tobj.Name = "Ammar";
                            tobj.Age = "22";
                            tobj.Nationality = "Egyption";
                            label1.Visible = true;
                            label1.Text = tobj.Name;
                            label3.Visible = true;
                            label3.Text = "Age: " + tobj.Age;
                            label4.Visible = true;
                            label4.Text = "Nationality: " + tobj.Nationality;
                            Swimm.Visible = true;
                            Swimm.Text = "Swim: 1 Backstroke , 3 Butterfly";
                            PictureBox img = new PictureBox();
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            this.pictureBox1.Image = new Bitmap("Ammar.jpg");
                        }
                        if (tobj.SymbolID.Equals(2))
                        {
                            tobj.Name = "Essam";
                            tobj.Age = "21";
                            tobj.Nationality = "Egyption";
                            label1.Visible = true;
                            label1.Text = tobj.Name;
                            label3.Visible = true;
                            label3.Text = "Age: " + tobj.Age;
                            label4.Visible = true;
                            label4.Text = "Nationality: " + tobj.Nationality;
                            Swimm.Visible = true;
                            Swimm.Text = "Swim: 4 Backstroke , 0 Butterfly";
                            PictureBox img = new PictureBox();
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            this.pictureBox1.Image = new Bitmap("Essam.jpg");
                        }
                        if (tobj.SymbolID.Equals(4))
                        {
                            tobj.Name = "Gomaa";
                            tobj.Age = "21";
                            tobj.Nationality = "Egyption";
                            label1.Visible = true;
                            label1.Text = tobj.Name;
                            label3.Visible = true;
                            label3.Text = "Age: " + tobj.Age;
                            label4.Visible = true;
                            label4.Text = "Nationality: " + tobj.Nationality;
                            Swimm.Visible = true;
                            Swimm.Text = "Swim: 1 Backstroke , 1 Butterfly";
                            PictureBox img = new PictureBox();
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            this.pictureBox1.Image = new Bitmap("Gomaa.jpg");
                        }*/
                    }
                }
            }
            //else
            //{
            //    label1.Text = "No one Identified";
            //    label3.Visible = false;
            //    label4.Visible = false;
            //    Swimm.Visible = false;
            //}

            // draw the blobs
            if (blobList.Count > 0)
            {
                lock (blobList)
                {
                    foreach (TuioBlob tblb in blobList.Values)
                    {
                        int bx = tblb.getScreenX(this.ClientSize.Width);
                        int by = tblb.getScreenY(this.ClientSize.Height);
                        float bw = tblb.Width * this.ClientSize.Width;
                        float bh = tblb.Height * this.ClientSize.Height;                                                                                                                                                                                                
                    }
                }
            }
        }
    }
}
