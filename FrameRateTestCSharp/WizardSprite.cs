using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameRateTestCSharp
{
    public class WizardSprite : SpriteState
    {
        public bool Frame { get; set; } // either Standing or Walking sprite
        public WizardSprite(Bitmap playerImg) : base(playerImg)
        {
        }
        public void UpdateBitmapSprite()
        {
            var state = Frame ? "Standing" : "Walking";
            var direction = "Forward";
            // if statements based on state to update direction

            if (LeftState)
            {
                direction = "Left";
            }

            if (RightState)
            {
                direction = "Right";
            }

            if (UpState)
            {
                direction = "Backward";
            }

            if (DownState)
            {
                direction = "Forward";
            }
            var path = $@"C:\Users\Chris\Desktop\Resources\WizardSprite{state}{direction}.png";
            PlayerImg = new Bitmap(path);

            Frame = !Frame;
        }

    }
}