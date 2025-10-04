#include <iostream>
#include <fstream>

using namespace std;

void ReadLinearSystem(string filename, int &n, double** &A, double* &b, double &e)
{
    ifstream fin(filename);

    fin >> n;
    fin >> e;

    A = new double*[n+1];
    for (int i = 0; i <= n; i++)
        A[i] = new double[n];
    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= n; j++)
            fin >> A[i][j];

    b = new double[n+1];
    for (int i = 1; i <= n; i++)
        fin >> b[i];

    fin.close();
}

void FreeMemory(double** A, double* b, double** x, int n)
{
    for (int i = 0; i <= n; i++)
        delete[] A[i];
    delete[] A;
    delete[] b;
    delete[] x;
}

void ShowSolution(double** x, int n, int k)
{
    if (x == nullptr)
    {
        cout << "Sistemul nu este definit corect.\n";
        return;
    }

    cout << "\nOprit la iteratia: " << k;

    cout << "\nSolutiile sistemului sunt:\n";
    for (int i = 1; i <= n; i++)
        cout << "x" << i << " = " << x[i][k] << '\n';
}

double** Jacobi(double** A, double* b, int n, double e, int &k)
{
    for (int i = 1; i <= n; i++)
    {
        double* sum = new double[n+1] {0};
        for (int j = 1; j <= n; j++)
            if (j != i) sum[i] += abs(A[i][j]);
        
        if (abs(A[i][i] <= sum[i]))
            return nullptr;
    }

    double** x = new double*[n+1];
    for (int i = 0; i <= n; i++)
    {
        x[i] = new double[n+1];
        x[i][0] = b[i] / A[i][i];
    }

    k = 1;
    double max;
    double* dif = new double[n+1];
    do
    {
        for (int i = 1; i <= n; i++)
        {
            double* sum = new double[n+1] {0};
            for (int j = 1; j <= n; j++)
                if (j != i)
                    sum[i] += A[i][j] * x[j][k-1];

            x[i][k] = (b[i] - sum[i]) / A[i][i];

            dif[i] = abs(x[i][k] - x[i][k-1]);
        }

        max = dif[1];
        for (int i = 2; i <= n; i++)
            if (dif[i] > max)
                max = dif[i];

        k++;
    } while (max >= e);
    
    k--;

    return x;
}

double** GaussSeidel(double** A, double* b, int n, double e, int& k)
{
    for (int i = 1; i <= n; i++)
    {
        double* sum = new double[n+1] {0};
        for (int j = 1; j <= n; j++)
            if (j != i) sum[i] += abs(A[i][j]);
        
        if (abs(A[i][i] <= sum[i]))
            return nullptr;
    }

    double** x = new double*[n+1];
    for (int i = 0; i <= n; i++)
    {
        x[i] = new double[n+1];
        x[i][0] = b[i] / A[i][i];
    }

    k = 1;
    double max;
    double* dif = new double[n+1];
    do
    {
        for (int i = 1; i <= n; i++)
        {
            double* sum1 = new double[n+1] {0};
            for (int j = 1; j <= i-1; j++)
                sum1[i] += A[i][j] * x[j][k];

            double* sum2 = new double[n+1] {0};
            for (int j = i+1; j <= n; j++)
                if (i != j)
                    sum2[i] += A[i][j] * x[j][k-1];

            x[i][k] = (b[i] - sum1[i] - sum2[i]) / A[i][i];

            dif[i] = abs(x[i][k] - x[i][k-1]);
        }

        max = dif[1];
        for (int i = 2; i <= n; i++)
            if (dif[i] > max)
                max = dif[i];

        k++;
    } while (max >= e);
    
    k--;
    return x;
}

int main()
{
    double** A;
    double* b;
    double e;
    int n;
    ReadLinearSystem("jacobi.in", n, A, b, e);

    int k;
    double** x = GaussSeidel(A, b, n, e, k);
    ShowSolution(x, n, k);

    cout << "---------------------------";

    x = Jacobi(A, b, n, e, k);
    ShowSolution(x, n, k);

    FreeMemory(A, b, x, n);
    return 0;
}