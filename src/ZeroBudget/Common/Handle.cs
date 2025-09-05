using System.Globalization;

namespace ZeroBudget.Common;

public record Handle(params string[] Components);

public delegate Slug HandleToSlug(Handle handle);
public delegate Handle TransformHandle(Handle handle);

public static class HandleTransforms
{
    public static TransformHandle ToLowercase(CultureInfo cultureInfo) =>
        handle => new Handle(Array.ConvertAll(handle.Components, c => c.ToLower(cultureInfo)));

    public static TransformHandle ToLowercaseInvariant =>
        handle => new Handle(Array.ConvertAll(handle.Components, c => c.ToLowerInvariant()));

    public static TransformHandle SplitOnWhiteSpace =>
        handle => new Handle([.. handle.Components.SelectMany(c => c.Split([' ', '\t', '\n'], StringSplitOptions.RemoveEmptyEntries))]);

    public static TransformHandle IntoLetterAndDigitRuns =>
        handle => new(handle.Components.SelectMany(SplitLetterAndDigitRuns).ToArray());

    private static IEnumerable<string> SplitLetterAndDigitRuns(string s)
    {
        int start = 0;
        while (start < s.Length && !char.IsLetterOrDigit(s[start]))
        {
            start++;
        }

        while (start < s.Length)
        {
            int end = start + 1;
            while (end < s.Length && char.IsLetterOrDigit(s[end]))
            {
                end++;
            }

            yield return s[start..end];
            start = end;
        }
    }
}

public static class HandleTransformCompositions
{
    public static TransformHandle Then(this TransformHandle first, TransformHandle second) =>
        handle => second(first(handle));

    public static Handle Transform(this Handle handle, params TransformHandle[] transforms) =>
        transforms.Aggregate(handle, (current, transform) => transform(current));

    public static Slug ToSlug(this Handle handle, HandleToSlug conversion) =>
        conversion(handle);
}

public static class HandleToSlugConversions
{
    public static HandleToSlug Concatenate =>
        handle => new(string.Join(string.Empty, handle.Components));
        
    public static HandleToSlug Hyphenate =>
        handle => new(string.Join("-", handle.Components));
}