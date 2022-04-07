// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using IdiotBenchMark.StringConcat.PerformanceTest;

//BenchmarkRunner.Run<Baseline>();
BenchmarkRunner.Run<StringConcatPerformanceTest>();