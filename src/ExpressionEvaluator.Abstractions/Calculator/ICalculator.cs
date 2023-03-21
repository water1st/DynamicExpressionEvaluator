namespace ExpressionEvaluator
{
    public interface ICalculator
    {
        string Calculate(string left, string right, string @operator);
    }
}
