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
using System.Xml.Linq;
using TUIO;

namespace HCI_Main
{
    public partial class Form2 : Form, TuioListener
    {
        //TUIO
        private TuioClient client;
        private Dictionary<long, TuioObject> objectList;
        private Dictionary<long, TuioBlob> blobList;
        private Dictionary<long, TuioCursor> cursorList;
        public Dictionary<long, TuioObject> newobject;
        private bool verbose;
        public static int width, height;
        private int window_width = 1000;
        private int window_height = 600;


        //Form2
        public static ClientC c = new ClientC();
        Bitmap off;
        Timer tt = new Timer();
        int ctClassify = 0;
        int ctCamera = 0;
        int ct2 = 0;
        int ct3 = 0;
        int ct4 = 0;
        int ctt = 0;



        public Form2()
        {
            //TUIO
            verbose = false;
            width = window_width;
            height = window_height;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                            ControlStyles.UserPaint |
                            ControlStyles.DoubleBuffer, true);

            objectList = new Dictionary<long, TuioObject>(128);
            cursorList = new Dictionary<long, TuioCursor>(128);
            blobList = new Dictionary<long, TuioBlob>(128);

            client = new TuioClient(3333);
            client.addTuioListener(this);
            client.connect();


            //Form2
            InitializeComponent();
            this.Paint += Form2_Paint;
            this.Load += Form2_Load;
            tt.Tick += Tt_Tick;
            tt.Start();
            c.connectToSocket("localhost", 8000);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Process.Start("C:/Users/3m/OneDrive/Documents/GitHub/HCII/HCI Main/HCI Main/bin/Debug/reacTIVision.exe");


            this.Text = "Swimming system";
            if (c.isConnected)
            {
                c.recieveMessage();
            }
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            DrawScene(e.Graphics);
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
        }

        private void OpenForm(Form NewForm)
        {
            NewForm.TopLevel = false;
            NewForm.FormBorderStyle = FormBorderStyle.None;
            NewForm.Dock = DockStyle.Fill;
            this.Display.Controls.Add(NewForm);
            this.Display.Tag = NewForm;
            NewForm.BringToFront();
            NewForm.Show();
        }       

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            SolidBrush brs = new SolidBrush(Color.Red);
        }


        private void ClassifyBTN_Click_1(object sender, EventArgs e)
        {
            ct2 = 0;
            ct3 = 0;
            ct4 = 0;
            ctCamera = 0;
            ctClassify++;
            if (ctClassify == 1)
            {
                OpenForm(new Swim_Classification());
            }
            else
            {
                MessageBox.Show("You are already in Classify Form");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ctClassify = 0;
            ctCamera = 0;
            ct3 = 0;
            ct4 = 0;
            ct2++;
            if (ct2 == 1)
            {
                OpenForm(new Drowning_detect());
            }
            else
            {
                MessageBox.Show("You are already in Person Detection");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ctClassify = 0;
            ct2 = 0;
            ct3 = 0;
            ct4 = 0;
            ctCamera++;
            if (ctCamera == 1)
            {
                OpenForm(new Camera_Screen());
            }
            else
            {
                MessageBox.Show("You are already in Camera Screen");
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            string email = "ammarwael73@gmail.com";
            string mailtoUri = $"mailto:{email}";

            try
            {
                Process.Start(new ProcessStartInfo(mailtoUri));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening email client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Account_Settings f = new Account_Settings();            
            f.ShowDialog();            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Account_Settings f = new Account_Settings();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ctClassify = 0;
            ctCamera = 0;
            ct2 = 0;
            ct3 = 0;
            ct4++;
            if (ct4 == 1)
            {
                OpenForm(new View_Assigned_training());
            }
            else
            {
                MessageBox.Show("You are already in assigned training");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ctClassify = 0;
            ctCamera = 0;
            ct2 = 0;
            ct3++;
            ct4 = 0;
            if (ct3 == 1)
            {
                OpenForm(new Add_swimmer());
            }
            else
            {
                MessageBox.Show("You are already in add swimmer form");
            }
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

            if (o.SymbolID.Equals(0) && ctt == 0)
            {
                ctt++;
                object dummySender = new object();
                EventArgs dummyEventArgs = new EventArgs();
                button4_Click(dummySender, dummyEventArgs);
            }

            //if (o.SymbolID.Equals(0) && ctClassify == 0)
            //{
            //    this.Text += "ok";
            //    ct2 = 0;
            //    ct3 = 0;
            //    ct4 = 0;
            //    ctCamera = 0;
            //    ctClassify++;
            //    OpenForm(new Add_swimmer());
            //}

            //if (o.SymbolID.Equals(1))
            //{

            //    ctClassify = 0;
            //    ctCamera = 0;
            //    ct3 = 0;
            //    ct4 = 0;
            //    ct2++;
            //    if (ct2 == 1)
            //    {
            //        OpenForm(new Drowning_detect());
            //    }
            //    else
            //    {
            //        MessageBox.Show("You are already in Person Detection");
            //    }

            //}
            //if (o.SymbolID.Equals(2) && ctCamera == 0)
            //{
            //    this.Text += "ok";
            //    ctClassify = 0;
            //    ct2 = 0;
            //    ct3 = 0;
            //    ct4 = 0;
            //    ctCamera++;
            //    OpenForm(new Camera_Screen());
            //}
            //if (o.SymbolID.Equals(3))
            //{

            //    ctClassify = 0;
            //    ctCamera = 0;
            //    ct2 = 0;
            //    ct3++;
            //    ct4 = 0;
            //    if (ct3 == 1)
            //    {
            //        OpenForm(new Add_swimmer());
            //    }
            //    else
            //    {
            //        MessageBox.Show("You are already in add swimmer form");
            //    }

            //}
            //if (o.SymbolID.Equals(4))
            //{

            //    ctClassify = 0;
            //    ctCamera = 0;
            //    ct2 = 0;
            //    ct3 = 0;
            //    ct4++;
            //    if (ct4 == 1)
            //    {
            //        OpenForm(new View_Assigned_training());
            //    }
            //    else
            //    {
            //        MessageBox.Show("You are already in assigned training");
            //    }

            //}


            //if (objectList.Count > 0)
            //{
            //    lock (objectList)
            //    {
            //        foreach (TuioObject tobj in objectList.Values)
            //        {
            //            if (tobj.SymbolID.Equals(0))
            //            {
            //                ctClassify = 0;
            //                ct2 = 0;
            //                ct3 = 0;
            //                ct4 = 0;
            //                ctCamera++;
            //                Console.WriteLine(ctCamera);
            //                if (ctCamera == 1)
            //                {
            //                    OpenForm(new Camera_Screen());
            //                }
            //            }
            //        }
            //    }
            //}
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
    }
}
