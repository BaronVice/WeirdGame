using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WeirdGame.GraphicObjects
{
    class BaseObjects
    {
        public float X;
        public float Y;
        public float Angle;
        public Action<BaseObjects, BaseObjects> OnOverlap;

        public BaseObjects(float x, float y, float angle)
        {
            X = x;
            Y = y;
            Angle = angle;
        }
        
        public virtual void Render(Graphics g){}

        public Matrix GetTransform()
        {
            var matrix = new Matrix();
            matrix.Translate(X, Y);
            matrix.Rotate(Angle);

            return matrix;
        }

        public virtual GraphicsPath GetGraphicsPath()
        {
            return new GraphicsPath();
        }

        public virtual bool Overlaps(BaseObjects obj, Graphics g)
        {
            var path1 = this.GetGraphicsPath();
            var path2 = obj.GetGraphicsPath();

            path1.Transform(this.GetTransform());
            path2.Transform(obj.GetTransform());

            var region = new Region(path1);
            region.Intersect(path2);

            return !region.IsEmpty(g);
        }

        public virtual void Overlap(BaseObjects obj)
        {
            if (this.OnOverlap != null)
                this.OnOverlap(this, obj);
        }
    }
}
