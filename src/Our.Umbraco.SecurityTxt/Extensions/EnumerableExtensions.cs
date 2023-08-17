using System.Diagnostics.CodeAnalysis;

namespace Our.Umbraco.SecurityTxt.Extensions;

public static class EnumerableExtensions
{
    public static bool TryGetListIfAny<T>(this IEnumerable<T>? source, [NotNullWhen(true)] out List<T>? result)
    {
        result = null;

        if (source == null)
        {
            return false;
        }

        var enumerable = source as T[] ?? source.ToArray();
        if (!enumerable.Any())
        {
            return false;
        }

        result = enumerable.ToList();
        return true;
    }
}
