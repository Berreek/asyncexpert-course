using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;

namespace Dotnetos.AsyncExpert.Homework.Module01.Benchmark
{
    [DisassemblyDiagnoser(exportCombinedDisassemblyReport: true)]
    [NativeMemoryProfiler]
    [MemoryDiagnoser]
    public class FibonacciBenchmark
    {
        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public ulong Recursive(ulong n) => FibbonacciCalc.Recursive(n);

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong RecursiveWithMemoization(ulong n) => new FibbonacciCalcWithMemoization(n).RecursiveWithMemoization();

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong Iterative(ulong n) => FibbonacciCalc.Iterative(n);

        public IEnumerable<ulong> Data()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
            yield return 13;
            yield return 19;
            yield return 23;
            yield return 29;
        }
    }
}
