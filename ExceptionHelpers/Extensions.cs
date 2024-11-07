using System.Runtime.CompilerServices;

namespace ExceptionHelpers;

public static class Extensions
{
	public static T ThrowIfNull<T>(this T input, string? message = null, Func<string?, string, Exception>? exceptionProvider = null, [CallerArgumentExpression(nameof(input))] string? parameterName = null)
	{
		if (input is null)
		{
			if (exceptionProvider is not null)
			{
				throw exceptionProvider.Invoke(parameterName, message ?? $"'{parameterName}' must not be null.");
			}
			throw new ArgumentNullException(parameterName, message ?? $"'{parameterName}' must not be null.");
		}
		return input;
	}
}
