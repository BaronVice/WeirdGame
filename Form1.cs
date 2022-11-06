using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeirdGame.GraphicObjects;

namespace WeirdGame
{
    public partial class Form1 : Form
    {
        Player player;
        Marker marker;
        List<BaseObjects> objects = new List<BaseObjects>();

        public Form1()
        {
            InitializeComponent();

            marker = new Marker(pbMain.Width / 2 + 100, pbMain.Height / 2 + 100, 0);
            objects.Add(marker);

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            objects.Add(player);

            objects.Add(new CustomRectangle(100, 100, 45));
            objects.Add(new CustomRectangle(300, 300, 115));
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var graphic = e.Graphics;

            // Заливка фона
            graphic.Clear(Color.White);

            foreach(BaseObjects obj in objects)
            {
                graphic.Transform = obj.GetTransform();
                obj.Render(graphic);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float dx = marker.X - player.X;
            float dy = marker.Y - player.Y;

            float distance = MathF.Sqrt(dx * dx + dy * dy);
            dx /= distance;
            dy /= distance;

            player.X += dx * 2;
            player.Y += dy * 2;

            pbMain.Invalidate();

        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            marker.X = e.X;
            marker.Y = e.Y;
        }
    }
}
