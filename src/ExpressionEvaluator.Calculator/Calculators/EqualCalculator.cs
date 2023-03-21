namespace ExpressionEvaluator
{
    internal class EqualCalculator : BaseCalculator
    {
        public override string Calculate(string left, string right, string @operator)
        {
            if (left.IsDatetime(out var leftDateTime) && right.IsDatetime(out var rightDatetime))
            {
                return (leftDateTime == rightDatetime).ToString();
            }
            else if (left.IsBoolean(out var leftBoolean) && right.IsBoolean(out var rightBoolean))
            {
                return (leftBoolean == rightBoolean).ToString();
            }
            else if (left.IsNumber(out var leftNumber) && right.IsNumber(out var rightNumber))
            {
                return (leftNumber == rightNumber).ToString();
            }
            else if (left.IsString(out var leftString) && right.IsString(out var rightString))
            {
                return (leftString == rightString).ToString();
            }
            else
            {
                throw CreateThrowNotSupportException(left, right, @operator);
            }
        }
    }
}
