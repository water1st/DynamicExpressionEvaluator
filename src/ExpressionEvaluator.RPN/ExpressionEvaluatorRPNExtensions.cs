using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ExpressionEvaluator
{
    public static class ExpressionEvaluatorRPNExtensions
    {
        public static IExpressionEvaluatorBuilder AddExpressionEvaluatorRPN(this IExpressionEvaluatorBuilder builder)
        {
            builder.Services.TryAddScoped<IStringArrayExpressionEvaluator, RPNStringArrayEvaluator>();
            builder.Services.TryAddScoped<IStringExpressionEvaluator, RPNStringEvaluator>();

            return builder;
        }
    }
}
