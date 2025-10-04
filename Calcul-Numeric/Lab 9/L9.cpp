#include <iostream>
#include <math.h>

using namespace std;
using namespace std;

// sin x
// double a = M_PI / 6.0, b = M_PI / 3.0;
// double fa = 1.0 / 2.0, fb = sqrt(3) / 2.0;
// double dfa = sqrt(3) / 2.0, dfb = 1.0/2.0;

// sqrt(x)
// double a = 4, b = 9;
// double fa = 2, fb = 3;
// double dfa = 1/4, dfb = 1/6;

// double Hermit2NoduriDuble(double x)
// {
//     return (((b-x)*(b-x) * (x-a)) / ((b-a)*(b-a))) * dfa
//          - (((x-a)*(x-a) * (b-x)) / ((b-a)*(b-a))) * dfb
//          + (((b-x)*(b-x) * (2 * (x-a) + (b-a))) / ((b-a)*(b-a)*(b-a))) * fa
//          + (((x-a)*(x-a) * (2 * (b-x) + (b-a))) / ((b-a)*(b-a)*(b-a))) * fb;
// }

double a = 0.0, b = 1.0;

double Bernstein1(double x)
{
    return 1 - x + x * M_E;
}

double Bernstein2(double x)
{
    return (1-x)*(1-x) + 2 * x * (1-x) * sqrt(M_E) + x*x * M_E;
}

double Bernstein3(double x)
{
    return (1-x)*(1-x)*(1-x) + 3 * ((1-x)*(1-x)) * x * pow(M_E, 1.0/3) + 3 * (x*x) * (1-x) * pow(M_E, 2.0/3) + (x*x*x) * M_E;
}

double Bernstein4(double x)
{
    return (1-x)*(1-x)*(1-x)*(1-x) + 4 * ((1-x)*(1-x)*(1-x)) * pow(M_E, 1.0/4) + 6 * ((1-x)*(1-x)) * (x*x) * sqrt(M_E) + 4 * (1-x) * (x*x*x) * pow(M_E, 3.0/4) + (x*x*x*x) * M_E;
}

void DreaptaRegresie(double x[], double y[], int n)
{
    double S1 = 0, S2 = 0, T1 = 0, T2 = 0;
    for (int i = 0; i < n; i++)
    {
        S1 += x[i];
        S2 += (x[i] * x[i]);
        T1 += y[i];
        T2 += (x[i] * y[i]);
    }

    double d = n * S2 - S1 * S1;
    double d1 = n * T2 - S1 * T1;
    double d2 = S2 * T1 - T2 * S1;

    double a = d1 / d;
    double b = d2 / d;

    cout << a << '\t' << b << '\n';
}

int main()
{
    // double x[1001];
    
    // // double P[1001];
    // double B1[1001], B2[1001], B3[1001], B4[1001];
    
    // // double h = (b - a) / 1000;
    // double h = 1.0 / 1000;

    // for (int i = 0; i <= 1000; i++)
    // {
    //     x[i] = a + i * h;
    //     B1[i] = Bernstein1(x[i]);
    //     B2[i] = Bernstein2(x[i]);
    //     B3[i] = Bernstein3(x[i]);
    //     B4[i] = Bernstein4(x[i]);

    //     cout << x[i] << '\t' << B1[i] << '\t' << B2[i] << '\t' << B3[i] << '\t' << B4[i] << '\n';
    // }

    int n = 6;
    double x[] = { 1, 3, 4, 6, 8, 9 };
    double y[] = { 1, 2, 4, 4, 5, 3 };

    DreaptaRegresie(x, y, n);
    cout << 95.0/281 << '\t' << 399.0/281;

    return 0;
}