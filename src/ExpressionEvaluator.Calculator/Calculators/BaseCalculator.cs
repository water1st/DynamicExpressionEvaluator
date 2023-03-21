using System;

namespace ExpressionEvaluator
{
    internal abstract class BaseCalculator: ICalculator
    {
        public abstract string Calculate(string left, string right,string @operator);

        protected NotSupportedException CreateThrowNotSupportException(string left, string right, string @operator)
        {
            return new NotSupportedException($"{@operator} operation of {left} type and {right} type is not supported");
        }
    }
}
