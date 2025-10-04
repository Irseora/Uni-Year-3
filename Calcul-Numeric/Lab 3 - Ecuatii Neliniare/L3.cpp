#include <iostream>
using namespace std;

float Function(float x)
{
    return x*x*x - 3;
}

float MetodaBijectiei(float a, float b, float eps)
{
    float mid = (a + b) / 2;

    if (b - mid < eps) return mid;

    if (Function(b) * Function(mid) < 0)
        return MetodaBijectiei(mid, b, eps);
    else
        return MetodaBijectiei(a, mid, eps);
}

void MetodaCoardei(float a, float b, float eps, float dda, float ddb)
{
    float x[100];

    if (Function(a) * dda < 0)
    {
        x[0] = a;
        // x[1] = x[0] - Function(x[0]) / (Function(b) - Function(x[0])) * (b - x[0]);

        int i = 0;
        do {
            x[i+1] = x[i] - Function(x[i]) / (Function(b) - Function(x[i])) * (b - x[i]);
            i++;
        } while (abs(x[i] - x[i-1]) >= eps);

        cout << i << '\t' << x[i];
        return;
    }

    if (Function(b) * ddb < 0)
    {
        x[0] = b;

        int i = 0;
        do {
            x[i+1] = x[i] - Function(x[i]) / (Function(a) - Function(x[i])) * (a - x[i]);
            i++;
        } while (abs(x[i] - x[i-1]) >= eps);

        cout << i << '\t' << x[i];
        return;
    }
}

int main()
{
    float a = 1, b = 2, eps = 0.0001, dda = 6, ddb = 12;

    //float res = MetodaBijectiei(a, b, eps);
    //cout << res;

    MetodaCoardei(a, b, eps, dda, ddb);

    return 0;
}