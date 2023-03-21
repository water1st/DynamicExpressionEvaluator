using Microsoft.Extensions.DependencyInjection;

namespace ExpressionEvaluator
{
    public static class ExpressionEvaluatorCoreExtensions
    {
        public static IExpressionEvaluatorBuilder AddExpressionEvaluatorCore(this IServiceCollection services)
        {
            return new ExpressionEvaluatorBuilder(services);
        }
    }
}
