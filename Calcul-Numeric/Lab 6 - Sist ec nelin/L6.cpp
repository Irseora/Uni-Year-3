#include <iostream>
#include <math.h>

using namespace std;

double F(double x, double y)
{
    return (double)sqrt((x * (y+5) - 1) / 2);
    // return (double)sqrt(5 - y*y);
}

double G(double x, double y)
{
    return (double)sqrt(x + 3 * (double)log10(x));
    // return 2 / x;
}

double F1(double x, double y, double z)
{
    return (double)sqrt(0.5 * (y * z + 5 * x - 1));
}

double F2(double x, double y, double z)
{
    return (double)sqrt(2 * x + (double)log(z));
}

double F3(double x, double y, double z)
{
    return (double)sqrt(x * y + 2 * z + 8);
}

void MetodaAproximatiilorSuccesive(double x0, double y0, double eps)
{
    double x[20], y[20];
    x[0] = x0;
    y[0] = y0;

    int n = 0;
    do
    {
        x[n+1] = F(x[n], y[n]);
        y[n+1] = G(x[n], y[n]);
        n++;

        // cout << x[n] << " - " << x[n-1] << " = " << abs(x[n] - x[n-1]) << '\t' << eps << '\n';
    } while (abs(x[n] - x[n-1]) >= eps || abs(y[n] - y[n-1]) >= eps);

    cout << '\n' << n << '\t' << x[n] << '\t' << y[n] << '\n';
}

void GaussSeidel3(double x0, double y0, double z0, double eps)
{
    double x[50], y[50], z[50];
    x[0] = x0;
    y[0] = y0;
    z[0] = z0;

    int n = 0;
    do 
    {
        x[n+1] = F1(x[n], y[n], z[n]);
        y[n+1] = F2(x[n+1], y[n], z[n]);
        z[n+1] = F3(x[n+1], y[n+1], z[n]);

        n++;
    } while (abs(x[n] - x[n-1]) >= eps || abs(y[n] - y[n-1]) >= eps || abs(z[n] - z[n-1]) >= eps);

    cout << '\n' << n << '\t' << x[n] << '\t' << y[n] << '\t' << z[n] << '\n';
}

void GaussSeidel2(double x0, double y0, double eps)
{
    double x[50], y[50];
    x[0] = x0;
    y[0] = y0;

    int n = 0;
    do 
    {
        x[n+1] = F(x[n], y[n]);
        y[n+1] = G(x[n+1], y[n]);

        n++;
    } while (abs(x[n] - x[n-1]) >= eps || abs(y[n] - y[n-1]) >= eps);

    cout << '\n' << n << '\t' << x[n] << '\t' << y[n] << '\n';
}

int main()
{
    // double x0 = 2.1, y0 = 1.1, eps = 0.0001;
    // MetodaAproximatiilorSuccesive(x0, y0, eps);

    // double x0 = 10, y0 = 10, z0 = 10, eps = 0.001;
    // GaussSeidel3(x0, y0, z0, eps);

    double x0 = 3.5, y0 = 2.2, eps = 0.0001;
    GaussSeidel2(x0, y0, eps);

    return 0;
}