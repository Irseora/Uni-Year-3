#include <iostream>
#include <math.h>

using namespace std;

double phi(double x)
{
    // return pow(x + 1, 1.00 / 4);
    // return pow(x + 1, 1.00 / 3);

    // return 1.00 / 5 * (pow(x, 5) + 1);

    return sin(x) + 0.25;
}

void MetodaAproximatiilorSuccesive(double x0, double eps)
{
    double x[20];
    x[0] = x0;

    int n = 0;
    do
    {
        x[n+1] = phi(x[n]);
        n++;

        cout << x[n] << " - " << x[n-1] << " = " << abs(x[n] - x[n-1]) << '\t' << eps << '\n';
    } while (abs(x[n] - x[n-1]) >= eps);

    cout << n << '\t' << x[n];
}

void MetodaHeron(double a, double eps)
{
    double x[20];
    x[0] = a;

    int n = 0;
    do
    {
        x[n+1] = 0.5 * (x[n] + (a / x[n]));
        n++;
    } while (abs(x[n] - x[n-1]) >= eps);

    cout << n << '\t' << x[n];
}

int main()
{
    // double x0 = 1.1781, eps[] = { 0.0001, 0.00000001, 0.000000000001 };
    // MetodaAproximatiilorSuccesive(x0, eps[0]);

    double a = 0.5, eps[] = { 0.0001, 0.00000001, 0.000000000001 };
    MetodaHeron(a, eps[0]);

    return 0;
}