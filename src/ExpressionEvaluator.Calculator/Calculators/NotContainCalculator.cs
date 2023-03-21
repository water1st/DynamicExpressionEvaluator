using System.Linq;

namespace ExpressionEvaluator
{
    internal class NotContainCalculator : BaseCalculator
    {
        public override string Calculate(string left, string right, string @operator)
        {
            if (left.IsStringArray(out var leftValue))
            {
                if (right.IsString(out var rightValueString))
                {
                    return (!leftValue.Contains(rightValueString)).ToString();
                }
                else if (right.IsStringArray(out var rightValueArray))
                {
                    var rsl = true;
                    foreach (var rightString in rightValueArray)
                    {
                        if (!rsl)
                            break;
                        rsl = rsl && leftValue.Contains(rightString);
                    }
                    return (!rsl).ToString();
                }
                throw CreateThrowNotSupportException(left, right, @operator);
            }
            else if (left.IsString(out var leftValueString) && right.IsString(out var rightValueString))
            {
                return (!leftValueString.Contains(rightValueString)).ToString();
            }
            else
            {
                throw CreateThrowNotSupportException(left, right, @operator);
            }
        }
    }
}
