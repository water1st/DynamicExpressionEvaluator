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

        public static IExpressionEvaluatorBuilder AddCustomTokenizer<Tokenizer>(this IExpressionEvaluatorBuilder builder)
            where Tokenizer : class, IExpressionTokenizer
        {
            builder.Services.TryAddScoped<IExpressionTokenizer, Tokenizer>();
            return builder;
        }
    }
}
