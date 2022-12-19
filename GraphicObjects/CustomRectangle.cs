using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace WeirdGame.GraphicObjects
{
    class CustomRectangle : BaseObjects
    {

        List<BaseObjects> enteredInRectangle = new List<BaseObjects>();
        List<BaseObjects> exitedFromRectangle = new List<BaseObjects>();

        public CustomRectangle()
        {
            base.X = -200;
            base.Y = 250;
            base.Angle = 0;
        }

        public void changeColor(BaseObjects obj)
        {
            obj.inBlack = true;
        }

        public void restoreColors(BaseObjects obj)
        {
            obj.inBlack = false;
        }

        public override void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), -100, -250, 200, 500);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddRectangle(new Rectangle(-100, -250, 200, 500));
            return path;
        }
    }
}
