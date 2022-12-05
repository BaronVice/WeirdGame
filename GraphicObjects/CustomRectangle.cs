using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WeirdGame.GraphicObjects
{
    class CustomRectangle : BaseObjects
    {
        public CustomRectangle()
        {
            base.X = -200;
            base.Y = 250;
            base.Angle = 0;
        }

        public override void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), -100, -250, 200, 500);
        }
    }
}
