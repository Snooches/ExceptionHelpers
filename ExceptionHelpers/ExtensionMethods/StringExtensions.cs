using System.Runtime.CompilerServices;

namespace ExceptionHelpers.ExtensionMethods;

public static class StringExtensions
{
    public static string ThrowIfNullOrEmpty(
        this string? input,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
    {
        input = input.ThrowIfNull(message, exceptionProvider, parameterName);

        if (!string.IsNullOrEmpty(input)) return input;

        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be null or empty.");

        throw new ArgumentException(
            paramName: parameterName,
            message: message ?? $"'{parameterName}' must not be empty.");
    }

    public static string ThrowIfNullOrWhiteSpace(
        this string? input,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
    {
        input = input.ThrowIfNull(message, exceptionProvider, parameterName);
        
        if (!string.IsNullOrWhiteSpace(input)) return input;

        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName,
                message ?? $"'{parameterName}' must not be empty or whitespace.");

        throw new ArgumentException(
            paramName: parameterName,
            message: message ?? $"'{parameterName}' must not be empty or whitespace.");
    }

    public static string ThrowIfInvalidLength(
        this string input,
        int maxLength = int.MaxValue,
        int minLength = 0,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
    {
        input = input.ThrowIfNull(message, exceptionProvider, parameterName);
        
        if (input.Length > maxLength)
        {
            if (exceptionProvider is not null)
                throw exceptionProvider.Invoke(parameterName,
                    message ?? $"'{parameterName}' must not be longer than {maxLength} characters.");

            throw new ArgumentException(
                paramName: parameterName,
                message: message ?? $"'{parameterName}' must not be longer than {maxLength} characters.");
        }
        
        if (input.Length < minLength)
        {
            if (exceptionProvider is not null)
                throw exceptionProvider.Invoke(parameterName,
                    message ?? $"'{parameterName}' must not be shorter than {minLength} characters.");

            throw new ArgumentException(
                paramName: parameterName,
                message: message ?? $"'{parameterName}' must not be shorter than {minLength} characters.");
        }
        
        return input;
    }
}