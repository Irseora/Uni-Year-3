#include <iostream>
using namespace std;

void ParabolaDeRegresie(int n, int x[], int y[])
{
    double S1 = 0, S2 = 0, S3 = 0, S4 = 0;
    double T1 = 0, T2 = 0, T3 = 0;
    for (int i = 0; i <= n; i++)
    {
        S1 += x[i];
        S2 += x[i] * x[i];
        S3 += x[i] * x[i] * x[i];
        S4 += x[i] * x[i] * x[i] * x[i];

        T1 += y[i];
        T2 += x[i] * y[i];
        T3 += x[i] * x[i] * y[i];
    }

    double d  = (n+1)*S2*S4 + 2*S1*S2*S3 - S2*S2*S2 - S1*S1*S4 - (n+1)*S3*S3;
    double d1 = (n+1)*S2*T3 + S1*S2*T2   + S1*S3*T1 - S2*S2*T1 - S1*S1*T2    - (n+1)*S3*T2;
    double d2 = (n+1)*T2*S4 + S4         + S2*S3*T1 + S1*S2*T3 - S2*S2*T2    - S1*S4*T1    - (n+1)*S3*T3;
    double d3 = S2*S4*T1    + S1*S3*T3   + S2*S3*T2 - S2*S2*T3 - S1*S4*T2    - S3*S3*T1;

    double a = d1 / d, b = d2 / d, c = d3 / d;
    cout << a << ' ' << '\t' << b << '\t' << c << '\n';
}

void Spline(double a, double b, int n, double x[], double y[])
{
    double h[1001];
    h[0] = (b - a) / 1000.0;

    for (int i = 1; i <= n; i++)
        h[i] = x[i] - x[i-1];

    double u[1001], s[1001];
    for (int k = 0; k < 1000; k++)
    {
        u[k] = a + k * h[0];
        for (int j = 1; j <= n; j++)
            if (x[j - 1] <= u[k] && u[k] <= x[j])
                s[k] = y[j-1] + (y[j] - y[j-1]) / h[j] * (u[k] - x[j-1]);
    }

    for (int k = 0; k < 1000; k++)
        cout << u[k] << '\t' << s[k] << '\n';
}

void SplinePatratic(double a, double b, int n, double x[], double y[])
{
    double h[1001];
    h[0] = (b - a) / 1000.0;

    for (int i = 1; i <= n; i++)
        h[i] = x[i] - x[i-1];

    double m[1001];
    m[0] = ((2 * h[1] + h[2]) / (h[1] * (h[1] + h[2]))) * (y[1] - y[0]) - (h[1] / (h[1] * (h[1] + h[2]))) * (y[2] - y[1]);

    for (int i = 1; i <= n; i++)
        m[i] = (2 / h[i]) * (y[i] - y[i-1]) - m[i-1];

    double u[1001], s[1001];
    for (int k = 0; k < 1000; k++)
    {
        u[k] = a + k * h[0];
        for (int j = 1; j <= n; j++)
            if (x[j - 1] <= u[k] && u[k] <= x[j])
                s[k] = ((m[j] - m[j-1]) / (2 * h[j])) * (u[k]-x[j-1]) * (u[k]-x[j-1]) + m[j-1] * (u[k] - x[j-1]) + y[j-1];
    }

    for (int k = 0; k < 1000; k++)
        cout << u[k] << '\t' << s[k] << '\n';
}

void SplineCubic(double a, double b, int n, double x[], double y[])
{
    double q = (b-a) / 1000.0;

    double h[1001];
    for (int i = 1; i <= n; i++)
        h[i] = x[i] - x[i-1];
}

int main()
{
    // int x[] = { -3, -2, -1,  0,  1,  2,  3 };
    // int y[] = {  6,  4,  1,  2,  3,  8, 11 };
    // ParabolaDeRegresie(6, x, y);
    // cout << 64.0 / 84 << '\t' << 25.0 / 28 << '\t' << 40.0 / 21 << '\n';

    double x[] = { 7.5, 10.5,  13, 15.5,  18,  21,  24, 27 };
    double y[] = { 130,  121, 128,   96, 122, 138, 114, 90 };
    int n = 7;
    double a = 7.5, b = 27;
    // Spline(a, b, n, x, y);
    SplinePatratic(a, b, n, x, y);

    return 0;
}