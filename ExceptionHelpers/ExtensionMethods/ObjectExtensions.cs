using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ExceptionHelpers.ExtensionMethods;

public static class ObjectExtensions
{
	public static T ThrowIfNull<T>(
		[NotNull]this T input, 
		string? message = null, 
		Func<string?, string, Exception>? exceptionProvider = null, 
		[CallerArgumentExpression(nameof(input))] string? parameterName = null)
	{
		if (input is not null) return input;
		
		if (exceptionProvider is not null)
			throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be null.");

		throw new ArgumentNullException(parameterName, message ?? $"'{parameterName}' must not be null.");
	}
}
