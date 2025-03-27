using ExceptionHelpers.ExtensionMethods;

namespace ExceptionHelpersTests.ExtensionMethods;

public class NumberExtensionsTests
{
    #region ThrowIfZero

    [TestCase(-1)]
    [TestCase(7)]
    public void ThrowIfZero_MethodWasCalledOnValidObject_ObjectWasReturned(int number)
    {
        int result = number.ThrowIfZero();

        Assert.That(result, Is.EqualTo(number));
    }

    [TestCase(0)]
    public void ThrowIfZero_MethodWasCalledOnInvalidNumber_GenericArgumentOutOfRangeExceptionWasThrown(int number)
    {
        Assert.That(() => number.ThrowIfZero(),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo("'number' must not be zero. (Parameter 'number')"));
    }

    [TestCase(0)]
    public void ThrowIfZero_MethodWasCalledOnWithCustomMessage_ArgumentOutOfRangeExceptionWasThrownWithProvidedMessage(
        int number)
    {
        const string message = "this is my custom exception message";

        Assert.That(() => number.ThrowIfZero(message),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo(message + " (Parameter 'number')"));
    }

    [TestCase(0)]
    public void ThrowIfZero_MethodWasCalledOnWithExceptionProvider_CustomExceptionWasThrown(int number)
    {
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => number.ThrowIfZero(exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }

    #endregion

    #region ThrowIfNegative

    [TestCase(0)]
    [TestCase(7)]
    public void ThrowIfNegative_MethodWasCalledOnValidObject_ObjectWasReturned(int number)
    {
        int result = number.ThrowIfNegative();

        Assert.That(result, Is.EqualTo(number));
    }

    [TestCase(-42)]
    [TestCase(-1)]
    public void ThrowIfNegative_MethodWasCalledOnInvalidNumber_GenericArgumentOutOfRangeExceptionWasThrown(int number)
    {
        Assert.That(() => number.ThrowIfNegative(),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo("'number' must not be negative. (Parameter 'number')"));
    }

    [TestCase(-42)]
    [TestCase(-1)]
    public void
        ThrowIfNegative_MethodWasCalledOnWithCustomMessage_ArgumentOutOfRangeExceptionWasThrownWithProvidedMessage(
            int number)
    {
        const string message = "this is my custom exception message";

        Assert.That(() => number.ThrowIfNegative(message),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo(message + " (Parameter 'number')"));
    }

    [TestCase(-42)]
    [TestCase(-1)]
    public void ThrowIfNegative_MethodWasCalledOnWithExceptionProvider_CustomExceptionWasThrown(int number)
    {
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => number.ThrowIfNegative(exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }

    #endregion

    #region ThrowIfNegativeOrZero

    [TestCase(1)]
    [TestCase(7)]
    public void ThrowIfNegativeOrZero_MethodWasCalledOnValidObject_ObjectWasReturned(int number)
    {
        int result = number.ThrowIfNegativeOrZero();

        Assert.That(result, Is.EqualTo(number));
    }

    [TestCase(-42)]
    [TestCase(0)]
    public void ThrowIfNegativeOrZero_MethodWasCalledOnInvalidNumber_GenericArgumentOutOfRangeExceptionWasThrown(
        int number)
    {
        Assert.That(() => number.ThrowIfNegativeOrZero(),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo("'number' must be positive. (Parameter 'number')"));
    }

    [TestCase(-42)]
    [TestCase(0)]
    public void
        ThrowIfNegativeOrZero_MethodWasCalledOnWithCustomMessage_ArgumentOutOfRangeExceptionWasThrownWithProvidedMessage(
            int number)
    {
        const string message = "this is my custom exception message";

        Assert.That(() => number.ThrowIfNegativeOrZero(message),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo(message + " (Parameter 'number')"));
    }

    [TestCase(-42)]
    [TestCase(0)]
    public void ThrowIfNegativeOrZero_MethodWasCalledOnWithExceptionProvider_CustomExceptionWasThrown(int number)
    {
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => number.ThrowIfNegativeOrZero(exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }

    #endregion

    #region ThrowIfEqual

    [TestCase(-2)]
    [TestCase(0)]
    [TestCase(7)]
    public void ThrowIfEqual_MethodWasCalledOnValidObject_ObjectWasReturned(int number)
    {
        int result = number.ThrowIfEqual(42);

        Assert.That(result, Is.EqualTo(number));
    }

    [TestCase(3)]
    public void ThrowIfEqual_MethodWasCalledOnInvalidNumber_GenericArgumentOutOfRangeExceptionWasThrown(int number)
    {
        Assert.That(() => number.ThrowIfEqual(3),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo("'number' must not be equal to '3'. (Parameter 'number')"));
    }

    [TestCase(3)]
    public void ThrowIfEqual_MethodWasCalledOnWithCustomMessage_ArgumentOutOfRangeExceptionWasThrownWithProvidedMessage(
        int number)
    {
        const string message = "this is my custom exception message";

        Assert.That(() => number.ThrowIfEqual(3, message),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo(message + " (Parameter 'number')"));
    }

    [TestCase(3)]
    public void ThrowIfEqual_MethodWasCalledOnWithExceptionProvider_CustomExceptionWasThrown(int number)
    {
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => number.ThrowIfEqual(3, exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }

    #endregion

    #region ThrowIfNotEqual

    [TestCase(7)]
    public void ThrowIfNotEqual_MethodWasCalledOnValidObject_ObjectWasReturned(int number)
    {
        int result = number.ThrowIfNotEqual(7);

        Assert.That(result, Is.EqualTo(number));
    }

    [TestCase(-42)]
    [TestCase(0)]
    [TestCase(8)]
    public void ThrowIfNotEqual_MethodWasCalledOnInvalidNumber_GenericArgumentOutOfRangeExceptionWasThrown(int number)
    {
        Assert.That(() => number.ThrowIfNotEqual(7),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo("'number' must not be equal to '7'. (Parameter 'number')"));
    }

    [TestCase(-42)]
    [TestCase(0)]
    [TestCase(8)]
    public void
        ThrowIfNotEqual_MethodWasCalledOnWithCustomMessage_ArgumentOutOfRangeExceptionWasThrownWithProvidedMessage(
            int number)
    {
        const string message = "this is my custom exception message";

        Assert.That(() => number.ThrowIfNotEqual(7, message),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo(message + " (Parameter 'number')"));
    }

    [TestCase(-42)]
    [TestCase(0)]
    [TestCase(8)]
    public void ThrowIfNotEqual_MethodWasCalledOnWithExceptionProvider_CustomExceptionWasThrown(int number)
    {
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => number.ThrowIfNotEqual(7, exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }

    #endregion
    
    #region ThrowIfLessThan

    [TestCase(2)]
    [TestCase(7)]
    public void ThrowIfLessThan_MethodWasCalledOnValidObject_ObjectWasReturned(int number)
    {
        int result = number.ThrowIfLessThan(2);

        Assert.That(result, Is.EqualTo(number));
    }

    [TestCase(-42)]
    [TestCase(-1)]
    [TestCase(1)]
    public void ThrowIfLessThan_MethodWasCalledOnInvalidNumber_GenericArgumentOutOfRangeExceptionWasThrown(int number)
    {
        Assert.That(() => number.ThrowIfLessThan(2),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo("'number' must not be less than '2'. (Parameter 'number')"));
    }

    [TestCase(-42)]
    [TestCase(-1)]
    [TestCase(1)]
    public void
        ThrowIfLessThan_MethodWasCalledOnWithCustomMessage_ArgumentOutOfRangeExceptionWasThrownWithProvidedMessage(
            int number)
    {
        const string message = "this is my custom exception message";

        Assert.That(() => number.ThrowIfLessThan(2, message),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo(message + " (Parameter 'number')"));
    }

    [TestCase(-42)]
    [TestCase(-1)]
    [TestCase(1)]
    public void ThrowIfLessThan_MethodWasCalledOnWithExceptionProvider_CustomExceptionWasThrown(int number)
    {
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => number.ThrowIfLessThan(2, exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }

    #endregion

    #region ThrowIfLessOrEqual

    [TestCase(3)]
    [TestCase(7)]
    public void ThrowIfLessOrEqual_MethodWasCalledOnValidObject_ObjectWasReturned(int number)
    {
        int result = number.ThrowIfLessOrEqual(2);

        Assert.That(result, Is.EqualTo(number));
    }

    [TestCase(-42)]
    [TestCase(-1)]
    [TestCase(2)]
    public void ThrowIfLessOrEqual_MethodWasCalledOnInvalidNumber_GenericArgumentOutOfRangeExceptionWasThrown(
        int number)
    {
        Assert.That(() => number.ThrowIfLessOrEqual(2),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo("'number' must not be less than or equal to '2'. (Parameter 'number')"));
    }

    [TestCase(-42)]
    [TestCase(-1)]
    [TestCase(2)]
    public void
        ThrowIfLessOrEqual_MethodWasCalledOnWithCustomMessage_ArgumentOutOfRangeExceptionWasThrownWithProvidedMessage(
            int number)
    {
        const string message = "this is my custom exception message";

        Assert.That(() => number.ThrowIfLessOrEqual(2, message),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo(message + " (Parameter 'number')"));
    }

    [TestCase(-42)]
    [TestCase(-1)]
    [TestCase(2)]
    public void ThrowIfLessOrEqual_MethodWasCalledOnWithExceptionProvider_CustomExceptionWasThrown(int number)
    {
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => number.ThrowIfLessOrEqual(2, exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }

    #endregion

    #region ThrowIfGreaterThan

    [TestCase(-3)]
    [TestCase(-42)]
    public void ThrowIfGreaterThan_MethodWasCalledOnValidObject_ObjectWasReturned(int number)
    {
        int result = number.ThrowIfGreaterThan(-2);

        Assert.That(result, Is.EqualTo(number));
    }

    [TestCase(42)]
    [TestCase(-1)]
    public void ThrowIfGreaterThan_MethodWasCalledOnInvalidNumber_GenericArgumentOutOfRangeExceptionWasThrown(
        int number)
    {
        Assert.That(() => number.ThrowIfGreaterThan(-2),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo("'number' must not be greater than '-2'. (Parameter 'number')"));
    }

    [TestCase(42)]
    [TestCase(-1)]
    public void
        ThrowIfGreaterThan_MethodWasCalledOnWithCustomMessage_ArgumentOutOfRangeExceptionWasThrownWithProvidedMessage(
            int number)
    {
        const string message = "this is my custom exception message";

        Assert.That(() => number.ThrowIfGreaterThan(-2, message),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo(message + " (Parameter 'number')"));
    }

    [TestCase(42)]
    [TestCase(-1)]
    public void ThrowIfGreaterThan_MethodWasCalledOnWithExceptionProvider_CustomExceptionWasThrown(int number)
    {
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => number.ThrowIfGreaterThan(-2, exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }

    #endregion

    #region ThrowIfGreaterOrEqual

    [TestCase(-3)]
    [TestCase(-42)]
    public void ThrowIfGreaterOrEqual_MethodWasCalledOnValidObject_ObjectWasReturned(int number)
    {
        int result = number.ThrowIfGreaterOrEqual(-2);

        Assert.That(result, Is.EqualTo(number));
    }

    [TestCase(42)]
    [TestCase(-2)]
    public void ThrowIfGreaterOrEqual_MethodWasCalledOnInvalidNumber_GenericArgumentOutOfRangeExceptionWasThrown(int number)
    {
        Assert.That(() => number.ThrowIfGreaterOrEqual(-2),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo("'number' must not be greater than or equal to '-2'. (Parameter 'number')"));
    }

    [TestCase(42)]
    [TestCase(-2)]
    public void ThrowIfGreaterOrEqual_MethodWasCalledOnWithCustomMessage_ArgumentOutOfRangeExceptionWasThrownWithProvidedMessage(int number)
    {
        const string message = "this is my custom exception message";

        Assert.That(() => number.ThrowIfGreaterOrEqual(-2, message),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo(message + " (Parameter 'number')"));
    }

    [TestCase(42)]
    [TestCase(-2)]
    public void ThrowIfGreaterOrEqual_MethodWasCalledOnWithExceptionProvider_CustomExceptionWasThrown(int number)
    {
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => number.ThrowIfGreaterOrEqual(-2, exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }

    #endregion
}