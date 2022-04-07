using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;

namespace IdiotBenchMark.StringConcat.PerformanceTest;

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        AddJob(Job.Default);
        AddColumn(TargetMethodColumn.Method, StatisticColumn.Mean, StatisticColumn.StdDev, 
            StatisticColumn.OperationsPerSecond, StatisticColumn.Min, StatisticColumn.Max, BaselineRatioColumn.RatioMean);
        AddLogger(ConsoleLogger.Default);
        AddExporter(RPlotExporter.Default, CsvExporter.Default, HtmlExporter.Default);
        AddAnalyser(EnvironmentAnalyser.Default);
        AddDiagnoser(MemoryDiagnoser.Default);
        UnionRule = ConfigUnionRule.AlwaysUseLocal;
    }
}