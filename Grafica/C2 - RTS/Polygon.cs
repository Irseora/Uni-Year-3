using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//                            1 0 x
// TRANSLATIE: P(px, py), T = 0 1 y  => P' = P * T
//                            0 0 1

//              cos t  -sin t  0
// ROTATIE: R = sin t   cos t  0  => P' = P * R
//                0       0    1
//              (fata de origine)

//
// ROTATIE: R = 
//

//              x 0 0
// SCALARE: S = 0 y 0  => P' = P * S
//              0 0 1

namespace C2___RTS
{
    internal class MyPoint
    {
        public float X, Y;

        public MyPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        // ------------------------------------------------------------------------------------

        public void Draw(Graphics handler, Color color)
        {
            Pen pen = new Pen(color);
            handler.DrawEllipse(pen, X - 3, Y - 3, 7, 7);
        }
    }

    internal class Polygon
    {
        public MyPoint[] points;

        public Polygon(string filename)
        {
            string buffer;
            TextReader reader = new StreamReader(filename);
            List<string> data = new List<string>();

            while ((buffer = reader.ReadLine()) != null)
                data.Add(buffer);

            reader.Close();

            points = new MyPoint[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                float X = float.Parse(data[i].Split(' ')[0]);
                float Y = float.Parse(data[i].Split(' ')[1]);
                points[i] = new MyPoint(X, Y);
            }
        }

        public Polygon(int n)
        {
            points = new MyPoint[n];
        }

        // ------------------------------------------------------------------------------------

        public void Draw(Graphics handler, Color color)
        {
            Pen pen = new Pen(color);

            for (int i = 0; i < points.Length; i++)
                handler.DrawLine(pen, points[i].X, points[i].Y, points[(i + 1) % points.Length].X, points[(i + 1) % points.Length].Y);
            
            foreach (MyPoint p in points)
                p.Draw(handler, color);
        }

        public Matrix ToMatrix()
        {
            Matrix toRet = new Matrix(2, points.Length);
            for (int i = 0; i < points.Length; i++)
            {
                toRet.values[0, i] = points[i].X;
                toRet.values[1, i] = points[i].Y;
            }
            return toRet;
        }

        public Polygon Translate(PointF translation)
        {
            Matrix Translation = new Matrix(points.Length, translation);
            Matrix Polygon = this.ToMatrix();
            Matrix Translated = Polygon + Translation;

            return Translated.ToPolygon();
        }

        public Polygon Scale(float scaleX, float scaleY)
        {
            Matrix Scaleing = new Matrix(2, 2);
            Scaleing.values[0, 0] = scaleX;
            Scaleing.values[0, 1] = 0;
            Scaleing.values[1, 0] = 0;
            Scaleing.values[1, 1] = scaleY;

            Matrix Polygon = this.ToMatrix().Transpose();
            Matrix Scaled = Polygon * Scaleing;

            return Scaled.Transpose().ToPolygon();
        }

        public Polygon Rotate(float angle, PointF pivot)
        {
            Matrix Rotation = new Matrix(2, 2);
            Rotation.values[0, 0] = (float)Math.Cos(angle);
            Rotation.values[0, 1] = -(float)Math.Sin(angle);
            Rotation.values[1, 0] = (float)Math.Sin(angle);
            Rotation.values[1, 1] = (float)Math.Cos(angle);

            Matrix Pivot = new Matrix(points.Length, pivot);
            Matrix Polygon = this.ToMatrix();
            Matrix Rotated = Rotation * (Polygon - Pivot) + Pivot;

            return Rotated.ToPolygon();
        }
    }
}
