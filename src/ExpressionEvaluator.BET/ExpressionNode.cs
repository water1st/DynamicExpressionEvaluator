namespace ExpressionEvaluator
{
    internal class ExpressionNode
    {
        public string Value { get; set; }
        public ExpressionNode Left { get; set; }
        public ExpressionNode Right { get; set; }
    }
}
