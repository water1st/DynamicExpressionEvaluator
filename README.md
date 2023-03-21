# ExpressionEvaluator
ExpressionEvaluator is a .NET library for evaluating string expressions using binary expression trees or reverse polish notation.

### Abstractions
The ExpressionEvaluator.Abstractions project contains the core abstractions and interfaces used by the library.

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

### Contributing
Contributions to this project are welcome. Please submit pull requests or issues to the GitHub repository.

License
This project is licensed under the MIT License.
