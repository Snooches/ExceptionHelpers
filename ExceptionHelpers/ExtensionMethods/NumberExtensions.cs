using System.Numerics;
using System.Runtime.CompilerServices;

namespace ExceptionHelpers.ExtensionMethods;

public static class NumberExtensions
{
    public static T ThrowIfZero<T>(
        this T input,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
        where T: struct, INumber<T>
    {
        if (input != default(T)) return input;
        
        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be zero.");

        throw new ArgumentOutOfRangeException(
            paramName: parameterName,
            message: message ?? $"'{parameterName}' must not be zero.");
    }
    
    public static T ThrowIfNegative<T>(
        this T input,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
    where T: struct, INumber<T>
    {
        if (input >= default(T)) return input;
        
        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be negative.");

        throw new ArgumentOutOfRangeException(
            paramName: parameterName,
            message: message ?? $"'{parameterName}' must not be negative.");
    }
    
    public static T ThrowIfNegativeOrZero<T>(
        this T input,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
        where T: struct, INumber<T>
    {
        if (input > default(T)) return input;
        
        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must be positive.");

        throw new ArgumentOutOfRangeException(
            paramName: parameterName,
            message: message ?? $"'{parameterName}' must be positive.");
    }
    
    public static T ThrowIfEqual<T>(
        this T input,
        T other,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
        where T: struct, INumber<T>
    {
        if (input != other) return input;
        
        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be equal to '{other}'.");

        throw new ArgumentOutOfRangeException(
            paramName: parameterName,
            message: message ?? $"'{parameterName}' must not be equal to '{other}'.");
    }

    public static T ThrowIfNotEqual<T>(
        this T input,
        T other,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
        where T: struct, INumber<T>
    {
        if (input == other) return input;
        
        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be equal to '{other}'.");

        throw new ArgumentOutOfRangeException(
            paramName: parameterName,
            message: message ?? $"'{parameterName}' must not be equal to '{other}'.");
    }

    public static T ThrowIfLessThan<T>(
        this T input,
        T other,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
        where T: struct, INumber<T>
    {
        if (input >= other) return input;
        
        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be less than '{other}'.");

        throw new ArgumentOutOfRangeException(
            paramName: parameterName,
            message: message ?? $"'{parameterName}' must not be less than '{other}'.");
    }
    
    public static T ThrowIfLessOrEqual<T>(
        this T input,
        T other,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
        where T: struct, INumber<T>
    {
        if (input > other) return input;
        
        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be less than or equal to '{other}'.");

        throw new ArgumentOutOfRangeException(
            paramName: parameterName,
            message: message ?? $"'{parameterName}' must not be less than or equal to '{other}'.");
    }

    public static T ThrowIfGreaterThan<T>(
        this T input,
        T other,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
        where T: struct, INumber<T>
    {
        if (input <= other) return input;
        
        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be greater than '{other}'.");

        throw new ArgumentOutOfRangeException(
            paramName: parameterName,
            message: message ?? $"'{parameterName}' must not be greater than '{other}'.");
    }

    public static T ThrowIfGreaterOrEqual<T>(
        this T input,
        T other,
        string? message = null,
        Func<string?, string, Exception>? exceptionProvider = null,
        [CallerArgumentExpression(nameof(input))]
        string? parameterName = null)
        where T: struct, INumber<T>
    {
        if (input < other) return input;
        
        if (exceptionProvider is not null)
            throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be greater than or equal to '{other}'.");

        throw new ArgumentOutOfRangeException(
            paramName: parameterName,
            message: message ?? $"'{parameterName}' must not be greater than or equal to '{other}'.");
    }
}