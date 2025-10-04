#include <iostream>
#include <fstream>

using namespace std;

void ReadLinearSystem(string filename, int &n, double** &A, double* &b)
{
    ifstream fin(filename);

    fin >> n;

    A = new double*[n];
    for (int i = 0; i < n; i++)
        A[i] = new double[n];
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            fin >> A[i][j];

    b = new double[n];
    for (int i = 0; i < n; i++)
        fin >> b[i];

    fin.close();
}

void FreeMemory(double** A, double* b, double* x, int n)
{
    for (int i = 0; i < n; i++)
        delete[] A[i];
    delete[] A;
    delete[] b;
    delete[] x;
}

void ShowSolution(double* x, int n)
{
    if (x == nullptr)
    {
        cout << "Sistemul nu este definit corect.\n";
        return;
    }

    cout << "\nSolutiile sistemului sunt:\n";
    for (int i = 0; i < n; i++)
        cout << "x" << i+1 << " = " << x[i] << '\n';
}

double* SolveSuperiorTriangularSystem(int &n, double** A, double* b)
{
    // Check if the system is superior triangular
    for (int i = 0; i < n; i++)
        for (int j = 0; j < i; j++)
            if (A[i][j] != 0)
                return nullptr;

    // Init solution
    double* x = new double[n+1];
    x[n-1] = b[n-1] / A[n-1][n-1];

    // Solve the system
    for (int i = n - 2; i >= 0; i--)
    {
        double sum = 0;
        for (int j = i + 1; j < n; j++)
            sum += A[i][j] * x[j];

        x[i] = (b[i] - sum) / A[i][i];
        if (x[i] == -0) x[i] = 0;
    }

    return x;
}

double* SolveInferiorTriangularSystem(int &n, double** A, double* b)
{
    // Check if the system is inferior triangular
    for (int i = 0; i < n; i++)
        for (int j = i + 1; j < n; j++)
            if (A[i][j] != 0)
                return nullptr;

    // Init solution
    double* x = new double[n+1];
    x[0] = b[0] / A[0][0];

    // Solve the system
    for (int i = 1; i < n; i++)
    {
        double sum = 0;
        for (int j = 0; j < i; j++)
            sum += A[i][j] * x[j];

        x[i] = (b[i] - sum) / A[i][i];
        if (x[i] == -0) x[i] = 0;
    }

    return x;
}

double* GaussianElimination(int n, double** AIn, double* bIn)
{
    // Init A
    double*** A = new double**[n];
    for (int i = 0; i < n; i++)
    {
        A[i] = new double*[n];
        for (int j = 0; j < n; j++)
            A[i][j] = new double[n-1];
    }

    // Copy AIn into A
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            A[i][j][0] = AIn[i][j];

    // Init b
    double** b = new double*[n];
    for (int i = 0; i < n; i++)
        b[i] = new double[n-1];

    // Copy bIn into b
    for (int i = 0; i < n; i++)
        b[i][0] = bIn[i];

    // Turn into superior triangular system
    for (int k = 0; k < n - 1; k++)
    {
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (i <= k)
                    A[i][j][k+1] = A[i][j][k];
                else if (j <= k)
                    A[i][j][k+1] = 0;
                else
                    A[i][j][k+1] = A[i][j][k] - A[i][k][k] * A[k][j][k] / A[k][k][k];
        
        for (int i = 0; i < n; i++)
            if (i <= k)
                b[i][k+1] = b[i][k];
            else
                b[i][k+1] = b[i][k] - A[i][k][k] * b[k][k] / A[k][k][k];
    }

    // Copy A back into AIn
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            AIn[i][j] = A[i][j][n-1];

    // Copy b back into bIn
    for (int i = 0; i < n; i++)
        bIn[i] = b[i][n-1];

    // Solve
    return SolveSuperiorTriangularSystem(n, AIn, bIn);
}

double** MultiplyMatrices(int n, double** mat1, double** mat2)
{
    double** result = new double*[n];
    for (int i = 0; i < n; i++)
        result[i] = new double[n];

    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
        {
            result[i][j] = 0;

            for (int k = 0; k < n; k++)
                result[i][j] += mat1[i][k] * mat2[k][j];
        }

    return result;
}

double* SolveTridiagonalSystem(int n, double** A, double* B)
{
    // Check if the system is tridiagonal
    // for (int i = 0; i < n; i++)
    //     for (int j = 0; j < n; j++)
    //         if (abs(i - j) > 1 && A[i][j] != 0)
    //             return nullptr;

    // Indexii a
    double* a = new double[n];
    for (int i = 0; i < n; i++)
        {
            a[i] = A[i][i];
            cout << a[i] << " ";
        }
    cout << '\n';

    // Indexii b
    double* b = new double[n];
    for (int i = 1; i < n; i++)
        {
            b[i] = A[i][i-1];
            cout << b[i] << " ";
        }
    cout << '\n';

    // Indexii C
    double* c = new double[n];
    for (int i = 0; i < n-1; i++)
    {
        c[i] = A[i][i+1];
        cout << c[i] << " ";
    }
    cout << '\n';

    double* u = new double[n];
    double* l = new double[n];
    double* p = new double[n];

    l[0] = a[0];

    for (int i = 0; i < n; i++)
    {
        if (i > 0)
        {
            p[i] = b[i];
            l[i] = a[i] - b[i] * u[i-1];
        }

        u[i] = c[i] / l[i];
    }

    double** L = new double*[n];
    for (int i = 0; i < n; i++)
        L[i] = new double[n];

    double** U = new double*[n];
    for (int i = 0; i < n; i++)
        U[i] = new double[n];

    for (int i = 0; i < n; i++)
    {
        L[i][i] = l[i];
        if (i > 0) L[i][i-1] = p[i];
        if (i < n-1) U[i][i+1] = u[i];
    }

    // >???

    return nullptr;
}

int main()
{
    int n;
    double** A;
    double* b;
    ReadLinearSystem("sistemsup.in", n, A, b);

    double* x = SolveSuperiorTriangularSystem(n, A, b);
    ShowSolution(x, n);
    
    FreeMemory(A, b, x, n);
    return 0;
}