using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WeirdGame.GraphicObjects
{
    class Player : BaseObjects
    {
        public Player(float x, float y, float angle) : base(x, y, angle) {}

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), -25, -25, 50, 50);
            g.DrawEllipse(new Pen(Color.Black, 2), -25, -25, 50, 50);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 35, 0);
        }

    }
}
