using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace WeirdGame.GraphicObjects
{
    class Marker : BaseObjects
    {
        public Marker(float x, float y, float angle) : base(x, y, angle) {}

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red), -10, -10, 20, 20);
            g.DrawEllipse(new Pen(Color.Red, 2), -15, -15, 30, 30);
            g.DrawEllipse(new Pen(Color.Red, 2), -20, -20, 40, 40);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-10, -10, 20, 20);
            return path;
        }

    }
}
