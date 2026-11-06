namespace Zad2;

public static class Numerics
{
    // TODO: Function
    
    public delegate double Function(double x);

    // TODO: HalleyRootFinding

    public static double HalleyRootFinding(Function f, Function? df = null, Function? ddf = null, double x0 = 0,
        double eps = 1e-6)
    {
        if (df == null)
        {
            df = x => (f(x + eps) - f(x - eps)) / (2 * eps);
        }

        if (ddf == null)
        {
            ddf = x => (df(x + eps) - df(x - eps)) / (2 * eps);
        }

        double xNowe = x0;
        double xStare;
        do
        {
            xStare = xNowe;
            xNowe = xStare - 2 * f(xStare) * df(xStare) / (2 * df(xStare) * df(xStare) - f(xStare) * ddf(xStare));
        }while (Math.Abs(xStare - xNowe) > eps);
        return xNowe;
    }
    
    public static double FindLinearRoot()
    {
        return HalleyRootFinding(x => 2 * x - 1, x => 2, x => 0);
    }

    public static double FindQuadraticRoot()
    {
        // TODO: FindQuadraticRoot f(x) = 2 * x * x + 3 * x + 1
        return HalleyRootFinding(x => 2 * (x * x) + 3 * x + 1);
    }

    public static double FindLogRoot()
    {
        // TODO: FindLogRoot f(x) = log(x)
        return HalleyRootFinding(x => double.Log(x), x => 1 / x, null, 2);
    }
}