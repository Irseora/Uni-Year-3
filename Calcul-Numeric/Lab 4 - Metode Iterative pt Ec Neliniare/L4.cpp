#include <iostream>
#include <math.h>

using namespace std;

double Function(double x)
{
    return x*x*x - x - 1;
    // return x*x*x*x*x - 5*x + 1;
    // return x*x - 2;
}

double DFunction(double x)
{
    return 3*x*x - 1;
    // return 5*x*x*x*x - 5;
    // return 2 * x;
}

// Converge mai rapid la sol. decat met. coardei
void MetodaTangentei(double a, double b, double eps, double dda)
{
    double x[100];

    if (Function(a) * dda > 0)
        x[0] = a;
    else
        x[0] = b;

    int i = 0;
    do {
        x[i+1] = x[i] - Function(x[i]) / DFunction(x[i]);
        i++;
    } while (abs(x[i] - x[i-1]) >= eps);

    cout << i << '\t' << x[i];
}

void MetodaTangenteiPtRadicali(double c, double k, double eps)
{
    float x[100];

    if (1 > c) x[0] = 1;
    else x[0] = c;

    int i = 0;
    do {
        x[i+1] = x[i] - (pow(x[i], k) - c) / (k * pow(x[i], k-1));
        i++;
    } while (abs(x[i] - x[i-1]) >= eps);

    cout << i << '\t' << x[i];
}

void Radicali(double eps)
{
    float x[100];

    for (int j = 0; j < 10; j++)
    {
        if (1 > j) x[0] = 1;
        else x[0] = j;

        int i = 0;
        do {
            x[i+1] = x[i] - (pow(x[i], 2) - j) / (2 * pow(x[i], 1));
            i++;
        } while (abs(x[i] - x[i-1]) >= eps);

        cout << i << '\t' << x[i] << '\n';
    }
}

void MetodaTangenteiModif(double a, double b, double eps, double dda)
{
    double x[100];

    if (Function(a) * dda > 0)
        x[0] = a;
    else
        x[0] = b;

    double dd = 11;

    int i = 0;
    do {
        x[i+1] = x[i] - Function(x[i]) / dd;
        i++;
    } while (abs(x[i] - x[i-1]) >= eps);

    cout << i << '\t' << x[i];
}

int main()
{
    // double a = 0, b = 1, eps = 0.001, dda = 11;
    // MetodaTangentei(a, b, eps, dda);

    // double c = 2, k = 3, eps = 0.001;
    // MetodaTangenteiPtRadicali(c, k, eps);

    // double eps = 0.001;
    // Radicali(eps);

    double a = 1, b = 2, eps = 0.0001, dda = 6;
    MetodaTangenteiModif(a, b, eps, dda);

    return 0;
}