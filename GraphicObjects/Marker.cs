using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace WeirdGame.GraphicObjects
{
    class Marker : BaseObjects
    {
        public static SolidBrush myBrush = new SolidBrush(Color.Red);
        public static Pen myPen = new Pen(Color.Red, 2);
        public Marker(float x, float y, float angle) : base(x, y, angle) {}

        public override void Render(Graphics g)
        {
            if (inBlack)
            {
                g.FillEllipse(blackBrush, -10, -10, 20, 20);
                g.DrawEllipse(blackPen, -15, -15, 30, 30);
                g.DrawEllipse(blackPen, -20, -20, 40, 40);
            }
            else
            {
                g.FillEllipse(myBrush, -10, -10, 20, 20);
                g.DrawEllipse(myPen, -15, -15, 30, 30);
                g.DrawEllipse(myPen, -20, -20, 40, 40);
            }

        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-10, -10, 20, 20);
            return path;
        }

    }
}
