using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ExpressionEvaluator
{
    public static class ExpressionEvaluatorCalculatorsExtensions
    {
        public static IExpressionEvaluatorBuilder AddExpressionEvaluatorDefaultCalculators(this IExpressionEvaluatorBuilder builder)
        {
            builder.AddExpressionEvaluatorCalculator<AddCalculator>(DefaultOperators.OPERATOR_ADD);
            builder.AddExpressionEvaluatorCalculator<SubtractCalculator>(DefaultOperators.OPERATOR_SUBTRACT);
            builder.AddExpressionEvaluatorCalculator<MultiplyCalculator>(DefaultOperators.OPERATOR_MULTIPLY);
            builder.AddExpressionEvaluatorCalculator<DivideCalculator>(DefaultOperators.OPERATOR_DIVIDE);
            builder.AddExpressionEvaluatorCalculator<GreaterThanCalculator>(DefaultOperators.OPERATOR_GREATER_THAN);
            builder.AddExpressionEvaluatorCalculator<GreaterThanOrEqualToCalculator>(DefaultOperators.OPERATOR_GREATER_THAN_OR_EQUAL_TO);
            builder.AddExpressionEvaluatorCalculator<LessThanCalculator>(DefaultOperators.OPERATOR_LESS_THAN);
            builder.AddExpressionEvaluatorCalculator<LessThanOrEqualToCalculator>(DefaultOperators.OPERATOR_LESS_THAN_OR_EQUAL_TO);
            builder.AddExpressionEvaluatorCalculator<EqualCalculator>(DefaultOperators.OPERATOR_EQUAL);
            builder.AddExpressionEvaluatorCalculator<NotEqualCalculator>(DefaultOperators.OPERATOR_NOT_EQUAL);
            builder.AddExpressionEvaluatorCalculator<AndCalculator>(DefaultOperators.OPERATOR_AND);
            builder.AddExpressionEvaluatorCalculator<OrCalculator>(DefaultOperators.OPERATOR_OR);
            builder.AddExpressionEvaluatorCalculator<ContainCalculator>(DefaultOperators.OPERATOR_CONTAIN);
            builder.AddExpressionEvaluatorCalculator<NotContainCalculator>(DefaultOperators.OPERATOR_NOT_CONTAIN);

            builder.Services.TryAddScoped<ICalculator, CalculatorMediator>();
            return builder;
        }
        private static IExpressionEvaluatorBuilder AddExpressionEvaluatorCalculator<TCalculator>(this IExpressionEvaluatorBuilder builder, string @operator)
            where TCalculator : class, ICalculator
        {
            if (!CalculatorMediator.CalculatorTypes.ContainsKey(@operator) &&
                CalculatorMediator.CalculatorTypes.TryAdd(@operator, typeof(TCalculator)))
            {

                builder.Services.AddScoped<TCalculator>();
            }

            return builder;
        }

        public static IExpressionEvaluatorBuilder AddExpressionEvaluatorCustomCalculator<TCalculator>(this IExpressionEvaluatorBuilder builder, string @operator, byte precedence)
            where TCalculator : class, ICalculator
        {
            if (!CalculatorMediator.CalculatorTypes.ContainsKey(@operator) &&
                ActivatedOperators.Add(@operator, precedence) &&
                CalculatorMediator.CalculatorTypes.TryAdd(@operator, typeof(TCalculator)))
            {

                builder.Services.AddScoped<TCalculator>();
            }

            builder.Services.TryAddScoped<ICalculator, CalculatorMediator>();

            return builder;
        }
    }
}
