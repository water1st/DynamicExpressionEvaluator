using System.Collections.Generic;

namespace ExpressionEvaluator
{
    public interface IExpressionTokenizer
    {
        IEnumerable<string> Tokenize(string expression);
    }
}
