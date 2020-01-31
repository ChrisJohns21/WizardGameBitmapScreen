using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FrameRateTestCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private Bitmap PlayerImg = new Bitmap(@"C:\Users\Chris\Desktop\Resources\WizardSpriteStandingForward.png");
        private Rectangle PlayerRect;
        private int MoveStep = 3;

        [DllImport("user32.dll", EntryPoint = "GetAsyncKeyState")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            PlayerImg.Dispose(); 
        }

        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            PlayerRect = new Rectangle(System.Convert.ToInt32((this.ClientSize.Width / (double)2) - (PlayerImg.Width / (double)2)), System.Convert.ToInt32((this.ClientSize.Height / (double)2) - (PlayerImg.Height / (double)2)), PlayerImg.Width, PlayerImg.Height);
            this.DoubleBuffered = true; 
            timer1.Interval = 30; 
            timer1.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            bool repaint = false;

            if (GetAsyncKeyState(Keys.Left) != 0)
            {
                if (PlayerRect.X - MoveStep < 0)
                    PlayerRect.X = 0; 
                else
                    PlayerRect.X -= MoveStep;
                repaint = true; 
            }

            if (GetAsyncKeyState(Keys.Right) != 0)
            {
                if (PlayerRect.X + MoveStep + PlayerRect.Width > this.ClientSize.Width)
                    PlayerRect.X = this.ClientSize.Width - PlayerRect.Width;
                else
                    PlayerRect.X += MoveStep;
                repaint = true; 
            }

            if (GetAsyncKeyState(Keys.Up) != 0)
            {
                if (PlayerRect.Y - MoveStep < 0)
                    PlayerRect.Y = 0;
                else
                    PlayerRect.Y -= MoveStep;
                repaint = true;
            }

            if (GetAsyncKeyState(Keys.Down) != 0)
            {
                if (PlayerRect.Y + MoveStep + PlayerRect.Height > this.ClientSize.Height)
                    PlayerRect.Y = this.ClientSize.Height - PlayerRect.Height;
                else
                    PlayerRect.Y += MoveStep;
                repaint = true;
            }

            if (repaint)
                this.Refresh(); 
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawImage(PlayerImg, PlayerRect);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Hide();

            SpriteImaging SI = new SpriteImaging();
            SI.Show();

        }
    }
}