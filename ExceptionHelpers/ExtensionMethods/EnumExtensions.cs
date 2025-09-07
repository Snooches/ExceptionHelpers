using System.Runtime.CompilerServices;

namespace ExceptionHelpers.ExtensionMethods;

public static class EnumExtensions
{
    public static T ThrowIfNotDefined<T>(
        this T value,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null)
        where T : struct, Enum
    {
        if (Enum.IsDefined(typeof(T), value))
            return value;

        message ??= $"'{parameterName}' must be a defined value of enum type '{typeof(T).Name}'.";

        if (exceptionProvider is not null)
            throw exceptionProvider(parameterName, message);

        throw new ArgumentOutOfRangeException(parameterName, value, message);
    }
}