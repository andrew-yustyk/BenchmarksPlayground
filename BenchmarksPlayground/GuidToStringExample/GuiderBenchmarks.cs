using BenchmarkDotNet.Attributes;

namespace BenchmarksPlayground.GuidToStringExample;

[StopOnFirstError]
[ReturnValueValidator(failOnError: true)]
[MemoryDiagnoser(displayGenColumns: false)]
public class GuiderBenchmarks
{
    public static readonly Guid TestIdAsGuid = Guid.Parse("f7edaebf-2bf6-44fb-9b8d-630168cd5378");
    public const string TestIdAsString = "v67t9_Yr-0SbjWMBaM1TeA";

    [Benchmark]
    public string GuidToB64IdManualNotOptimized()
    {
        return Guider.GuidToB64IdManualNotOptimized(TestIdAsGuid);
    }

    [Benchmark]
    public string GuidToB64IdManualOptimized()
    {
        return Guider.GuidToB64IdManualOptimized(TestIdAsGuid);
    }

    [Benchmark]
    public string GuidToB64IdStd()
    {
        return Guider.GuidToB64IdStd(TestIdAsGuid);
    }

    [Benchmark]
    public Guid B64IdToGuidManualNotOptimized()
    {
        return Guider.B64IdToGuidManualNotOptimized(TestIdAsString);
    }

    [Benchmark]
    public Guid B64IdToGuidManualOptimized()
    {
        return Guider.B64IdToGuidManualOptimized(TestIdAsString);
    }

    [Benchmark]
    public Guid B64IdToGuidStd()
    {
        return Guider.B64IdToGuidStd(TestIdAsString);
    }
}
