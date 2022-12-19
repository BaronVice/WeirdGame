using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace WeirdGame.GraphicObjects
{
    class Player : BaseObjects
    {
        public static SolidBrush myBrush = new SolidBrush(Color.Blue);
        public static Pen myPen = new Pen(Color.Black, 2);
        public Action<Marker> OnMarkerOverlap;
        public float vX, vY;
        public Player(float x, float y, float angle) : base(x, y, angle) {}

        public override void Render(Graphics g)
        {
            if (inBlack)
            {
                g.FillEllipse(blackBrush, -25, -25, 50, 50);
                g.DrawEllipse(blackPen, -25, -25, 50, 50);
                g.DrawLine(blackPen, 0, 0, 35, 0);
            }
            else
            {
                g.FillEllipse(myBrush, -25, -25, 50, 50);
                g.DrawEllipse(myPen, -25, -25, 50, 50);
                g.DrawLine(myPen, 0, 0, 35, 0);
            }
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-25, -25, 50, 50);
            return path;
        }

        public override void Overlap(BaseObjects obj)
        {
            base.Overlap(obj);

            if (obj is Marker)
                OnMarkerOverlap(obj as Marker);
        }

    }
}
