using System.Collections;
using System.Runtime.CompilerServices;

namespace ExceptionHelpers.ExtensionMethods;

public static class EnumerableExtensions
{
    public static T ThrowIfNullOrEmpty<T>(
        this T? input,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))] string? parameterName = null)
    where T : IEnumerable
    {
        input.ThrowIfNull(message, exceptionProvider, parameterName);

        //Could be optimised for specific collection types
        foreach (var unused in input)
            return input;
        
        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be empty.");

        throw new ArgumentException(paramName: parameterName, message: message ?? $"'{parameterName}' must not be empty.");
    }
}