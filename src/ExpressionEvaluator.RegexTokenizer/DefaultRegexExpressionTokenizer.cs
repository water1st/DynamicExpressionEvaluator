using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExpressionEvaluator
{
    internal class DefaultRegexExpressionTokenizer : IExpressionTokenizer
    {
        private const int INT32_ZERO = 0;

        public IEnumerable<string> Tokenize(string expression)
        {
            const string pattern = "[-]?\\d+\\.?\\d*|\"[^\"]*\"|True|False|true|false|\\d{4}[-/]\\d{2}[-/]\\d{2}( \\d{2}:\\d{2}:\\d{2})?|(==)|(!=)|(>=)|(<=)|(##)|(!#)|(&&)|(\\|\\|)|[\\\\+\\\\\\-\\\\*/><\\\\(\\\\)]|\\[[^\\[\\]]*\\]";

            var regex = new Regex(pattern);

            var matches = regex.Matches(expression);

            var parenthesis = INT32_ZERO;
            var result = new Queue<string>();
            for (var i = INT32_ZERO; i < matches.Count; i++)
            {
                var value = matches[i].Value;
                //处理当没有使用空格分割操作符的时候，数字遇到减号会被分为负数的问题
                if (i > INT32_ZERO && value.IsNumber(out var currentNumber) && currentNumber < 0
                    && result.Count > INT32_ZERO && result.Last().IsNumber(out _))
                {
                    result.Enqueue(DefaultOperators.OPERATOR_SUBTRACT);
                    result.Enqueue(Math.Abs(currentNumber).ToString());
                    continue;
                }

                //记录括号，如果左括号就加，右括号就减，最后回正就是左右括号数量对等
                if (value == DefaultOperators.OPERATOR_LEFT_PARENTHESIS)
                    parenthesis++;
                else if (value == DefaultOperators.OPERATOR_RIGHT_PARENTHESIS)
                    parenthesis--;

                result.Enqueue(value);
            }

            if (parenthesis != INT32_ZERO)
            {
                const string exceptionMessage = "Expression error! Unequal number of expression parentheses";
                throw new ArgumentException(exceptionMessage);
            }

            return result;
        }
    }
}
