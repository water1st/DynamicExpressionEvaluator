using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ExpressionEvaluator
{
    public static class ExpressionEvaluatorCoreExtensions
    {
        public static IExpressionEvaluatorBuilder AddExpressionEvaluatorCore(this IServiceCollection services)
        {
            return new ExpressionEvaluatorBuilder(services);
        }

        public static IExpressionEvaluatorBuilder AddCustomTokenizer<TTokenizer>(this IExpressionEvaluatorBuilder builder)
            where TTokenizer : class, IExpressionTokenizer
        {
            builder.Services.TryAddScoped<IExpressionTokenizer, TTokenizer>();
            return builder;
        }

        public static IExpressionEvaluatorBuilder AddCustomExpressionStringEvaluator<TEvaluator>(this IExpressionEvaluatorBuilder builder)
            where TEvaluator : class, IStringExpressionEvaluator
        {
            builder.Services.TryAddScoped<IStringExpressionEvaluator, TEvaluator>();
            return builder;
        }

        public static IExpressionEvaluatorBuilder AddCustomExpressionStringArrayEvaluator<TEvaluator>(this IExpressionEvaluatorBuilder builder)
            where TEvaluator : class, IStringArrayExpressionEvaluator
        {
            builder.Services.TryAddScoped<IStringArrayExpressionEvaluator, TEvaluator>();
            return builder;
        }
    }
}
