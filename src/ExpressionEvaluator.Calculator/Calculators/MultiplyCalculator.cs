namespace ExpressionEvaluator
{
    internal class MultiplyCalculator : BaseCalculator
    {
        public override string Calculate(string left, string right, string @operator)
        {
            if (left.IsNumber(out var leftValue) && right.IsNumber(out var rightValue))
            {
                return (leftValue * rightValue).ToString();
            }
            else
            {
                throw CreateThrowNotSupportException(left, right, @operator);
            }
        }
    }
}
