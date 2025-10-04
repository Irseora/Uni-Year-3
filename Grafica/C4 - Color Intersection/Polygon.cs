using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Intersection
{
    internal class Polygon
    {
        public PointF[] points;
        public static Random random = new Random();

        public Polygon(string data)
        {
            string[] strings = data.Split(' ');
            points = new PointF[strings.Length / 2];

            for (int i = 0; i < strings.Length; i += 2)
            {
                float X = float.Parse(strings[i]);
                float Y = float.Parse(strings[i + 1]);

                points[i / 2] = new PointF(X, Y);
            }
        }

        public Polygon()
        {
            int n = random.Next(3, 20);
            points = new PointF[n];

            for (int i = 0; i < n; i++)
                points[i] = new PointF(random.Next(1024), random.Next(600));
        }

        public void Draw(Graphics handler)
        {
            for (int i = 0; i < points.Length - 1; i++)
                handler.DrawLine(Pens.Black, points[i], points[i + 1]);
            handler.DrawLine(Pens.Black, points[0], points[points.Length - 1]);
        }
    }
}
