using ExceptionHelpers.ExtensionMethods;

namespace ExceptionHelpersTests.ExtensionMethods;

public class EnumerableExtensionsTests
{
    #region ThrowIfNullOrEmpty

    [Test]
    public void ThrowIfNullOrEmpty_MethodWasCalledOnNonEmptyObject_ObjectWasReturned()
    {
        IEnumerable<int> collection = [1];

        IEnumerable<int> result = collection.ThrowIfNullOrEmpty();

        Assert.That(result, Is.SameAs(collection));
    }

    [Test]
    public void ThrowIfNullOrEmpty_MethodWasCalledOnObjectOfDerivedType_ObjectOfCorrectTypeWasReturned()
    {
        List<int> collection = [1];

        List<int> result = collection.ThrowIfNullOrEmpty();

        Assert.That(result, Is.TypeOf<List<int>>());
        Assert.That(result, Is.SameAs(collection));
    }

    [TestCaseSource(nameof(NullOrEmptyCollectionTestData))]
    public void ThrowIfNullOrNull_MethodWasCalledOnNullWithNoParameters_GenericArgumentExceptionWasThrown(TestCaseData<IEnumerable<int>> testCase)
    {
        IEnumerable<int>? collection = testCase.Object;
        
        Assert.That(() => collection.ThrowIfNullOrEmpty(),
            Throws.InstanceOf(testCase.ExpectedExceptionType)
                .With.Message.EqualTo(testCase.ExpectedExceptionMessage));
    }

    [TestCaseSource(nameof(NullOrEmptyCollectionTestData))]
    public void ThrowIfNullOrNull_MethodWasCalledWithCustomMessage_ArgumentExceptionWasThrownWithProvidedMessage(TestCaseData<IEnumerable<int>> testCase)
    {
        IEnumerable<int>? collection = testCase.Object;
        
        const string message = "This is my custom exception message.";

        Assert.That(() => collection.ThrowIfNullOrEmpty(message: message), 
            Throws.InstanceOf(testCase.ExpectedExceptionType)
                .With.Message.EqualTo(message + " (Parameter 'collection')"));
    }

    [TestCaseSource(nameof(NullOrEmptyCollectionTestData))]
    public void ThrowIfNullOrNull_MethodWasCalledWithExceptionProvider_CustomExceptionWasThrown(TestCaseData<IEnumerable<int>> testCase)
    {
        IEnumerable<int>? collection = testCase.Object;
        
        Exception ExceptionProvider(string? parameterName, string message) =>
            new InvalidOperationException("static message.");

        Assert.That(() => collection.ThrowIfNullOrEmpty(exceptionProvider: ExceptionProvider),
            Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("static message."));
    }

    private static IEnumerable<TestCaseData<IEnumerable<int>>> NullOrEmptyCollectionTestData()
    {
        yield return new(null, typeof(ArgumentNullException), "'collection' must not be null. (Parameter 'collection')");
        yield return new([], typeof(ArgumentException), "'collection' must not be empty. (Parameter 'collection')");
    }
    
    #endregion
}