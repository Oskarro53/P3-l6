using System;

namespace Zad1;

/// <summary>
/// Zadeklaruj delegację o nazwie Function, który przyjmuje parametr x typu double
/// i zwraca wartość typu double. <br/>
/// Zaimplementuj statyczną metodę NewtonRootFinding, która przyjmuje funkcję f typu Function,
/// funkcję pochodną df typu Function (z domyślną wartością null), punkt początkowy x0
/// (z domyślną wartością 0) oraz dokładność eps (z domyślną wartością 1e-6).
/// Metoda powinna zwracać obliczony pierwiastek równania metodą Newtona.<br/>
/// Jeśli funkcja pochodna df jest równa null w parametrze,
/// zainicjuj ją na początku metody używając przybliżenia:
/// "(f(x + eps) - f(x - eps)) / (2 * eps)".<br/>
/// Metoda Newtona: https://en.wikipedia.org/wiki/Newton%27s_method <br/>
/// Następnie napisz trzy metody bezparametrowe zwracające pierwiastki funkcji
/// przy użyciu metody Newtona:<br/>
/// - FindLinearRoot - Dla funkcji f(x) = x - 2. Przekaż dokładną pochodną.<br/>
/// - FindQuadraticRoot - Dla funkcji f(x) = x * x + 2 * x + 1. Przekaż null jako pochodną.<br/>
/// - FindSinRoot - Dla funkcji f(x) = sin(x). Przekaż dokładną pochodną i punkt startowy x0 = 2.
///   Przekaż funkcję sin i cos przez referencję do metod: Math.Sin i Math.Cos.
/// </summary>
public static class Numerics
{
    // TODO: Function

    public delegate double Function(double x);
    
    // TODO: NewtonRootFinding

    public static double NewtonRootFinding(Function f, Function? df = null, double x0 = 0, double eps = 1e-6)
    {
        if (df == null)
            df = x => ((f(x + eps) - f(x - eps)) / (2 * eps));
        double xStare = x0;
        double xNowe = xStare - (f(xStare) / df(xStare));
        while (Math.Abs(xStare - xNowe) > eps)
        {
            xStare = xNowe;
            xNowe = xStare - (f(xStare) / df(xStare));
        }
        
        return xNowe;
    }

    public static double FindLinearRoot()
    {
        // TODO: FindLinearRoot f(x) = x - 2
        return NewtonRootFinding(x => x - 2, x => 1);
    }

    public static double FindQuadraticRoot()
    {
        // TODO: FindQuadraticRoot f(x) = x * x + 2 * x + 1
        return NewtonRootFinding(x => x * x + 2 * x + 1);
    }

    public static double FindSinRoot()
    {
        // TODO: FindSinRoot f(x) = sin(x)
        return NewtonRootFinding(Math.Sin, Math.Cos, 2);
    }
}