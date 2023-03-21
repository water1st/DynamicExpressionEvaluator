using Microsoft.Extensions.DependencyInjection;

namespace ExpressionEvaluator
{
    public static class ExpressionEvaluatorRPNDefaultExtensions
    {
        public static IExpressionEvaluatorBuilder AddDefaultRPNExpressionEvaluator(this IServiceCollection services)
        {
            var builder = services.AddExpressionEvaluatorCore()
                .AddExpressionEvaluatorRPN()
                .AddExpressionEvaluatorDefaultCalculators()
                .AddExpressionEvaluatorDefaultRegexTokenizer();

            return builder;
        }
    }
}
