using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using Microsoft.Diagnostics.Tracing.Analysis;

namespace IdiotBenchMark.Mapper.PerformanceTest;

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        AddColumn(TargetMethodColumn.Method, StatisticColumn.Mean, StatisticColumn.Error, StatisticColumn.StdDev, 
            BaselineRatioColumn.RatioMean, RankColumn.Stars, StatisticColumn.OperationsPerSecond, StatisticColumn.Min, 
            StatisticColumn.Max, BaselineRatioColumn.RatioMean);
        AddLogger(ConsoleLogger.Default);
        AddExporter(RPlotExporter.Default, CsvExporter.Default, HtmlExporter.Default);
        AddAnalyser(EnvironmentAnalyser.Default);
        AddDiagnoser(MemoryDiagnoser.Default);
        UnionRule = ConfigUnionRule.AlwaysUseLocal;
    }
}