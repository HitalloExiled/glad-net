namespace Glad.Net.Extensions;

public static class StringExtensions
{
    public static string ToSafeIdentifier(this string value) =>
        !string.IsNullOrEmpty(value) && char.IsAsciiDigit(value[0])
            ? "_" + value
            : value;
}
