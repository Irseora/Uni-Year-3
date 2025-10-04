using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using C3___Grafica_Raster.Resurse;

namespace C3___Grafica_Raster
{
    public partial class Form1 : Form
    {
        Bitmap source, destination;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            source = new Bitmap(comboBox1.SelectedItem.ToString());
            sourcePictureBox.Image = source;

            destination = new Bitmap(source.Width, source.Height);
        }

        private void medianButton_Click(object sender, EventArgs e)
        {
            int k = 2;
            
            // Inside
            for (int i = k; i < source.Width - k; i++)
            {
                for (int j = k; j < source.Height - k; j++)
                {
                    List<Color> colors = new List<Color>();

                    for (int l = -k; l <= k; l++)
                        for (int c = -k; c <= k; c++)
                            colors.Add(source.GetPixel(i + l, j + c));

                    colors.Sort(delegate (Color A, Color B) { return Engine.EuclidColorDistance(A).CompareTo(Engine.EuclidColorDistance(B)); });
                    
                    destination.SetPixel(i, j, colors[colors.Count / 2]);
                }
            }

            // Contour

            destinationPictureBox.Image = destination;
        }

        private void standardiseButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = Engine.StandardiseColor(source.GetPixel(i, j), 64);
                    destination.SetPixel(i, j, color);
                }

            destinationPictureBox.Image = destination;
        }

        private void contourButton_Click(object sender, EventArgs e)
        {
            float epsilon = 10;

            standardiseButton_Click(sender, e);

            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                    source.SetPixel(i, j, destination.GetPixel(i, j));

            for (int i = 1; i < source.Width - 1; i++)
                for (int j = 1; j < source.Height - 1; j++)
                {
                    bool contour = false;
                    Color color1 = source.GetPixel(i, j);

                    for (int k = -1; k <= 1; k++)
                        for (int c = -1; c <= 1; c++)
                        {
                            Color color2 = source.GetPixel(i + k, j + c);

                            if (Math.Abs(Engine.EuclidColorDistance(color1) - Engine.EuclidColorDistance(color2)) > epsilon)
                            {
                                contour = true;
                            }
                        }

                    if (contour) destination.SetPixel(i, j, Color.Black);
                    else destination.SetPixel(i, j, Color.White);
                }

            destinationPictureBox.Image = destination;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(@"..\..\Resurse");

            foreach(string file in files)
                comboBox1.Items.Add(file);

            comboBox1.SelectedItem = comboBox1.Items[1];

            source = new Bitmap(comboBox1.SelectedItem.ToString());
            sourcePictureBox.Image = source;

            destination = new Bitmap(source.Width, source.Height);
        }
    }
}
