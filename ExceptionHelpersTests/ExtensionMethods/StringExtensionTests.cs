using ExceptionHelpers.ExtensionMethods;

namespace ExceptionHelpersTests.ExtensionMethods;

public class StringExtensionTests
{
    #region ThrowIfNullOrEmpty
    
    [Test]
    public void ThrowIfNullOrEmpty_MethodWasCalledOnNonEmptyObject_ObjectWasReturned()
    {
        const string str = "string";

        string result = str.ThrowIfNullOrEmpty();

        Assert.That(result, Is.SameAs(str));
    }

    [TestCaseSource(nameof(NullOrEmptyStringTestData))]
    public void ThrowIfNullOrEmpty_MethodWasCalledOnInvalidStringWithNoParameters_GenericArgumentExceptionWasThrown(TestCaseData<string> testCase)
    {
        string? str = testCase.Object;
        
        Assert.That(() => str.ThrowIfNullOrEmpty(),
            Throws.InstanceOf(testCase.ExpectedExceptionType)
                .With.Message.EqualTo(testCase.ExpectedExceptionMessage));
    }

    [TestCaseSource(nameof(NullOrEmptyStringTestData))]
    public void ThrowIfNullOrEmpty_MethodWasCalledWithCustomMessage_ArgumentExceptionWasThrownWithProvidedMessage(TestCaseData<string> testCase)
    {
        string? str = testCase.Object;
        
        const string message = "This is my custom exception message.";

        Assert.That(() => str.ThrowIfNullOrEmpty(message: message),
            Throws.InstanceOf(testCase.ExpectedExceptionType)
                .With.Message.EqualTo(message + " (Parameter 'str')"));
    }

    [TestCaseSource(nameof(NullOrEmptyStringTestData))]
    public void ThrowIfNullOrEmpty_MethodWasCalledWithExceptionProvider_CustomExceptionWasThrown(TestCaseData<string> testCase)
    {
        string? str = testCase.Object;
        
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => str.ThrowIfNullOrEmpty(exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo("static message."));
    }

    private static IEnumerable<TestCaseData<string>> NullOrEmptyStringTestData()
    {
        yield return new(null, typeof(ArgumentNullException), "'str' must not be null. (Parameter 'str')");
        yield return new("", typeof(ArgumentException), "'str' must not be empty. (Parameter 'str')");
    }
    
    #endregion
    
    #region ThrowIfNullOrWhiteSpace
    [Test]
    public void ThrowIfNullOrWhiteSpace_MethodWasCalledOnValidObject_ObjectWasReturned()
    {
        const string str = "string";

        string result = str.ThrowIfNullOrEmpty();

        Assert.That(result, Is.SameAs(str));
    }

    [TestCaseSource(nameof(NullOrWhiteSpaceStringTestData))]
    public void ThrowIfNullOrWhiteSpace_MethodWasCalledOnWhiteSpaceStringWithNoParameters_GenericArgumentExceptionWasThrown(TestCaseData<string> testCase)
    {
        string? str = testCase.Object;
        
        Assert.That(() => str.ThrowIfNullOrWhiteSpace(),
            Throws.InstanceOf(testCase.ExpectedExceptionType)
                .With.Message.EqualTo(testCase.ExpectedExceptionMessage));
    }

    [TestCaseSource(nameof(NullOrWhiteSpaceStringTestData))]
    public void ThrowIfNullOrWhiteSpace_MethodWasCalledWithCustomMessage_ArgumentExceptionWasThrownWithProvidedMessage(TestCaseData<string> testCase)
    {
        string? str = testCase.Object;

        const string message = "This is my custom exception message.";

        Assert.That(() => str.ThrowIfNullOrWhiteSpace(message: message),
            Throws.InstanceOf(testCase.ExpectedExceptionType)
                .With.Message.EqualTo(message + " (Parameter 'str')"));
    }

    [TestCaseSource(nameof(NullOrWhiteSpaceStringTestData))]
    public void ThrowIfNullOrWhiteSpace_MethodWasCalledWithExceptionProvider_CustomExceptionWasThrown(TestCaseData<string> testCase)
    {
        string? str = testCase.Object;

        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => str.ThrowIfNullOrWhiteSpace(exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }
    
    private static IEnumerable<TestCaseData<string>> NullOrWhiteSpaceStringTestData()
    {
        yield return new(null, typeof(ArgumentNullException), "'str' must not be null. (Parameter 'str')");
        yield return new("", typeof(ArgumentException), "'str' must not be empty or whitespace. (Parameter 'str')");
        yield return new(" ", typeof(ArgumentException), "'str' must not be empty or whitespace. (Parameter 'str')");
        yield return new("\t", typeof(ArgumentException), "'str' must not be empty or whitespace. (Parameter 'str')");
    }
    #endregion
    
    #region ThrowIfInvalidLength
    
    [Test]
    public void ThrowIfInvalidLength_MethodWasCalledOnValidObject_ObjectWasReturned()
    {
        const string str = "string";

        string result = str.ThrowIfInvalidLength();

        Assert.That(result, Is.SameAs(str));
    }

    [TestCaseSource(nameof(InvalidLengthStringTestData))]
    public void ThrowIfInvalidLength_MethodWasCalledOnInvalidString_GenericArgumentExceptionWasThrown(TestCaseData<(string? Str ,int MinLength, int MaxLength)> testCase)
    {
        string? str = testCase.Object.Str;

        Assert.That(() => str.ThrowIfInvalidLength(minLength: testCase.Object.MinLength, maxLength: testCase.Object.MaxLength),
            Throws.InstanceOf(testCase.ExpectedExceptionType)
                .With.Message.EqualTo(testCase.ExpectedExceptionMessage));
    }

    [TestCaseSource(nameof(InvalidLengthStringTestData))]
    public void ThrowIfInvalidLength_MethodWasCalledWithCustomMessage_ArgumentExceptionWasThrownWithProvidedMessage(TestCaseData<(string? Str ,int MinLength, int MaxLength)> testCase)
    {
        string? str = testCase.Object.Str;

        const string message = "This is my custom exception message.";

        Assert.That(() => str.ThrowIfInvalidLength(minLength: testCase.Object.MinLength, maxLength: testCase.Object.MaxLength, message: message),
            Throws.InstanceOf(testCase.ExpectedExceptionType)
                .With.Message.EqualTo(message + " (Parameter 'str')"));
    }

    [TestCaseSource(nameof(InvalidLengthStringTestData))]
    public void ThrowIfInvalidLength_MethodWasCalledWithExceptionProvider_CustomExceptionWasThrown(TestCaseData<(string? Str ,int MinLength, int MaxLength)> testCase)
    {
        string? str = testCase.Object.Str;
        
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => str.ThrowIfInvalidLength(minLength: testCase.Object.MinLength, maxLength: testCase.Object.MaxLength, exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }
    
    private static IEnumerable<TestCaseData<(string?,int,int)>> InvalidLengthStringTestData()
    {
        yield return new((null,0,1), typeof(ArgumentNullException), "'str' must not be null. (Parameter 'str')");
        yield return new(("",1,2), typeof(ArgumentException), "'str' must not be shorter than 1 characters. (Parameter 'str')");
        yield return new(("abc",1,2), typeof(ArgumentException), "'str' must not be longer than 2 characters. (Parameter 'str')");
        yield return new(("ab",3,1), typeof(ArgumentException), "'str' must not be longer than 1 characters. (Parameter 'str')");
    }
    
    
    #endregion
}