# ExpressionEvaluator
ExpressionEvaluator is a .NET library for evaluating string expressions using binary expression trees or reverse polish notation.

### Abstractions
The ExpressionEvaluator.Abstractions project contains the core abstractions and interfaces used by the library.
The `IStringArrayExpressionEvaluator` interface defines a string Evaluate(IEnumerable<string> words) method, which takes an iterator object words that represents a tokenized expression, such as `["1", "+", "2"]`. The Evaluate method evaluates the expression and returns the result as a string.

The IStringArrayExpressionEvaluator interface provides an abstraction for evaluating mathematical expressions represented as arrays of strings. By separating the evaluation logic from the expression parsing logic, this interface allows for greater flexibility and modularity in the implementation of mathematical expression evaluators.

### BET
The ExpressionEvaluator.BET project contains an implementation of the expression evaluator using binary expression trees.

### RPN
The ExpressionEvaluator.RPN project contains an implementation of the expression evaluator using reverse polish notation.

### Calculator
The ExpressionEvaluator.Calculator project contains a calculator implementation for evaluating arithmetic expressions.

### RegexTokenizer
The ExpressionEvaluator.RegexTokenizer project contains an implementation of a tokenizer using regular expressions.

### Utilities
The ExpressionEvaluator.Utilities project contains utility classes and methods used by the library.

### Default Implementations
The ExpressionEvaluator.Default.BET and ExpressionEvaluator.Default.RPN projects provide quick registration of the ExpressionEvaluator to the dependency injection container.

### Getting Started
To get started, add the ExpressionEvaluator to your IServiceCollection and use the IStringExpressionEvaluator to evaluate expressions:

```csharp
var services = new ServiceCollection();
services.AddDefaultBETExpressionEvaluator();
var provider = services.BuildServiceProvider();
var expressions = new string[] { /* list of expressions to evaluate */ };
var expressionEvaluator = provider.GetService<IStringExpressionEvaluator>();

foreach (var expression in expressions)
{
    Console.WriteLine($"{expression} = {expressionEvaluator.Evaluate(expression)}");
}
```

### Customization
ExpressionEvaluator provides customization options to allow users to add their own functionality to the library.

#### Custom Tokenizer
Users can implement their own tokenizer by implementing the ITokenizer interface and registering it with the `IExpressionEvaluatorBuilder` using the `AddCustomTokenizer` method.

For example, a custom tokenizer that splits expressions into words separated by underscores could be implemented as follows:


```csharp
public class UnderscoreTokenizer : ITokenizer
{
    public IEnumerable<string> Tokenize(string expression)
    {
        return expression.Split('_');
    }
}
```
And registered using:

```csharp
services.AddExpressionEvaluatorCore()
    .AddCustomTokenizer<UnderscoreTokenizer>();
```

#### Custom Expression Evaluators
ExpressionEvaluator provides interfaces to implement custom evaluators for both single string expressions and arrays of string expressions.

#### Single String Expression Evaluators
Users can implement their own single string expression evaluators by implementing the `IStringExpressionEvaluator` interface and registering it with the `IExpressionEvaluatorBuilder` using the `AddCustomExpressionStringEvaluator` method.

For example, a custom evaluator that evaluates expressions as JavaScript code could be implemented as follows:

```csharp
public class JavaScriptEvaluator : IStringExpressionEvaluator
{
    public string Evaluate(string expression)
    {
        // evaluate expression as JavaScript code
        return JavaScriptEngine.Evaluate(expression).ToString();
    }
}
```

And registered using:

```csharp
services.AddExpressionEvaluatorCore()
    .AddCustomExpressionStringEvaluator<JavaScriptEvaluator>();
```

### Contributing
Contributions to this project are welcome. Please submit pull requests or issues to the GitHub repository.

License
This project is licensed under the MIT License.
