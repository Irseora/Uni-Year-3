using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C1___Geometrie_Vectoriala
{
    public partial class Form1 : Form
    {
        MyGraphics myGraphics;
        float a, b = 0f;
        Random rand;
        /*int i = 0;*/
        /*List<PointF> points;*/

        public Form1()
        {
            InitializeComponent();
            myGraphics = new MyGraphics(pictureBox1);
            rand = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DrawPolygon(myGraphics.g, Pr(4, new PointF(250, 250), 150, 0));

            /*for (float a = 0; a <= (float)(Math.PI * 2); a += 0.2f)
                DrawPolygon(myGraphics.g, Pr(4, new PointF(250, 250), 150, a));*/

            /*for (float a = 0; a <= 200; a += 10)
                DrawPolygon(myGraphics.g, Pr(4, new PointF(250, 250), a, 0));*/

            /*for (float a = 0; a <= 200; a += 10, b += 0.1f)
                DrawPolygon(myGraphics.g, Pr(6, new PointF(250, 250), a, b));*/

            /*points = IrregularPolygon(10, new PointF(250, 250), 100, 200, 0);
            DrawPolygon(myGraphics.g, points);*/

            //DrawRegularFractal(myGraphics.g, 10, new PointF(pictureBox1.Width/2, pictureBox1.Height/2), 100, 0);

            /*float R = 100;
            FillPolygon(myGraphics.g, Pr(100, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R, 0), Color.Red);
            FillPolygon(myGraphics.g, Pr(100, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.85f, 0), Color.White);*/

            /*float R = 100;
            FillPolygon(myGraphics.g, Pr(4, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R, 0), Color.Black);
            FillPolygon(myGraphics.g, Pr(4, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.95f, 0), Color.White);
            FillPolygon(myGraphics.g, Pr(4, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.7f, 0), Color.Yellow);*/

            /*float R = 230;
            FillPolygon(myGraphics.g, Pr(3, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R, (float)Math.PI + (float)Math.PI / 6), Color.Red);
            FillPolygon(myGraphics.g, Pr(3, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.9f, (float)Math.PI + (float)Math.PI / 6), Color.White);
            FillPolygon(myGraphics.g, Pr(3, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.8f, (float)Math.PI + (float)Math.PI / 6), Color.Red);
            FillPolygon(myGraphics.g, Pr(3, new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), R * 0.4f, (float)Math.PI + (float)Math.PI / 6), Color.White);*/

            // Sierpinsky Triangle Fractal
            DrawSierpinsky(myGraphics.g, new PointF(130, 30), new PointF(20, 500), new PointF(700, 110));

            myGraphics.RefreshGraphics();
        }

        void DrawSierpinsky(Graphics g, PointF A, PointF B, PointF C)
        {
            if (TwoPointDistance(A, B) > 1 && TwoPointDistance(B, C) > 1 && TwoPointDistance(A, C) > 1)
            {
                float k1 = 1, k2 = 1;

                DrawTriangle(g, A, B, C);

                PointF M = new PointF((A.X * k1 + B.X * k2) / 2, (A.Y * k1 + B.Y * k2) / (k1 + k2));
                PointF N = new PointF((A.X * k1 + C.X * k2) / 2, (A.Y * k1 + C.Y * k2) / (k1 + k2));
                PointF P = new PointF((B.X * k1 + C.X * k2) / 2, (B.Y * k1 + C.Y * k2) / (k1 + k2));

                DrawSierpinsky(g, A, M, N);
                DrawSierpinsky(g, M, B, P);
                DrawSierpinsky(g, N, P, C);
            }
        }

        public void DrawTriangle(Graphics g, PointF A, PointF B, PointF C)
        {
            g.DrawLine(Pens.Black, A, B);
            g.DrawLine(Pens.Black, A, C);
            g.DrawLine(Pens.Black, B, C);
        }

        float TwoPointDistance(PointF A, PointF B)
        {
            return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }

        void FillPolygon(Graphics g, List<PointF> points, Color fillColor)
        {
            g.FillPolygon(new SolidBrush(fillColor), points.ToArray());
            g.DrawPolygon(new Pen(fillColor), points.ToArray());
        }

        void DrawIrregularFractal(Graphics g, int n, PointF C, float minR, float maxR, float phi)
        {
            List<PointF> t = IrregularPolygon(n, C, minR, maxR, phi);

            if (AreaPolygon(C, t) > 10)
            {
                DrawPolygon(myGraphics.g, t);

                foreach (PointF p in t)
                    DrawIrregularFractal(myGraphics.g, n, p, minR / 2, maxR / 2, phi);
            }
        }

        void DrawRegularFractal(Graphics g, int n, PointF C, float R, float phi)
        {
            List<PointF> t = Pr(n, C, R, phi);

            if (AreaPolygon(C, t) > 10)
            {
                DrawPolygon(myGraphics.g, t);

                foreach (PointF p in t)
                    if (rand.Next(2) == 0)       // rand.Next() % 2
                        DrawRegularFractal(myGraphics.g, n, p, R / 2, phi + 0.2f);
            }
        }

        public float Determinant(PointF A, PointF B, PointF C)
        {
            return (A.X * B.Y + B.X * C.Y + A.Y * C.X - C.X * B.Y - A.Y * B.X - C.Y * A.X);
        }

        public float AreaTriangle(PointF A, PointF B, PointF C)
        {
            return 0.5f * (float)Math.Abs(Determinant(A, B, C));
        }

        public float AreaPolygon(PointF C, List<PointF> points)
        {
            float sum = 0;
            for (int i = 0; i < points.Count; i++)
                sum += AreaTriangle(C, points[i], points[(i + 1) % points.Count]);
            return sum;
        }

        private List<PointF> Pr(int n, PointF C, float R, float phi)
        {
            List<PointF> toRet = new List<PointF>();
            float alpha = (float)(2 * Math.PI) / n;

            for (int i = 0; i < n; i++)
            {
                float x = C.X + R * (float)Math.Cos(alpha * i + phi);
                float y = C.Y + R * (float)Math.Sin(alpha * i + phi);
                toRet.Add(new PointF(x, y));
            }

            return toRet;
        }

        private List<PointF> IrregularPolygon(int n, PointF C, float minR, float maxR, float phi)
        {
            List<PointF> toRet = new List<PointF>();
            float sum = (float)(2 * Math.PI);

            float[] segments = new float[n + 1];
            segments[0] = 0;
            segments[n] = sum;

            for (int i = 1; i < n; i++)
                segments[i] = (float)(rand.NextDouble() * sum);

            bool ok = false;
            while (!ok)
            {
                ok = true;
                for (int i = 0; i < n; i++)
                    for (int j = i + 1; j < n; j++)
                        if (segments[i] > segments[j])
                        {
                            (segments[i], segments[j]) = (segments[j], segments[i]);
                            ok = false;
                        }
            }

            for (int i = 0; i <= n; i++)
                listBox1.Items.Add(segments[i].ToString("0.000"));

            /*float[] alpha = new float[n];*/
            float[] d = new float[n];
            for (int i = 0; i < n - 1; i++)
            {
                /*alpha[i] = segments[i + 1] - segments[i];*/
                d[i] = (float)rand.NextDouble() * (maxR - minR) + minR;
            }

            for (int i = 0; i < n; i++)
            {
                /*float x = C.X + d[i] * (float)Math.Cos(alpha[i] * i + phi);
                float y = C.Y + d[i] * (float)Math.Sin(alpha[i] * i + phi);*/

                float x = C.X + d[i] * (float)Math.Cos(segments[i] + phi);
                float y = C.Y + d[i] * (float)Math.Sin(segments[i] + phi);

                toRet.Add(new PointF(x, y));
            }

            return toRet;
        }

        public void DrawPolygon(Graphics g, List<PointF> points)
        {
            myGraphics.g.DrawPolygon(Pens.Black, points.ToArray());
        }

        public void DrawPoints(Graphics g, List<PointF> points)
        {
            foreach (var point in points)
                g.DrawEllipse(Pens.Black, point.X - 1, point.Y - 1, 3, 3);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a += 10;
            b += 0.1f;

            if (a >= 200) a = 10;

            myGraphics.ClearGraphics();
            DrawPoints(myGraphics.g, Pr(6, new PointF(250, 250), a, b));
            myGraphics.RefreshGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (timer1.Enabled) timer1.Enabled = false;
            else timer1.Enabled = true;*/

            /*if (i < points.Count - 1)
                myGraphics.g.DrawLine(Pens.Black, points[i], points[i + 1]);
            else if (i == points.Count - 1)
                myGraphics.g.DrawLine(Pens.Black, points[0], points[points.Count - 1]);
            i++;*/

            myGraphics.RefreshGraphics();
        }
    }
}
