using BenchmarkDotNet.Attributes;

namespace IdiotBenchMark.DictionaryLookup.PerformanceTest;

[Config(typeof(BenchmarkConfig))]
[RankColumn]
public class DictionaryLookupPerformanceTest
{
    private readonly Dictionary<string, string> _myDictionary = new();
    private const string Key = "test_99";

    public DictionaryLookupPerformanceTest()
    {
        for(int i =0;i < 100; i++)
        {
            _myDictionary[i.ToString()] = $"test_{i}";
        }
    }
    
    [Benchmark(Baseline = true)]
    public string GetValueByKey()
    {
        if (_myDictionary.ContainsKey(Key))
        {
            return _myDictionary[Key];
        }
        
        return string.Empty;
    }
    
    [Benchmark]
    public string GetValueByKeyWithLinq()
    {
        return _myDictionary.FirstOrDefault(a => a.Key == Key).Value;
    }
    
    [Benchmark]
    public string? GetValueByKeyWithTryGet()
    {
        _myDictionary.TryGetValue(Key, out string? value);
        return value;
    }
    
    [Benchmark]
    public string GetValueByKeyManual()
    {
        foreach (var item in _myDictionary)
        {
            if(item.Key == "test_99")
            {
                return item.Value;
            }
        }
        
        return string.Empty;
    }
}