using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace Zad2;

public static class Benchmarking
{
    private const int Size = 1_000;

    public static void StringAdd()
    {
        string _ = String.Empty;
        for (int i = 0; i < Size; i++)
        {
            _ += 'a';
        }
    }

    public static void StringBuilder()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Size; i++)
        {
            sb.Append('a');
        }

        string _ = sb.ToString();
    }

    public static void StringJoin()
    {
        string _ = string.Join(string.Empty, Enumerable.Repeat('a', Size));
    }

    // TODO: CreateBenchmark

    public static Action CreateBenchmark(Action action, string name, int times = 1000)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < times; i++)
        {
            action();
        }
        stopwatch.Stop();
        return () => Console.WriteLine($"Function {name}: {stopwatch.Elapsed.TotalMilliseconds /times} ms on average");
    }

    public static IEnumerable<Action> CreateBenchmarks()
    {
        // TODO: CreateBenchmarks
        var strAddTime = CreateBenchmark(StringAdd, "String+=");
        var strBuilderTime = CreateBenchmark(StringBuilder, "StringBuilder");
        var strJoinTime = CreateBenchmark(StringJoin, "StringJoin");
        List<Action> result = new List<Action>();
        result.Add(strAddTime);
        result.Add(strBuilderTime);
        result.Add(strJoinTime);
        return result;
    }
}