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
        CustomRectangle rectangle;
        List<BaseObjects> objects = new List<BaseObjects>();
        int score = 0;

        public Form1()
        {
            InitializeComponent();

            rectangle = new CustomRectangle();
            objects.Add(rectangle);

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            objects.Add(player);

            player.OnOverlap += (p, obj) =>
            {
                if (obj is Apple)
                {
                    objects.Remove(obj);
                    lblScore.Text = $"Очки: {++score}";
                    objects.Add(new Apple());
                }

                txtLogs.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLogs.Text;
            };

            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };

            marker = new Marker(pbMain.Width / 2 + 100, pbMain.Height / 2 + 100, 0);
            objects.Add(marker);

            objects.Add(new Apple());
            objects.Add(new Apple());
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var graphic = e.Graphics;

            // Заливка фона
            graphic.Clear(Color.White);

            updatePlayer();
            updateRectangle();


            // Пересечение
            foreach(var obj in objects.ToList())
            {
                if (obj != rectangle)
                {
                    if (rectangle.Overlaps(obj, graphic))
                        rectangle.changeColor(obj);
                    else
                        rectangle.restoreColors(obj);
                }

                if (obj != player && player.Overlaps(obj, graphic))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
            }

            // Прорисовка
            foreach(var obj in objects)
            {
                graphic.Transform = obj.GetTransform();
                obj.Render(graphic);
            }

        }
        private void updateRectangle()
        {
            rectangle.X += 5;
            if (rectangle.X > 1280)
            {
                rectangle.X = -200;
            }
        }
        private void updatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                float distance = MathF.Sqrt(dx * dx + dy * dy);
                dx /= distance;
                dy /= distance;

                player.vX += dx * 0.8f;
                player.vY += dy * 0.8f;

                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }

            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;

            player.X += player.vX;
            player.Y += player.vY;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbMain.Invalidate();

        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }

            marker.X = e.X;
            marker.Y = e.Y;
        }
    }
}
