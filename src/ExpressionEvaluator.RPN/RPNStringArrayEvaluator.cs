using System;
using System.Collections.Generic;

namespace ExpressionEvaluator
{
    internal class RPNStringArrayEvaluator : IStringArrayExpressionEvaluator
    {
        private readonly ICalculator calculator;
        private const int INT32_ZERO = 0;
        public RPNStringArrayEvaluator(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        public string Evaluate(IEnumerable<string> words)
        {
            var tokens = ConvertToRPN(words);

            return EvaluateRPN(tokens);
        }

        private IEnumerable<string> ConvertToRPN(IEnumerable<string> tokens)
        {
            //结果队列
            var result = new Queue<string>();
            //操作符栈
            var stack = new Stack<string>();

            foreach (var token in tokens)
            {
                //如果不是操作符，则直接入列
                if (!token.IsOperator(out var @operator))
                {
                    result.Enqueue(token);
                }
                else
                {
                    if (@operator == DefaultOperators.OPERATOR_RIGHT_PARENTHESIS)
                    {
                        //如果是右括号，则出栈入列直到遇到左括号
                        while (stack.Count > INT32_ZERO && stack.Peek() != DefaultOperators.OPERATOR_LEFT_PARENTHESIS)
                        {
                            result.Enqueue(stack.Pop());
                        }
                        //如果是左括号，则出栈并丢弃
                        if (stack.Count > INT32_ZERO && stack.Peek() == DefaultOperators.OPERATOR_LEFT_PARENTHESIS)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        //如果栈顶的操作符优先级大于目前操作符，则需要出栈入列
                        while (@operator != DefaultOperators.OPERATOR_LEFT_PARENTHESIS && stack.Count > INT32_ZERO && ActivatedOperators.GetPrecedence(@operator) <= ActivatedOperators.GetPrecedence(stack.Peek()))
                        {
                            result.Enqueue(stack.Pop());
                        }

                        //将当前操作符入栈
                        stack.Push(@operator);
                    }
                }
            }

            //将栈内剩余操作符入列
            while (stack.Count > INT32_ZERO)
            {
                result.Enqueue(stack.Pop());
            }

            return result;
        }

        private string EvaluateRPN(IEnumerable<string> tokens)
        {
            //结果栈
            var stack = new Stack<string>();

            foreach (var token in tokens)
            {
                // 如果不是操作符直接入栈
                if (!token.IsOperator(out var @operator))
                {
                    stack.Push(token);
                }
                //如果是操作符，则出栈两个操作数，并进行相应的运算，然后将结果入栈
                else
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    var result = calculator.Calculate(left, right, @operator);

                    stack.Push(result);
                }
            }

            if (stack.Count > 1)
            {
                const string errorMessage = "Expression error! expression is missing an operator or operand";
                throw new ArgumentException(errorMessage);
            }


            // 最后栈中只剩下一个元素，即为最终结果
            return stack.Pop();
        }
    }
}
