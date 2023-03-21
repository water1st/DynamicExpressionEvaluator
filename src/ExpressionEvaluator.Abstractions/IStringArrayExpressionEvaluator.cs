using System.Collections.Generic;

namespace ExpressionEvaluator
{
    public interface IStringArrayExpressionEvaluator
    {
        string Evaluate(IEnumerable<string> words);
    }
}
