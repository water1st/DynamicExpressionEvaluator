using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ExpressionEvaluator
{
    public static class ExpressionEvaluatorDefaultRegexTokenizerExtensions
    {
        public static IExpressionEvaluatorBuilder AddExpressionEvaluatorDefaultRegexTokenizer(this IExpressionEvaluatorBuilder builder)
        {
            builder.Services.TryAddScoped<IExpressionTokenizer, DefaultRegexExpressionTokenizer>();

            return builder;
        }
    }
}
