using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;

namespace ExpressionEvaluator
{
    internal class CalculatorMediator : ICalculator
    {
        internal readonly static ConcurrentDictionary<string, Type> CalculatorTypes = new ConcurrentDictionary<string, Type>();
        private readonly IServiceProvider serviceProvider;

        public CalculatorMediator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Calculate(string left, string right, string @operator)
        {
            if (CalculatorTypes.TryGetValue(@operator, out var type))
            {
                var calculator = serviceProvider.GetRequiredService(type) as ICalculator;
                return calculator.Calculate(left, right, @operator);
            }

            throw new OperatorNotRegisteredExcpetion($"\"{@operator}\" has not registered an operator calculator yet");
        }

    }
}
