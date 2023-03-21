namespace ExpressionEvaluator
{
    internal class AndCalculator : BaseCalculator
    {
        public override string Calculate(string left, string right, string @operator)
        {
            if (left.IsBoolean(out var leftValue) && right.IsBoolean(out var rightValue))
            {
                return (leftValue && rightValue).ToString();
            }
            else
            {
                throw CreateThrowNotSupportException(left, right, @operator);
            }
        }
    }
}
