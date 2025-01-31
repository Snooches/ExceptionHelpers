# ExceptionHelpers
Collection of Extension methods to easily validate parameters

## How to use

All checks are implemented as extension methods. That means you can invoke them directly on the parameter in question:

    public void Method(object parameter)
    {
        parameter.ThrowIfNull();
        ...
    }

All checks return the parameter they were called on (unless they throw an exception of course).
This allows you to chain multiple checks or use them in assignments:

    public void Constructor(String strParameter, object objParameter)
    {
        this.ImportantObject = objParameter.Throw()
        this.importantString = strParameter.ThrowIfNullOrWhiteSpace()
                                           .ThrowIfInvalidLength(3,15);
    }

All checks have default values for the Exceptions that are thrown as well as the generated messages.
These can be overriden by providing additional Parameters to the check-Method:

    public void Method()
    {
        string str = null;
        str.ThrowIfNull("my message"); 
        //Result is a ArgumentNullException with the included message

        Exception ExceptionProvider(string? parameterName, string message) 
            => new CustomException(message, parameterName);
        str.ThrowIfNull("msg",  ExceptionProvider); 
        // Result is a exception of CustomException 
        // (possibly including the message, depending on the implementation of the constructor)
    }

## Possible extension
Checking the source code in this repo it should not be difficult to include support for more types. 
If you think this very basic set is missing some important types, feel free to [create an issue](https://github.com/Snooches/ExceptionHelpers/issues), and maybe I will get around to it.