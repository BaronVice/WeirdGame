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

        public BaseObjects(float x, float y, float angle)
        {
            X = x;
            Y = y;
            Angle = angle;
        }
        
        // Отрисовка объекта
        public virtual void Render(Graphics g){}

        public Matrix GetTransform()
        {
            var matrix = new Matrix();
            matrix.Translate(X, Y);
            matrix.Rotate(Angle);

            return matrix;
        }
    }
}
