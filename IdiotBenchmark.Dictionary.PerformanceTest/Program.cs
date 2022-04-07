// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using IdiotBenchMark.DictionaryLookup.PerformanceTest;

//BenchmarkRunner.Run<Baseline>();
BenchmarkRunner.Run<DictionaryLookupPerformanceTest>();