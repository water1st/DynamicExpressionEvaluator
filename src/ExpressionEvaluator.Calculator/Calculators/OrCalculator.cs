namespace ExpressionEvaluator
{
    internal class OrCalculator : BaseCalculator
    {
        public override string Calculate(string left, string right, string @operator)
        {
            if (left.IsBoolean(out var leftValue) && right.IsBoolean(out var rightValue))
            {
                return (leftValue || rightValue).ToString();
            }
            else
            {
                throw CreateThrowNotSupportException(left, right, @operator);
            }
        }
    }
}
