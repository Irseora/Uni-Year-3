using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2___RTS
{
    internal class Matrix
    {
        public float[,] values;

        public static Matrix Empty;
        public int N { get { return values.GetLength(0); } }
        public int M { get { return values.GetLength(1); } }

        public Matrix(string filename)
        {
            string buffer;
            List<string> data = new List<string>();
            TextReader reader = new StreamReader(filename);

            while ((buffer = reader.ReadLine()) != null)
                data.Add(buffer);
            reader.Close();

            int n = data.Count;
            int m = data[0].Split(' ').Length;
            values = new float[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] local = data[i].Split(' ');
                for (int j = 0; j < m; j++)
                    values[i, j] = float.Parse(local[j]);
            }
        }

        public Matrix(int n, int m)
        {
            values = new float[n, m];
        }

        public Matrix(int n, PointF A)
        {
            values = new float[2, n];
            for (int i = 0; i < n; i++)
            {
                values[0, i] = A.X;
                values[1, i] = A.Y;
            }
        }

        // ------------------------------------------------------------------------------------

        public List<string> View()
        {
            List<string> toRet = new List<string>();

            for (int i = 0; i < N; i++)
            {
                string buffer = "";
                for (int j = 0; j < M; j++)
                    buffer += values[i, j] + " ";

                toRet.Add(buffer);
            }

            return toRet;
        }

        public Polygon ToPolygon()
        {
            Polygon toRet = new Polygon(values.GetLength(1));
            for (int i = 0; i < values.GetLength(1); i++)
                toRet.points[i] = new MyPoint(values[0, i], values[1, i]);
            return toRet;
        }

        public Matrix Transpose()
        {
            Matrix toRet = new Matrix(M, N);
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    toRet.values[i, j] = values[j, i];
            return toRet;
        }


        // ------------------------------------------------------------------------------------

        public static Matrix operator + (Matrix A, Matrix B)
        {
            if (A.N != B.N || A.M != B.M)
                return Matrix.Empty;

            Matrix toRet = new Matrix(A.N, A.M);

            for (int i = 0; i < A.N; i++)
                for (int j = 0; j < A.M; j++)
                    toRet.values[i, j] = A.values[i, j] + B.values[i, j];

            return toRet;
        }

        public static Matrix operator - (Matrix A, Matrix B)
        {
            if (A.N != B.N || A.M != B.M)
                return Matrix.Empty;

            Matrix toRet = new Matrix(A.N, A.M);

            for (int i = 0; i < A.N; i++)
                for (int j = 0; j < A.M; j++)
                    toRet.values[i, j] = A.values[i, j] - B.values[i, j];

            return toRet;
        }

        public static Matrix operator * (Matrix A, Matrix B)
        {
            if (A.M != B.N)
                return Matrix.Empty;

            Matrix toRet = new Matrix(A.N, B.M);

            for (int i = 0; i < A.N; i++)
                for (int j = 0; j < B.M; j++)
                {
                    toRet.values[i, j] = 0;
                    for (int k = 0; k < A.M; k++)
                        toRet.values[i, j] += A.values[i, k] * B.values[k, j];
                }
            
            return toRet;
        }
    }
}
