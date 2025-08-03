using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;

namespace BenchmarksPlayground.BytesToHexString;

[StopOnFirstError]
[ReturnValueValidator(failOnError: true)]
[MemoryDiagnoser(displayGenColumns: false)]
public class BytesToHexStringBenchmarks
{
    [Params(256)]
    [SuppressMessage("ReSharper", "UnassignedField.Global")]
    public int Size;

    private byte[] _bytes = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _bytes = new byte[Size];
        Random.Shared.NextBytes(_bytes);
    }

    [Benchmark(Baseline = true)]
    public string AggregateStringBuilderAppend()
    {
        return BytesToHexStringService.AggregateStringBuilderAppend(_bytes);
    }

    [Benchmark]
    public string ConvertToHexStringToLower()
    {
        return BytesToHexStringService.ConvertToHexStringToLower(_bytes);
    }

    [Benchmark]
    public string ConvertToHexStringToLowerInvariant()
    {
        return BytesToHexStringService.ConvertToHexStringToLowerInvariant(_bytes);
    }
}
