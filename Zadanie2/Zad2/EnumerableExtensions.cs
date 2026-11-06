using System.Text;

namespace Zad2;

public static class EnumerableExtensions
{
    // TODO: Collect

    public static TAccumulate Collect<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate collection,
        Func<TAccumulate, TSource, TAccumulate> func)
    {
        TAccumulate result  = collection;
        foreach (var item in source)
        {
            result = func(result, item);
        }
        return result;
    }
    
    // TODO: Filter

    public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
                yield return item;
        }
    }

    public static string ConcatStrings<T>(this IEnumerable<T> source)
    {
        IEnumerable<T> filtered = source.Filter(item => item is string);
        return filtered.Collect(new StringBuilder(), (accumulator,  item) => accumulator.Append(item)).ToString();
    }
}