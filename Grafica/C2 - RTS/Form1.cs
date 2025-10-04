using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C2___RTS
{
    public partial class Form1 : Form
    {
        MyGraphics grp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grp = new MyGraphics(pictureBox1);

            //Matrix A = new Matrix(@"../../Inputs/mat1.txt");
            //Matrix B = new Matrix(@"../../Inputs/mat2.txt");

            //Matrix Sum = A + B;
            //Matrix Prod = A * B;

            //foreach (string p in Prod.View())
            //   listBox1.Items.Add(p);

            Polygon polygon = new Polygon(@"../../Inputs/polygon.txt");
            polygon.Draw(grp.g, Color.Black);

            Polygon rotated = polygon.Rotate(10, new PointF(pictureBox1.Height / 2, pictureBox1.Width / 2));
            rotated.Draw(grp.g, Color.Red);

            /*Polygon translated = polygon.Translate(new PointF(50, 50));
            translated.Draw(grp.g, Color.Red);*/

            /*Polygon scaled = polygon.Scale(1.5f, 1.5f);
            scaled.Draw(grp.g, Color.Red);*/

            grp.Refresh();
        }
    }
}
