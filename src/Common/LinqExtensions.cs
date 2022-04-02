namespace GakuGym.Common;

public static class LinqExtensions
{
    /// <summary>
    /// Joins the strings with an optional separator. Equivalent to String.Join(separator, strings)
    /// </summary>
    /// <param name="strings">The strings to concatenate together.</param>
    /// <param name="separator">An optional separator between each concatenation.</param>
    /// <returns>The concatenation of all the string values separated by the separator.</returns>
    public static string StringJoin(this IEnumerable<string> strings, string separator = null)
    {
        return String.Join(separator, strings);
    }

    /// <summary>
    /// Returns true if value is contained in values, false otherwise. Equivalent to values.Contains(value)
    /// </summary>
    /// <typeparam name="T">The type of values being compared.</typeparam>
    /// <param name="value">The value to test for.</param>
    /// <param name="values">The list of values to test against.</param>
    /// <returns>True if the value is contained in values.</returns>
    public static bool IsIn<T>(this T value,  IEnumerable<T> values)
    {
        return values.Contains(value);
    }

    public static IEnumerable<(T item, int index)> Indexed<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        IEnumerable<(T item, int index)> impl()
        {
            var i = 0;
            foreach (var item in source)
            {
                yield return (item, i);
                ++i;
            }
        }

        return impl();
    }
}

public struct RangeEnumerator
{
    public RangeEnumerator(int start, int end) => (Current, this.end) = (start - 1, end);

    public int Current { get; private set; }
    private int end;
    
    public bool MoveNext() => ++Current < end;
}

public static class RangeEx
{
    public static IEnumerable<int> Inclusive(this Range range)
    {
        foreach (var i in range.Start..(range.End.Value + 1))
            yield return i;
    }

    public static IEnumerable<int> Enumerate(this Range range)
    {
        foreach (var i in range)
            yield return i;
    }

    public static RangeEnumerator GetEnumerator(this Range range)
    {
        if (range.Start.IsFromEnd || range.End.IsFromEnd)
        {
            throw new ArgumentException(nameof(range));
        }

        return new RangeEnumerator(range.Start.Value, range.End.Value);
    }
}
