using ExceptionHelpers.ExtensionMethods;

namespace ExceptionHelpersTests.ExtensionMethods;

public class ObjectExtensionsTests
{
	#region ThrowIfNull

	[Test] 
	public void ThrowIfNull_MethodWasCalledOnNonNullObject_ObjectWasReturned()
	{
		object obj = new();

		object result = obj.ThrowIfNull();

		Assert.That(result, Is.SameAs(obj));
	}

	[Test]
	public void ThrowIfNull_MethodWasCalledOnNullWithNoParameters_GenericArgumentNullExceptionWasThrown()
	{
		object? obj = null;

		Assert.That(() => obj.ThrowIfNull(), Throws.ArgumentNullException
			.With.Message.EqualTo("'obj' must not be null. (Parameter 'obj')"));
	}

	[Test]
	public void ThrowIfNull_MethodWasCalledWithCustomMessage_ArgumentNullExceptionWasThrownWithProvidedMessage()
	{
		object? obj = null;
		const string message = "This is my custom exception message.";

		Assert.That(() => obj.ThrowIfNull(message: message), Throws.ArgumentNullException
			.With.Message.EqualTo(message + " (Parameter 'obj')"));
	}

	[Test]
	public void ThrowIfNull_MethodWasCalledWithExceptionProvider_CustomExceptionWasThrown()
	{
		object? obj = null;
		Exception ExceptionProvider(string? parameterName, string message) => new ArgumentException("static message.", parameterName);

		Assert.That(()=> obj.ThrowIfNull(exceptionProvider: ExceptionProvider), Throws.ArgumentException
			.With.Message.EqualTo("static message. (Parameter 'obj')"));
	}

	#endregion
}