using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Color_Intersection
{
    internal class Map
    {
        List<Polygon> polygons;
        PointF point;
        Color fillColor;

        public Map(string filename)
        {
            TextReader reader = new StreamReader(filename);
            List<string> data = new List<string>();
            string buffer;

            while ((buffer = reader.ReadLine()) != null)
                data.Add(buffer);

            reader.Close();

            polygons = new List<Polygon>();
            for (int i = 0; i < data.Count - 2; i++)
                polygons.Add(new Polygon(data[i]));

            string[] line = data[data.Count - 2].Split(' ');
            point = new PointF(float.Parse(line[0]), float.Parse(line[1]));

            line = data[data.Count - 1].Split(' ');
            fillColor = Color.FromArgb(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]));

            for (int i = 0; i < 3; i++)
                polygons.Add(new Polygon());
        }

        public void Draw(Graphics handler)
        {
            foreach (Polygon polygon in polygons)
                polygon.Draw(handler);
        }

        public void Fill(MyGraphics handler)
        {
            Queue<PointF> queue = new Queue<PointF>();
            queue.Enqueue(point);

            handler.bmp.SetPixel((int)point.X, (int)point.Y, Color.Red);

            while (queue.Count > 0)
            {
                PointF current = queue.Dequeue();

                int[] modifierX = { -1,  0,  1,  0 };
                int[] modifierY = {  0, -1,  0,  1 };

                for (int i = 0; i < 4; i++)
                {
                    PointF neighbor = new PointF(current.X + modifierX[i], current.Y + modifierY[i]);
                    if (handler.bmp.GetPixel((int)neighbor.X, (int)neighbor.Y) == handler.backColor)
                    {
                        handler.bmp.SetPixel((int)neighbor.X, (int)neighbor.Y, fillColor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}
