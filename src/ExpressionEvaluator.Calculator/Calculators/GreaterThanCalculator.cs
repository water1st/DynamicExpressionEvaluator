namespace ExpressionEvaluator
{
    internal class GreaterThanCalculator : BaseCalculator
    {
        public override string Calculate(string left, string right, string @operator)
        {
            if (left.IsDatetime(out var leftDatetime) && right.IsDatetime(out var rightDatetime))
            {
                return (leftDatetime > rightDatetime).ToString();
            }
            else if (left.IsNumber(out var leftNumber) && right.IsNumber(out var rightNumber))
            {
                return (leftNumber > rightNumber).ToString();
            }
            else
            {
                throw CreateThrowNotSupportException(left, right, @operator);
            }
        }
    }
}
