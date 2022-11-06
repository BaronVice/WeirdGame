using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WeirdGame.GraphicObjects
{
    class CustomRectangle : BaseObjects
    {
        public CustomRectangle(float x, float y, float angle) : base(x, y, angle){}

        public override void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Yellow), -50, -30, 100, 60);
            g.DrawRectangle(new Pen(Color.Red, 2), -50, -30, 100, 60);
        }
    }
}
