using Microsoft.Extensions.DependencyInjection;

namespace ExpressionEvaluator
{
    public interface IExpressionEvaluatorBuilder
    {
        IServiceCollection Services { get; }
    }
}
