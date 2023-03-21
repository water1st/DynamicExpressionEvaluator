using Microsoft.Extensions.DependencyInjection;

namespace ExpressionEvaluator
{
    public static class ExpressionEvaluatorBETDefaultExtensions
    {
        public static IExpressionEvaluatorBuilder AddDefaultBETExpressionEvaluator(this IServiceCollection services)
        {
            var builder = services.AddExpressionEvaluatorCore()
                .AddExpressionEvaluatorDefaultRegexTokenizer()
                .AddExpressionEvaluatorDefaultCalculators()
                .AddExpressionEvaluatorBET();

            return builder;
        }
    }
}
