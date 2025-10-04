using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3___Grafica_Raster.Resurse
{
    public static class Engine
    {
        public static double EuclidColorDistance(Color color)
        {
            return Math.Sqrt(color.R * color.R + color.G * color.G + color.B * color.B);
        }

        public static double ManhattanColorDistance(Color color)
        {
            return color.R + color.G + color.B;
        }

        public static Color StandardiseColor(Color color, int k)
        {
            int R = (color.R / k) * k;
            int G = (color.G / k) * k;
            int B = (color.B / k) * k;

            return Color.FromArgb(R, G, B);
        }
    }
}
