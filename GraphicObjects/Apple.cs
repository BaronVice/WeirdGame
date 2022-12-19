using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace WeirdGame.GraphicObjects
{
    class Apple : BaseObjects
    {
        public static SolidBrush myBrush = new SolidBrush(Color.Green);
        public static Pen myPen = new Pen(Color.Aqua, 2);

        private Random rnd = new Random();
        public Apple(){
            base.X = rnd.Next(30, 1025);
            base.Y = rnd.Next(30, 396);
            base.Angle = 0;
        }

        public override void Render(Graphics g)
        {
            if (inBlack)
            {
                g.FillEllipse(blackBrush, -20, -20, 40, 40);
                g.DrawEllipse(blackPen, -20, -20, 40, 40);
            }
            else
            {
                g.FillEllipse(myBrush, -20, -20, 40, 40);
                g.DrawEllipse(myPen, -20, -20, 40, 40);
            }
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-20, -20, 40, 40);
            return path;
        }

        public void generatePosition()
        {

        }

    }
}