using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FrameRateTestCSharp
{
    public partial class SpriteImaging : Form
    {
        public WizardSprite Player { get; set; }
        public SpriteState Player2 { get; set; }
        public SpriteImaging()
        {
            InitializeComponent();
            Player = new WizardSprite(new Bitmap(@"C:\Users\Chris\Desktop\Resources\WizardSpriteStandingForward.png"));
            Player2 = new SpriteState(new Bitmap(@"C:\Users\Chris\Desktop\Resources\Dummy.png"));
        }

        [DllImport("user32.dll", EntryPoint = "GetAsyncKeyState")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            Player.RightState = GetAsyncKeyState(Keys.Right) != 0;
            Player.LeftState = GetAsyncKeyState(Keys.Left) != 0;
            Player.DownState = GetAsyncKeyState(Keys.Down) != 0;
            Player.UpState = GetAsyncKeyState(Keys.Up) != 0;

            Player2.RightState = !Player.RightState;
            Player2.LeftState = !Player.LeftState;
            Player2.DownState = !Player.DownState;
            Player2.UpState = !Player.UpState;

            Player.UpdateBitmapSprite();
            Player.UpdateCoords();
            Player2.UpdateCoords();
            Refresh();
        }

        private void SpriteImaging_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawImage(Player2.PlayerImg, Player2.Location);
            e.Graphics.DrawImage(Player.PlayerImg, Player.Location);
        }

        private void SpriteImaging_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            timer1.Interval = 30;
            timer1.Start();
        }
    }
}