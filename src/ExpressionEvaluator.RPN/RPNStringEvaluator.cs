namespace ExpressionEvaluator
{
    internal class RPNStringEvaluator : IStringExpressionEvaluator
    {
        private readonly IExpressionTokenizer tokenizer;
        private readonly IStringArrayExpressionEvaluator evaluator;

        public RPNStringEvaluator(IExpressionTokenizer tokenizer, IStringArrayExpressionEvaluator evaluator)
        {
            this.tokenizer = tokenizer;
            this.evaluator = evaluator;
        }

        public string Evaluate(string expression)
        {
            var tokens = tokenizer.Tokenize(expression);
            return evaluator.Evaluate(tokens);
        }
    }
}
