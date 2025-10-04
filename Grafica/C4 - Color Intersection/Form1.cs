using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Intersection
{
    public partial class Form1 : Form
    {
        MyGraphics graphics;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = new MyGraphics(pictureBox1);

            Map test = new Map(@"../../input.txt");
            test.Draw(graphics.g);

            test.Fill(graphics);
        }
    }
}
