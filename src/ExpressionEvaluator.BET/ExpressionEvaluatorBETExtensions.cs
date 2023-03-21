using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ExpressionEvaluator
{
    public static class ExpressionEvaluatorBETExtensions
    {
        public static IExpressionEvaluatorBuilder AddExpressionEvaluatorBET(this IExpressionEvaluatorBuilder builder)
        {
            builder.Services.TryAddScoped<IStringArrayExpressionEvaluator, BETStringArrayEvaluator>();
            builder.Services.TryAddScoped<IStringExpressionEvaluator, BETStringEvaluator>();

            return builder;
        }
    }
}
