using System;
using System.Runtime.Serialization;

namespace ExpressionEvaluator
{
    public class OperatorNotRegisteredExcpetion : Exception
    {
        public OperatorNotRegisteredExcpetion()
        {
        }

        public OperatorNotRegisteredExcpetion(string message) : base(message)
        {
        }

        public OperatorNotRegisteredExcpetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OperatorNotRegisteredExcpetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
