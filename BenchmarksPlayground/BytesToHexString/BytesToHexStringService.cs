using System.Text;

namespace BenchmarksPlayground.BytesToHexString;

public static class BytesToHexStringService
{
    public static string AggregateStringBuilderAppend(byte[] bytesToConvert)
    {
        return bytesToConvert
            .Aggregate(new StringBuilder(bytesToConvert.Length * 2), (sb, b) => sb.Append($"{b:x2}"))
            .ToString();
    }

    public static string ConvertToHexStringToLower(byte[] bytesToConvert)
    {
        return Convert.ToHexString(bytesToConvert).ToLower();
    }

    public static string ConvertToHexStringToLowerInvariant(byte[] bytesToConvert)
    {
        return Convert.ToHexString(bytesToConvert).ToLowerInvariant();
    }
}
