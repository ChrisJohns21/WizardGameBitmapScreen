using System.Drawing;

namespace FrameRateTestCSharp
{
    public class SpriteState
    {
        public string BaseResourcePath = @"C:\Users\Chris\Desktop\Resources\";
        public bool LeftState { get; set; } = false;
        public bool RightState { get; set; } = false;
        public bool UpState { get; set; } = false;
        public bool DownState { get; set; } = false;
        public bool Repaint = false;
        public int X { get; set; }
        public int Y { get; set; }
        public Point Location { get
            {
                return new Point(X, Y);
            }
        }
        public Bitmap PlayerImg { get; set; }

        public SpriteState(Bitmap playerImg)
        {
            PlayerImg = playerImg;
        }

        public void UpdateCoords()
        {
            if (LeftState)
            {
                X += -1;
            }

            if (RightState)
            {
                X += 1;
            }

            if (UpState)
            {
                Y += -1;
            }

            if (DownState)
            {
                Y += 1;
            }
        }
    }
}