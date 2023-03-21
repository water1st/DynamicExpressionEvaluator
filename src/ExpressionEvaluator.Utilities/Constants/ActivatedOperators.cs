using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ExpressionEvaluator
{
    public static class ActivatedOperators
    {
        private const byte PRECEDENCE_0 = 0;
        private const byte PRECEDENCE_1 = 1;
        private const byte PRECEDENCE_2 = 2;
        private const byte PRECEDENCE_3 = 3;
        private const byte PRECEDENCE_4 = 4;
        private const byte PRECEDENCE_5 = 5;

        private static ConcurrentDictionary<string, byte> operators;
        private readonly static object lockObject = new object();
        static ActivatedOperators()
        {
            if (operators == null)
            {
                lock (lockObject)
                {
                    if (operators == null)
                    {
                        operators = new ConcurrentDictionary<string, byte>();
                        AddDefaultOperators();
                    }
                }
            }
        }

        private static void AddDefaultOperators()
        {
            operators.TryAdd(DefaultOperators.OPERATOR_LEFT_PARENTHESIS, PRECEDENCE_0);
            operators.TryAdd(DefaultOperators.OPERATOR_RIGHT_PARENTHESIS, PRECEDENCE_0);
            operators.TryAdd(DefaultOperators.OPERATOR_AND, PRECEDENCE_1);
            operators.TryAdd(DefaultOperators.OPERATOR_OR, PRECEDENCE_1);
            operators.TryAdd(DefaultOperators.OPERATOR_EQUAL, PRECEDENCE_2);
            operators.TryAdd(DefaultOperators.OPERATOR_NOT_EQUAL, PRECEDENCE_2);
            operators.TryAdd(DefaultOperators.OPERATOR_CONTAIN, PRECEDENCE_2);
            operators.TryAdd(DefaultOperators.OPERATOR_NOT_CONTAIN, PRECEDENCE_2);
            operators.TryAdd(DefaultOperators.OPERATOR_GREATER_THAN, PRECEDENCE_3);
            operators.TryAdd(DefaultOperators.OPERATOR_GREATER_THAN_OR_EQUAL_TO, PRECEDENCE_3);
            operators.TryAdd(DefaultOperators.OPERATOR_LESS_THAN, PRECEDENCE_3);
            operators.TryAdd(DefaultOperators.OPERATOR_LESS_THAN_OR_EQUAL_TO, PRECEDENCE_3);
            operators.TryAdd(DefaultOperators.OPERATOR_ADD, PRECEDENCE_4);
            operators.TryAdd(DefaultOperators.OPERATOR_SUBTRACT, PRECEDENCE_4);
            operators.TryAdd(DefaultOperators.OPERATOR_MULTIPLY, PRECEDENCE_5);
            operators.TryAdd(DefaultOperators.OPERATOR_DIVIDE, PRECEDENCE_5);
        }

        public static bool Add(string @operator, byte precedence)
        {
            return operators.TryAdd(@operator, precedence);
        }

        public static IEnumerable<string> Get() => operators.Keys;
        public static byte GetPrecedence(string @operator)
        {
            if (operators.TryGetValue(@operator, out var result))
                return result;
            else
                throw new OperatorNotRegisteredExcpetion($"\"{@operator}\" has not registered an operator calculator yet");
        }
    }
}
