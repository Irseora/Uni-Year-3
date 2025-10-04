#include <iostream>
#include <math.h>

using namespace std;

double F(double x)
{
    //return 1 / (1 + x);
    // return (1 / (sqrt(2 * M_PI))) * pow(M_E, -((x*x)/2));
    return 2*x - (3 / (x+1));
}

double DF(double x)
{
    // return (-1) / ((x+1)*(x+1));
    return 0; 
}  

void CuadraturaSimpson(double a, double b, int n)
{
    double x[1000];
    for (int i = 0; i < n; i++)
        x[i] = a + ((i * (b-a)) / n);

    double T = 0, M = 0;
    for (int i = 1; i < n; i++)
    {
        T += F(x[i]) + F(x[i-1]);
        M += F((x[i-1] + x[i]) / 2);
    }
        
    double S = ((b-a) / (6*n)) * (T + 4 * M);
    cout << S;
}

void CuadraturaCorectataSimspon(double a, double b, int n, double dfa, double dfb)
{
    double x[1000];
    for (int i = 0; i < n; i++)
        x[i] = a + ((i * (b-a)) / n);

    double T = 0, M = 0;
    for (int i = 1; i < n; i++)
    {
        T += F(x[i]) + F(x[i-1]);
        M += F((x[i-1] + x[i]) / 2);
    }

    cout << T << '\t' << M << '\n';

    double S = ((b-a) / (30*n)) * (7*T + 16*M) - (((b-a)*(b-a)) / (60*n*n)) * (dfb - dfa);
    cout << S;
}

void CuadraturaNewton(double a, double b, int n)
{
    double x[1000];
    for (int i = 0; i <= n; i++)
        x[i] = a + ((i * (b-a)) / n);

    double y[1000], z[1000];
    for (int i = 1; i <= n; i++)
    {
        y[i] = x[i-1] + (1/3) * (x[i] - x[i-1]);
        z[i] = x[i-1] + (2/3) * (x[i] - x[i-1]);
    }

    double T = 0, U = 0, V = 0;
    for (int i = 1; i <= n; i++)
    {
        T += F(x[i]) + F(x[i-1]);
        U += F(y[i]);
        V += F(z[i]);
    }

    double S = ((b-a) / (8*n)) * (T + 3*U + 3*V);
    cout << S;

    double aprox = (3 * ((b-a) / 3)) / 8 * (F(x[0]) + 3*F(x[1]) + 3*F(x[2]) + F(x[3]));
    cout << '\t' << aprox;
}

int main()
{
    double a = 1, b = 2;
    
    //CuadraturaSimpson(a, b, 4);
    //cout << '\t';
    //CuadraturaSimpson(a, b, 16);
    //cout << '\n';

    //double dfa = 0, dfb = -0.24197;
    //CuadraturaCorectataSimspon(a, b, 10, dfa, dfb);

    CuadraturaNewton(a, b, 3);

    return 0;
}