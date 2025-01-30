namespace ExceptionHelpersTests;

public record TestCaseData<T>(T? Object, Type ExpectedExceptionType, string ExpectedExceptionMessage);