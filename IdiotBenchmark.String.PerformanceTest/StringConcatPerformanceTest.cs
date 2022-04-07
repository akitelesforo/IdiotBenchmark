using BenchmarkDotNet.Attributes;
using System.Text;

namespace IdiotBenchMark.StringConcat.PerformanceTest;

[Config(typeof(BenchmarkConfig))]
[RankColumn]
public class StringConcatPerformanceTest
{
    int _length = 1000;

    [Benchmark]
    public void Concat()
    {
        var concatString = string.Empty;
        for (int i = 0; i < _length; i++)
        {
            concatString += "a";
        }
    }

    [Benchmark]
    public void Interpolation()
    {
        var concatString = string.Empty;
        for (int i = 0; i < _length; i++)
        {
            concatString = $"{concatString}a";
        }
    }

    [Benchmark]
    public void StringBuilder()
    {
        StringBuilder stringBuilder = new();
        for (int i = 0; i < _length; i++)
        {
            stringBuilder.Append("a");
        }
    }
}