namespace ExpressionEvaluator
{
    internal class BETStringEvaluator : IStringExpressionEvaluator
    {
        private readonly IStringArrayExpressionEvaluator evaluator;
        private readonly IExpressionTokenizer tokenizer;

        public BETStringEvaluator(IStringArrayExpressionEvaluator evaluator, IExpressionTokenizer tokenizer)
        {
            this.evaluator = evaluator;
            this.tokenizer = tokenizer;
        }

        public string Evaluate(string expression)
        {
            var tokens = tokenizer.Tokenize(expression);
            var result = evaluator.Evaluate(tokens);
            return result;
        }
    }
}
