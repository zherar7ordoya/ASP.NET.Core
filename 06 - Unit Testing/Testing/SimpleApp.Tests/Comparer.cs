namespace SimpleApp.Tests;

public class Comparer
{
    public static Comparer<U?> Get<U>(Func<U?, U?, bool> func)
    {
        return new Comparer<U?>(func);
    }
}

public class Comparer<T> : IEqualityComparer<T>
{
    private readonly Func<T?, T?, bool> _comparisonFunction;

    public Comparer(Func<T?, T?, bool> func)
    {
        _comparisonFunction = func;
    }

    public bool Equals(T? x, T? y)
    {
        return _comparisonFunction(x, y);
    }

    public int GetHashCode(T obj)
    {
        return obj?.GetHashCode() ?? 0;
    }

    public static IEqualityComparer<T> Create(Func<T?, T?, bool> func)
    {
        return new Comparer<T>(func);
    }
}
