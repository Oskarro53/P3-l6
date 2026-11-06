using System;
using System.Collections.Generic;
using System.Numerics;

namespace Zad1;

/// <summary>
/// W tym etapie nie wolno używać funkcji Aggregate z LINQ.<br/>
/// Napisz metodę rozszerzającą Reduce&lt;TSource, TAccumulate&gt;
/// do interfejsu IEnumerable&lt;TSource&gt;, która będzie
/// wykonywać operację redukcji na sekwencji do pojedynczej wartości.<br/>
/// Metoda powinna przyjmować następujące parametry:<br/>
/// - TAccumulate seed: inicjalna wartość akumulatora,<br/>
/// - Func accumulator: funkcja, która realizuje logikę akumulacji,
///   przyjmującą dwie wartości typu TAccumulate i TSource,
///   zwracającą wartość typu TAccumulate.<br/>
/// Metoda powinna iterować przez elementy sekwencji source
/// i aktualizować wynikowy akumulator przy użyciu dostarczonej funkcji.<br/>
/// Przy użyciu metody Reduce zaimplementuj trzy metody
/// rozszerzające interfejs IEnumerable&lt;T&gt;,
/// przy ograniczeniu typu T do interfejsu INumber&lt;T&gt;:<br/>
/// - Sum - zwracającą sumę T sekwencji<br/>
/// - Min - zwracającą minimalny element T sekwencji<br/>
/// - Max - zwracającą maksymalny element T sekwencji<br/>
/// Wskazówki:<br/>
/// - T.CreateTruncating(double.NegativeInfinity)<br/>
/// - T.CreateTruncating(double.PositiveInfinity)<br/>
/// - T.Zero<br/>
/// - T.Min<br/>
/// - T.Max
/// </summary>
public static class EnumerableExtensions
{
    //TODO: Reduce<TSource, TAccumulator>

    public static TAccumulate Reduce<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed,
        Func<TAccumulate, TSource, TAccumulate> accumulator)
    {
        TAccumulate result = seed;
        foreach (var item in source)
        {
            result = accumulator(result, item);
        }
        return result;
    }

    public static T Sum<T>(this IEnumerable<T> source) where T : INumber<T>
    {
        return source.Reduce(T.Zero, (x, y) => x + y);
    }

    public static T Max<T>(this IEnumerable<T> source) where T : INumber<T>
    {
        return source.Reduce(T.Zero, (x, y) => x < y ? y : x);
    }

    public static T Min<T>(this IEnumerable<T> source) where T : INumber<T>
    {
        return source.Reduce(T.Zero, (x, y) => x > y ? y : x);
    }
}