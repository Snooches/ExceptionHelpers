using ExceptionHelpers.ExtensionMethods;

namespace ExceptionHelpersTests.ExtensionMethods;

public class EnumExtensionTests
{
    #region ThrowIfNotDefined

    [Test]
    public void ThrowIfNotDefined_MethodWasCalledOnDefinedValue_ValueWasReturned()
    {
        TestEnum value = TestEnum.Valid;

        TestEnum result = value.ThrowIfNotDefined();
        
        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void ThrowIfNotDefined_MethodWasCalledWithCustomMessage_ArgumentExceptionWasThrownWithProvidedMessage()
    {
        TestEnum value = (TestEnum)255;
        
        const string message = "This is my custom message.";
        
        Assert.That(()=> value.ThrowIfNotDefined(message: message),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.StartsWith(message + " (Parameter 'value')"));
    }
    
    [Test]
    public void ThrowIfNotDefined_MethodWasCalledWithExceptionProvider_CustomExceptionWasThrown()
    {
        TestEnum value = (TestEnum)255;
        
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => value.ThrowIfNotDefined(exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }
    
    #endregion

    private enum TestEnum: byte
    {
        Default = 0,
        Valid = 1
    }
}