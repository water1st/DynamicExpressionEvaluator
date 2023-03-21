using Microsoft.Extensions.DependencyInjection;

namespace ExpressionEvaluator
{
    internal class ExpressionEvaluatorBuilder : IExpressionEvaluatorBuilder
    {
        public ExpressionEvaluatorBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
