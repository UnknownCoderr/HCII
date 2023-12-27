using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUIO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HCI_Main.TUIO
{
    public partial class PieMenu : Form , TuioListener
    {
        public class EllipseInfo
        {
            public Brush Color { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        Form activeform;
        int i = 0;
        private TuioClient client;
        private Dictionary<long, TuioObject> objectList;
        private Dictionary<long, TuioCursor> cursorList;
        private Dictionary<long, TuioBlob> blobList;
        private bool verbose;
        public static bool isok = false;
        Font font = new Font("Arial", 10.0f);
        SolidBrush fntBrush = new SolidBrush(Color.White);
        SolidBrush bgrBrush = new SolidBrush(Color.FromArgb(0, 0, 64));
        SolidBrush curBrush = new SolidBrush(Color.FromArgb(192, 0, 192));
        SolidBrush objBrush = new SolidBrush(Color.FromArgb(64, 0, 0));
        SolidBrush blbBrush = new SolidBrush(Color.FromArgb(64, 64, 64));
        Pen curPen = new Pen(new SolidBrush(Color.Blue), 1);
        Assign_training p = new Assign_training();
        public int ctor = 0, ctor1 = 0, ctor2 = 0, ctor3 = 0, ctor4 = 0, ctor5 = 0;        
        Bitmap off;
        bool ishere = false;
        bool isSwim = false;
        int xminus = 470;
        bool isCamera = false; bool isDetect = false; bool isNewSwimmer = false; 
        bool isView = false; bool isAccount = false, isAssign = false, isBack = false, isBack1 = false, isAssignT = false, isClear = false, ChangeUsername = false, ChangePassword = false, isBack2 = false;
        public string[] menuOptions = { "Person detection", "camera screen", "new swimmer", "view training", "account setting" , "Swimm class" };
        Timer tt = new Timer();
        public int ctt = 0, ctTimer = 0;
        public bool isTimer = false;
        public int intTUIO =0;
        public PieMenu()
        {                                           
            InitializeComponent();
            this.Paint += PieMenu_Paint;
            this.Load += PieMenu_Load1;
            verbose = false;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                            ControlStyles.UserPaint |
                            ControlStyles.DoubleBuffer, true);                      
            if (intTUIO==0)
            {                
                objectList = new Dictionary<long, TuioObject>(128);
                cursorList = new Dictionary<long, TuioCursor>(128);
                blobList = new Dictionary<long, TuioBlob>(128);
                client = new TuioClient(3333);
                client.addTuioListener(this);
                client.connect();
            }
                   
            isok = true;
            tt.Tick += Tt_Tick;
            tt.Start();
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            //DrawDubb(this.CreateGraphics());
        }


        private void PieMenu_Load1(object sender, EventArgs e)
        {           
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        }

        private void PieMenu_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        List<EllipseInfo> ellipseList = new List<EllipseInfo>();
        List<EllipseInfo> ellipseList2 = new List<EllipseInfo>();
        List<EllipseInfo> ellipseList3 = new List<EllipseInfo>();
        List<EllipseInfo> ellipseList4 = new List<EllipseInfo>();

        void DrawScene(Graphics g2)
        {
            g2.Clear(Color.White);

            if (isTimer)
            {
                ctTimer++;
                label2.Text = "" + ctTimer;
            }
            
            if (ctt == 0) 
            {
                int centerX = ClientSize.Width / 2;
                int centerY = ClientSize.Height / 2;
                int radius = 100;
                float angleIncrement = 360f / menuOptions.Length;


                for (int i = 0; i < menuOptions.Length; i++)
                {
                    float angle = i * angleIncrement;
                    float radians = (float)(angle * Math.PI / 180.0);

                    int x = (int)(centerX + radius * Math.Cos(radians));
                    int y = (int)(centerY + radius * Math.Sin(radians));

                    EllipseInfo ellipseInfo = new EllipseInfo
                    {
                        Color = Brushes.Cyan,
                        X = x - 460,
                        Y = y - 30,
                        Width = 60,
                        Height = 60
                    };

                    ellipseList.Add(ellipseInfo);
                    g2.FillEllipse(ellipseList[i].Color, ellipseList[i].X, ellipseList[i].Y, ellipseList[i].Width, ellipseList[i].Height);

                    using (Font font = new Font("Arial", 8))
                    {
                        SizeF textSize = g2.MeasureString(menuOptions[i], font);
                        g2.DrawString(menuOptions[i], font, Brushes.Black, x - 470, y - textSize.Height / 2);
                    }
                }
                               
            }

            if (ctt == 1)
            {
                int centerX = ClientSize.Width / 2;
                int centerY = ClientSize.Height / 2;
                int radius = 100;
                float angleIncrement = 360f / menuOptions.Length;

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    float angle = i * angleIncrement;
                    float radians = (float)(angle * Math.PI / 180.0);

                    int x = (int)(centerX + radius * Math.Cos(radians));
                    int y = (int)(centerY + radius * Math.Sin(radians));


                    EllipseInfo ellipseInfo = new EllipseInfo
                    {
                        Color = Brushes.Cyan,
                        X = x - 460,
                        Y = y - 30,
                        Width = 60,
                        Height = 60
                    };

                    ellipseList2.Add(ellipseInfo);
                    g2.FillEllipse(ellipseList2[i].Color, ellipseList2[i].X, ellipseList2[i].Y, ellipseList2[i].Width, ellipseList2[i].Height);


                    using (Font font = new Font("Arial", 8))
                    {
                        SizeF textSize = g2.MeasureString(menuOptions[i], font);
                        g2.DrawString(menuOptions[i], font, Brushes.Black, x - xminus, y - textSize.Height / 2);
                    }
                }
            }

            if (ctt == 2)
            {
                int centerX = ClientSize.Width / 2;
                int centerY = ClientSize.Height / 2;
                int radius = 100;
                float angleIncrement = 360f / menuOptions.Length;

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    float angle = i * angleIncrement;
                    float radians = (float)(angle * Math.PI / 180.0);

                    int x = (int)(centerX + radius * Math.Cos(radians));
                    int y = (int)(centerY + radius * Math.Sin(radians));


                    EllipseInfo ellipseInfo = new EllipseInfo
                    {
                        Color = Brushes.Cyan,
                        X = x - 460,
                        Y = y - 30,
                        Width = 60,
                        Height = 60
                    };

                    ellipseList3.Add(ellipseInfo);
                    g2.FillEllipse(ellipseList3[i].Color, ellipseList3[i].X, ellipseList3[i].Y, ellipseList3[i].Width, ellipseList3[i].Height);


                    using (Font font = new Font("Arial", 8))
                    {
                        SizeF textSize = g2.MeasureString(menuOptions[i], font);
                        g2.DrawString(menuOptions[i], font, Brushes.Black, x - xminus, y - textSize.Height / 2);
                    }
                }
            }

            if (ctt == 3)
            {
                int centerX = ClientSize.Width / 2;
                int centerY = ClientSize.Height / 2;
                int radius = 100;
                float angleIncrement = 360f / menuOptions.Length;

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    float angle = i * angleIncrement;
                    float radians = (float)(angle * Math.PI / 180.0);

                    int x = (int)(centerX + radius * Math.Cos(radians));
                    int y = (int)(centerY + radius * Math.Sin(radians));


                    EllipseInfo ellipseInfo = new EllipseInfo
                    {
                        Color = Brushes.Cyan,
                        X = x - 460,
                        Y = y - 30,
                        Width = 60,
                        Height = 60
                    };

                    ellipseList4.Add(ellipseInfo);
                    g2.FillEllipse(ellipseList4[i].Color, ellipseList4[i].X, ellipseList4[i].Y, ellipseList4[i].Width, ellipseList4[i].Height);


                    using (Font font = new Font("Arial", 8))
                    {
                        SizeF textSize = g2.MeasureString(menuOptions[i], font);
                        g2.DrawString(menuOptions[i], font, Brushes.Black, x - xminus, y - textSize.Height / 2);
                    }
                }
            }

        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

        private void PieMenu_Load(object sender, EventArgs e)
        {
            //Process.Start("D:\\HCII\\HCI Main\\HCI Main\\bin\\Debug\\reacTIVision.exe");
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

            if (verbose) Console.WriteLine("set obj " + o.SymbolID + " " + o.SessionID + " " + o.X + " " + o.Y + " " + o.Angle + " " + o.MotionSpeed + " " + o.RotationSpeed + " " + o.MotionAccel + " " + o.RotationAccel);
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
        private void OpenForm(Form NewForm)
        {
            NewForm.TopLevel = false;
            NewForm.FormBorderStyle = FormBorderStyle.None;
            NewForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(NewForm);
            this.panel1.Tag = NewForm;
            NewForm.BringToFront();
            NewForm.Show();
        }

        public void isrotate(float angel ,int Id)
        {            
            if (ctt == 0 && Id== 0)
            {
                if (angel > 0.5 && angel < 1 && !isSwim)
                {
                    if (!isTimer)
                    {
                        isTimer = true;
                    }
                    ellipseList[0].Color = Brushes.Cyan;
                    ellipseList[1].Color = Brushes.Cyan;
                    ellipseList[2].Color = Brushes.Cyan;
                    ellipseList[3].Color = Brushes.Cyan;
                    ellipseList[4].Color = Brushes.Cyan;
                    ellipseList[5].Color = Brushes.Red;

                    if (ctor >= 50)
                    {
                        isTimer = false;
                        ctTimer = 0;
                        isSwim = true;
                        isDetect = false;
                        isCamera = false;
                        isNewSwimmer = false;
                        isView = false;
                        isAccount = false;
                        isAssign = false;
                        isAssignT = false;
                        isBack = false;
                        isBack1 = false;
                        isClear = false;
                        isBack2 = false;
                        ChangePassword = false;
                        ChangeUsername = false;
                        OpenForm(new Swim_Classification());                        
                        Console.WriteLine("Top right: " + angel);
                    }
                    ctor++;
                    ctor1 = 0;
                    ctor2 = 0;
                    ctor3 = 0;
                    ctor4 = 0;
                    ctor5 = 0;
                }

                if (angel >= 1 && angel < 2 && !isDetect)
                {
                    if (!isTimer)
                    {
                        isTimer = true;
                    }
                    ellipseList[0].Color = Brushes.Red;
                    ellipseList[1].Color = Brushes.Cyan;
                    ellipseList[2].Color = Brushes.Cyan;
                    ellipseList[3].Color = Brushes.Cyan;
                    ellipseList[4].Color = Brushes.Cyan;
                    ellipseList[5].Color = Brushes.Cyan;

                    if (ctor1 > 50)
                    {
                        isTimer = false;
                        ctTimer = 0;
                        isSwim = false;
                        isDetect = true;
                        isCamera = false;
                        isNewSwimmer = false;
                        isView = false;
                        isAccount = false;
                        isAssign = false;
                        isAssignT = false;
                        isBack = false;
                        isBack1 = false;
                        isClear = false;
                        isBack2 = false;
                        ChangePassword = false;
                        ChangeUsername = false;
                        OpenForm(new Drowning_detect());
                        Console.WriteLine("right: " + angel);
                    }
                    ctor = 0;
                    ctor1++;
                    ctor2 = 0;
                    ctor3 = 0;
                    ctor4 = 0;
                    ctor5 = 0;
                }

                if (angel >= 2 && angel < 3 && !isCamera)
                {
                    if (!isTimer)
                    {
                        isTimer = true;
                    }
                    ellipseList[0].Color = Brushes.Cyan;
                    ellipseList[1].Color = Brushes.Red;
                    ellipseList[2].Color = Brushes.Cyan;
                    ellipseList[3].Color = Brushes.Cyan;
                    ellipseList[4].Color = Brushes.Cyan;
                    ellipseList[5].Color = Brushes.Cyan;

                    if (ctor2 > 50)
                    {
                        isTimer = false;
                        ctTimer = 0;
                        string[] newMenuOptions = { "Start", "Back", "Assign Training" };
                        menuOptions = newMenuOptions;
                        ctt = 1;
                        xminus = 450;
                        isSwim = false;
                        isDetect = false;
                        isCamera = true;
                        isNewSwimmer = false;
                        isView = false;
                        isAccount = false;
                        isAssign = false;
                        isAssignT = false;
                        isBack = false;
                        isBack1 = false;
                        isClear = false;
                        isBack2 = false;
                        ChangePassword = false;
                        ChangeUsername = false;
                        OpenForm(new Camera_Screen());
                        Console.WriteLine("bottom right: " + angel);
                    }
                    ctor = 0;
                    ctor1 = 0;
                    ctor2++;
                    ctor3 = 0;
                    ctor4 = 0;
                    ctor5 = 0;
                }

                if (angel >= 3 && angel < 4 && !isNewSwimmer)
                {
                    if (!isTimer)
                    {
                        isTimer = true;
                    }
                    ellipseList[0].Color = Brushes.Cyan;
                    ellipseList[1].Color = Brushes.Cyan;
                    ellipseList[2].Color = Brushes.Red;
                    ellipseList[3].Color = Brushes.Cyan;
                    ellipseList[4].Color = Brushes.Cyan;
                    ellipseList[5].Color = Brushes.Cyan;
                    if (ctor3 > 50)
                    {
                        isTimer = false;
                        ctTimer = 0;
                        isSwim = false;
                        isDetect = false;
                        isCamera = false;
                        isNewSwimmer = true;
                        isView = false;
                        isAccount = false;
                        isAssign = false;
                        isAssignT = false;
                        isBack = false;
                        isBack1 = false;
                        isClear = false;
                        isBack2 = false;
                        ChangePassword = false;
                        ChangeUsername = false;
                        OpenForm(new Add_swimmer());
                        Console.WriteLine("bottom left: " + angel);
                    }
                    ctor = 0;
                    ctor1 = 0;
                    ctor2 = 0;
                    ctor3++;
                    ctor4 = 0;
                    ctor5 = 0;
                }

                if (angel >= 4 && angel < 5 && !isView)
                {
                    if (!isTimer)
                    {
                        isTimer = true;
                    }
                    ellipseList[0].Color = Brushes.Cyan;
                    ellipseList[1].Color = Brushes.Cyan;
                    ellipseList[2].Color = Brushes.Cyan;
                    ellipseList[3].Color = Brushes.Red;
                    ellipseList[4].Color = Brushes.Cyan;
                    ellipseList[5].Color = Brushes.Cyan;
                    if (ctor4 > 50)
                    {
                        isTimer = false;
                        ctTimer = 0;
                        isSwim = false;
                        isDetect = false;
                        isCamera = false;
                        isNewSwimmer = false;
                        isView = true;
                        isAccount = false;
                        isAssign = false;
                        isAssignT = false;
                        isBack = false;
                        isBack1 = false;
                        isClear = false;
                        isBack2 = false;
                        ChangePassword = false;
                        ChangeUsername = false;
                        OpenForm(new View_Assigned_training());
                        Console.WriteLine("left: " + angel);
                    }
                    ctor = 0;
                    ctor1 = 0;
                    ctor2 = 0;
                    ctor3 = 0;
                    ctor4++;
                    ctor5 = 0;
                }

                if (angel >= 5 && angel < 5.5 && !isAccount)
                {
                    if (!isTimer)
                    {
                        isTimer = true;
                    }
                    ellipseList[0].Color = Brushes.Cyan;
                    ellipseList[1].Color = Brushes.Cyan;
                    ellipseList[2].Color = Brushes.Cyan;
                    ellipseList[3].Color = Brushes.Cyan;
                    ellipseList[4].Color = Brushes.Red;
                    ellipseList[5].Color = Brushes.Cyan;
                    if (ctor5 > 50)
                    {
                        string[] newMenuOptions = { "Change pass", "Change name" , "Back"};
                        menuOptions = newMenuOptions;
                        xminus -= 10;
                        ctt = 3;
                        isTimer = false;
                        ctTimer = 0;
                        isSwim = false;
                        isDetect = false;
                        isCamera = false;
                        isNewSwimmer = false;
                        isView = false;
                        isAccount = true;
                        isAssign = false;
                        isAssignT = false;
                        isBack = false;
                        isBack1 = false;
                        isClear = false;
                        isBack2 = false;
                        ChangePassword = false;
                        ChangeUsername = false;
                        OpenForm(new Account_Settings());
                        Console.WriteLine("top left: " + angel);
                    }
                    ctor = 0;
                    ctor1 = 0;
                    ctor2 = 0;
                    ctor3 = 0;
                    ctor4 = 0;
                    ctor5++;
                }
            }
            
            if (ctt == 1 && Id == 0)
            {
                if (angel >= 5 && angel < 5.5 && !isAssign)
                {
                    if (!isTimer)
                    {
                        isTimer = true;
                    }
                    ellipseList[0].Color = Brushes.Cyan;
                    ellipseList[1].Color = Brushes.Cyan;
                    ellipseList[2].Color = Brushes.Cyan;
                    ellipseList[3].Color = Brushes.Cyan;
                    ellipseList[4].Color = Brushes.Cyan;
                    ellipseList[5].Color = Brushes.Cyan;
                    ellipseList2[0].Color = Brushes.Cyan;
                    ellipseList2[1].Color = Brushes.Cyan;
                    ellipseList2[2].Color = Brushes.Red;

                    if (ctor4 > 50)
                    {
                        ellipseList2[1].Color = Brushes.Cyan;
                        ellipseList2[2].Color = Brushes.Cyan;
                        isTimer = false;
                        ctTimer = 0;
                        isView = true;
                        OpenForm(p);
                        Console.WriteLine("Left: " + angel);
                        string[] newMenuOptions = { "Assign", "Clear", "Back" };
                        menuOptions = newMenuOptions;
                        ctt = 2;
                        isSwim = false;
                        isDetect = false;
                        isCamera = false;
                        isNewSwimmer = false;
                        isView = false;
                        isAccount = false;
                        isAssign = true;
                        isAssignT = false;
                        isBack = false;
                        isBack1 = false;
                        isClear = false;
                        isBack2 = false;
                        ChangePassword = false;
                        ChangeUsername = false;
                        DrawDubb(this.CreateGraphics());
                    }
                    ctor = 0;
                    ctor1 = 0;
                    ctor2 = 0;
                    ctor3 = 0;
                    ctor4++;
                    ctor5 = 0;
                }

                if (angel >= 3 && angel < 4 && !isBack1)
                {
                    if (!isTimer)
                    {
                        isTimer = true;
                    }
                    ellipseList[0].Color = Brushes.Cyan;
                    ellipseList[1].Color = Brushes.Cyan;
                    ellipseList[2].Color = Brushes.Cyan;
                    ellipseList[3].Color = Brushes.Cyan;
                    ellipseList[4].Color = Brushes.Cyan;
                    ellipseList[5].Color = Brushes.Cyan;
                    ellipseList2[0].Color = Brushes.Cyan;
                    ellipseList2[1].Color = Brushes.Red;
                    ellipseList2[2].Color = Brushes.Cyan;
                    ellipseList2[3].Color = Brushes.Cyan;

                    if (ctor4 > 50)
                    {
                        ellipseList2[1].Color = Brushes.Cyan;
                        ellipseList2[2].Color = Brushes.Cyan;
                        isTimer = false;
                        ctTimer = 0;
                        isView = true;
                        Console.WriteLine("Left: " + angel);
                        string[] newMenuOptions = { "Person detection", "camera screen", "new swimmer", "view training", "account setting", "Swimm class" };
                        menuOptions = newMenuOptions;
                        ctt = 0;
                        isSwim = false;
                        isDetect = false;
                        isCamera = false;
                        isNewSwimmer = false;
                        isView = false;
                        isAccount = false;
                        isAssign = false;
                        isAssignT = false;
                        isBack = false;
                        isBack1 = true;
                        isClear = false;
                        isBack2 = false;
                        ChangePassword = false;
                        ChangeUsername = false;
                    }
                    ctor = 0;
                    ctor1 = 0;
                    ctor2 = 0;
                    ctor3 = 0;
                    ctor4++;
                    ctor5 = 0;
                }
            }

            if (ctt == 2 )
            {
                if(Id == 0)
                {
                    if (angel >= 1 && angel < 2 && !isAssignT)
                    {
                        if (!isTimer)
                        {
                            isTimer = true;
                        }
                        ellipseList[0].Color = Brushes.Cyan;
                        ellipseList[1].Color = Brushes.Cyan;
                        ellipseList[2].Color = Brushes.Cyan;
                        ellipseList[3].Color = Brushes.Cyan;
                        ellipseList[4].Color = Brushes.Cyan;
                        ellipseList[5].Color = Brushes.Cyan;
                        ellipseList2[0].Color = Brushes.Cyan;
                        ellipseList2[1].Color = Brushes.Cyan;
                        ellipseList3[0].Color = Brushes.Red;
                        ellipseList3[1].Color = Brushes.Cyan;
                        ellipseList3[2].Color = Brushes.Cyan;
                        if (ctor2 > 50)
                        {
                            isTimer = false;
                            ctTimer = 0;
                            isSwim = false;
                            isDetect = false;
                            isCamera = false;
                            isNewSwimmer = false;
                            isView = false;
                            isAccount = false;
                            isAssignT = true;
                            isAssign = false;
                            isBack = false;
                            isClear = false;
                            p.asssign();
                            Console.WriteLine("Right: " + angel);
                        }
                        ctor = 0;
                        ctor1 = 0;
                        ctor2++;
                        ctor3 = 0;
                        ctor4 = 0;
                        ctor5 = 0;
                    }

                    if (angel >= 5 && angel < 5.5 && !isBack)
                    {
                        if (!isTimer)
                        {
                            isTimer = true;
                        }
                        ellipseList[0].Color = Brushes.Cyan;
                        ellipseList[1].Color = Brushes.Cyan;
                        ellipseList[2].Color = Brushes.Cyan;
                        ellipseList[3].Color = Brushes.Cyan;
                        ellipseList[4].Color = Brushes.Cyan;
                        ellipseList[5].Color = Brushes.Cyan;
                        ellipseList2[0].Color = Brushes.Cyan;
                        ellipseList2[1].Color = Brushes.Cyan;
                        ellipseList3[0].Color = Brushes.Cyan;
                        ellipseList3[1].Color = Brushes.Cyan;
                        ellipseList3[2].Color = Brushes.Red;
                        if (ctor5 > 50)
                        {
                            isTimer = false;
                            ctTimer = 0;
                            string[] newMenuOptions = { "Start", "Back", "Assign Training" };
                            menuOptions = newMenuOptions;
                            ctt = 1;
                            isSwim = false;
                            isDetect = false;
                            isCamera = false;
                            isNewSwimmer = false;
                            isView = false;
                            isAccount = false;
                            isAssign = false;
                            isAssignT = false;
                            isBack = true;
                            isBack1 = false;
                            isClear = false;
                            intTUIO = 1;
                            OpenForm(new Camera_Screen());
                            Console.WriteLine("Top left: " + angel);
                        }
                        ctor = 0;
                        ctor1 = 0;
                        ctor2 = 0;
                        ctor3 = 0;
                        ctor4 = 0;
                        ctor5++;
                    }

                    if (angel >= 3 && angel < 4 && !isClear)
                    {
                        if (!isTimer)
                        {
                            isTimer = true;
                        }
                        ellipseList[0].Color = Brushes.Cyan;
                        ellipseList[1].Color = Brushes.Cyan;
                        ellipseList[2].Color = Brushes.Cyan;
                        ellipseList[3].Color = Brushes.Cyan;
                        ellipseList[4].Color = Brushes.Cyan;
                        ellipseList[5].Color = Brushes.Cyan;
                        ellipseList2[0].Color = Brushes.Cyan;
                        ellipseList2[1].Color = Brushes.Cyan;
                        ellipseList3[0].Color = Brushes.Cyan;
                        ellipseList3[1].Color = Brushes.Red;
                        ellipseList3[2].Color = Brushes.Cyan;
                        if (ctor4 > 50)
                        {
                            isTimer = false;
                            ctTimer = 0;
                            isSwim = false;
                            isDetect = false;
                            isCamera = false;
                            isNewSwimmer = false;
                            isView = false;
                            isAccount = false;
                            isAssign = false;
                            isAssignT = false;
                            isBack = false;
                            isBack1 = false;
                            isClear = true;
                            p.clear();
                            Console.WriteLine("bottom left: " + angel);
                        }
                        ctor = 0;
                        ctor1 = 0;
                        ctor2 = 0;
                        ctor3 = 0;
                        ctor4++;
                        ctor5 = 0;
                    }
                }

                if (Id == 1)
                {
                    if (angel > 0.5 && angel < 1)
                    {
                        p.assignComboBox("Swimmer1");
                    }
                    if (angel > 1 && angel < 2)
                    {
                        p.assignComboBox("Swimmer2");
                    }
                    if (angel > 2 && angel < 3)
                    {
                        p.assignComboBox("Swimmer3");
                    }
                    if (angel > 3 && angel < 4)
                    {
                        p.assignComboBox("Swimmer4");
                    }
                    if (angel > 4 && angel < 5)
                    {
                        p.assignComboBox("Swimmer5");
                    }
                    if (angel > 5 && angel < 5.5)
                    {
                        p.assignComboBox("Swimmer6");
                    }
                }

                if (Id == 2)
                {
                    if (angel > 0.5 && angel < 1)
                    {
                        p.assignCount("1");
                    }
                    if (angel > 1 && angel < 2)
                    {
                        p.assignCount("2");
                    }
                    if (angel > 2 && angel < 3)
                    {
                        p.assignCount("3");
                    }
                    if (angel > 3 && angel < 4)
                    {
                        p.assignCount("4");
                    }
                    if (angel > 4 && angel < 5)
                    {
                        p.assignCount("5");
                    }
                    if (angel > 5 && angel < 5.5)
                    {
                        p.assignCount("6");
                    }
                }

                if (Id == 3)
                {
                    if (angel > 0.5 && angel < 1)
                    {
                        p.assignSWimmStyle("FreeStyle");
                    }
                    if (angel > 1 && angel < 2)
                    {
                        p.assignSWimmStyle("BackStroke");
                    }
                    if (angel > 2 && angel < 3)
                    {
                        p.assignSWimmStyle("ButterFly");
                    }                    
                }
            }

            if (ctt == 3)
            {
                if (angel >= 1 && angel < 2 && !ChangePassword)
                {
                    if (!isTimer)
                    {
                        isTimer = true;
                    }
                    ellipseList[0].Color = Brushes.Cyan;
                    ellipseList[1].Color = Brushes.Cyan;
                    ellipseList[2].Color = Brushes.Cyan;
                    ellipseList[3].Color = Brushes.Cyan;
                    ellipseList[4].Color = Brushes.Cyan;
                    ellipseList[5].Color = Brushes.Cyan;
                    ellipseList4[0].Color = Brushes.Red;
                    ellipseList4[1].Color = Brushes.Cyan;
                    ellipseList4[2].Color = Brushes.Cyan;
                    if (ctor4 > 50)
                    {
                        isTimer = false;
                        ctTimer = 0;
                        isSwim = false;
                        isDetect = false;
                        isCamera = false;
                        isNewSwimmer = false;
                        isView = false;
                        isAccount = false;
                        isAssign = false;
                        isAssignT = false;
                        isBack = false;
                        isBack1 = false;
                        isClear = false;
                        ChangePassword = true;
                        ChangeUsername = false;
                        isBack2=false;
                        OpenForm(new Change_Passowrd());
                    }
                    ctor = 0;
                    ctor1 = 0;
                    ctor2 = 0;
                    ctor3 = 0;
                    ctor4++;
                    ctor5 = 0;
                }

                if (angel >= 3 && angel < 4 && !ChangeUsername)
                {
                    if (!isTimer)
                    {
                        isTimer = true;
                    }
                    ellipseList[0].Color = Brushes.Cyan;
                    ellipseList[1].Color = Brushes.Cyan;
                    ellipseList[2].Color = Brushes.Cyan;
                    ellipseList[3].Color = Brushes.Cyan;
                    ellipseList[4].Color = Brushes.Cyan;
                    ellipseList[5].Color = Brushes.Cyan;
                    if (ellipseList4.Count != 0)
                    {
                        ellipseList4[0].Color = Brushes.Cyan;
                        ellipseList4[1].Color = Brushes.Red;
                        ellipseList4[2].Color = Brushes.Cyan;
                    }
                    
                    if (ctor5 > 50)
                    {
                        isTimer = false;
                        ctTimer = 0;
                        isSwim = false;
                        isDetect = false;
                        isCamera = false;
                        isNewSwimmer = false;
                        isView = false;
                        isAccount = false;
                        isAssign = false;
                        isAssignT = false;
                        isBack = false;
                        isBack1 = false;
                        isClear = false;
                        isBack2 = false;
                        ChangePassword = false;
                        ChangeUsername = true;
                        OpenForm(new Change_Pass());
                    }
                    ctor = 0;
                    ctor1 = 0;
                    ctor2 = 0;
                    ctor3 = 0;
                    ctor4 = 0;
                    ctor5++;
                }

                if (angel >= 5 && angel < 5.5 && !isBack2)
                {
                    if (!isTimer)
                    {
                        isTimer = true;
                    }
                    ellipseList[0].Color = Brushes.Cyan;
                    ellipseList[1].Color = Brushes.Cyan;
                    ellipseList[2].Color = Brushes.Cyan;
                    ellipseList[3].Color = Brushes.Cyan;
                    ellipseList[4].Color = Brushes.Cyan;
                    ellipseList[5].Color = Brushes.Cyan;
                    if (ellipseList4.Count != 0)
                    {
                        ellipseList4[0].Color = Brushes.Cyan;
                        ellipseList4[1].Color = Brushes.Cyan;
                        ellipseList4[2].Color = Brushes.Red;
                    }

                    if (ctor2 > 50)
                    {
                        ellipseList4[0].Color = Brushes.Cyan;
                        ellipseList4[1].Color = Brushes.Cyan;
                        ellipseList4[2].Color = Brushes.Cyan;
                        isTimer = false;
                        ctTimer = 0;
                        isView = true;
                        string[] newMenuOptions = { "Person detection", "camera screen", "new swimmer", "view training", "account setting", "Swimm class" };
                        menuOptions = newMenuOptions;
                        ctt = 0;
                        isSwim = false;
                        isDetect = false;
                        isCamera = false;
                        isNewSwimmer = false;
                        isView = false;
                        isAccount = false;
                        isAssign = false;
                        isAssignT = false;
                        isBack = false;
                        isBack1 = false;
                        isClear = false;
                        isBack2 = true;
                        ChangePassword = false;
                        ChangeUsername = false;
                    }
                    ctor = 0;
                    ctor1 = 0;
                    ctor2 ++;
                    ctor3 = 0;
                    ctor4 = 0;
                    ctor5 = 0;
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            ishere = false;
            if (objectList.Count > 0)
            {
                lock (objectList)
                {
                    foreach (TuioObject tobj in objectList.Values)
                    {
                        
                        isrotate(tobj.Angle, tobj.SymbolID);
                    }
                }
            }
            DrawDubb(this.CreateGraphics());
        }
    }
}
