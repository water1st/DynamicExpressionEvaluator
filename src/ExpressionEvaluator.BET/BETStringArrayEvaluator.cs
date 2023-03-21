using System;
using System.Collections.Generic;

namespace ExpressionEvaluator
{
    internal class BETStringArrayEvaluator : IStringArrayExpressionEvaluator
    {
        private const int INT32_ZERO = 0;
        private readonly ICalculator calculator;

        public BETStringArrayEvaluator(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        private ExpressionNode BuildTree(IEnumerable<string> tokens)
        {
            //结果栈
            var result = new Stack<ExpressionNode>();
            //操作符栈
            var stack = new Stack<ExpressionNode>();

            void SetChildNode()
            {
                var parent = stack.Pop();
                var right = result.Pop();
                var left = result.Pop();

                parent.Left = left;
                parent.Right = right;

                result.Push(parent);
            }


            foreach (var token in tokens)
            {

                //如果不是操作符，则直接入列
                if (!token.IsOperator(out var @operator))
                {
                    result.Push(new ExpressionNode
                    {
                        Value = token
                    });
                }
                else
                {
                    if (@operator == DefaultOperators.OPERATOR_RIGHT_PARENTHESIS)
                    {
                        //如果是右括号，则出栈入列直到遇到左括号
                        while (stack.Count > INT32_ZERO && stack.Peek().Value != DefaultOperators.OPERATOR_LEFT_PARENTHESIS)
                        {
                            SetChildNode();
                        }
                        //如果是左括号，则出栈并丢弃
                        if (stack.Count > INT32_ZERO && stack.Peek().Value == DefaultOperators.OPERATOR_LEFT_PARENTHESIS)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        //如果栈顶的操作符优先级大于目前操作符，则需要出栈入列
                        while (@operator != DefaultOperators.OPERATOR_LEFT_PARENTHESIS && stack.Count > INT32_ZERO && ActivatedOperators.GetPrecedence(@operator) <= ActivatedOperators.GetPrecedence(stack.Peek().Value))
                        {
                            SetChildNode();
                        }

                        //将当前操作符入栈
                        stack.Push(new ExpressionNode
                        {
                            Value = @operator
                        });
                    }
                }

            }

            while (result.Count > 1)
            {
                if (stack.Count == INT32_ZERO || result.Count < 2)
                {
                    const string errorMessage = "Expression error! expression is missing an operator or operand";
                    throw new ArgumentException(errorMessage);
                }

                SetChildNode();
            }

            return result.Pop();
        }

        private ExpressionNode EvaluateTree(ExpressionNode node)
        {
            if (node.Value.IsOperator(out var @operator))
            {
                var leftResult = EvaluateTree(node.Left);
                var rightResult = EvaluateTree(node.Right);

                var result = calculator.Calculate(leftResult.Value, rightResult.Value, @operator);

                return new ExpressionNode { Value = result };
            }

            return node;
        }

        public string Evaluate(IEnumerable<string> tokens)
        {
            var root = BuildTree(tokens);
            var result = EvaluateTree(root);

            return result.Value;
        }

    }
}
