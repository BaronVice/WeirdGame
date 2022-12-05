using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace WeirdGame.GraphicObjects
{
    class Apple : BaseObjects
    {
        private Random rnd = new Random();
        public Apple(){
            base.X = rnd.Next(30, 1025);
            base.Y = rnd.Next(30, 396);
            base.Angle = 0;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Green), -20, -20, 40, 40);
            g.DrawEllipse(new Pen(Color.Aqua, 2), -20, -20, 40, 40);
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