# DynamicExpressionEvaluator

### Getting started

To use the Exceptionless sink, first install the [NuGet package](https://www.nuget.org/packages/DynamicExpressionEvaluator.Default.RPN/):

```powershell
Install-Package DynamicExpressionEvaluator.Default.RPN
``` 

Next, we need to ensure that DynamicExpressionEvaluator has been Registerd. 

```csharp
using Exceptionless;
ExceptionlessClient.Default.Startup("API_KEY");
```

Next, enable the sink using `WriteTo.Exceptionless()`

```csharp
services.AddDefaultRPNExpressionEvaluator();
```
Next, Injection the `IStringExpressionEvaluator` where you use it

Done!
