using System;
using System.Linq;
using System.Text.Json;

namespace ExpressionEvaluator
{
    public static class StringExtensions
    {
        public static bool IsBoolean(this string value, out bool valueResult)
        {
            return bool.TryParse(value, out valueResult);
        }

        public static bool IsOperator(this string value, out string @operator)
        {
            if (ActivatedOperators.Get().Contains(value))
            {
                @operator = value;
                return true;
            }
            else
            {
                @operator = null;
                return false;
            }
        }

        public static bool IsNumber(this string value, out decimal result)
        {
            return decimal.TryParse(value, out result);
        }

        public static bool IsDatetime(this string value, out DateTime dateTime)
        {
            return DateTime.TryParseExact(value.Replace("\"", "").Trim(), new string[]
                {
                    "yyyy-MM-dd",
                    "yyyy/MM/dd",
                    "yyyy-MM-dd HH:mm:ss",
                    "yyyy-MM/dd HH:mm:ss"
                },
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dateTime);
        }

        public static bool IsString(this string value, out string resultValue)
        {
            var result = false;
            if (!IsDatetime(value, out _) && value.StartsWith(DefaultOperators.CHAR_DOUBLE_QUOTE) && value.EndsWith(DefaultOperators.CHAR_DOUBLE_QUOTE))
            {
                resultValue = value.Trim(DefaultOperators.CHAR_DOUBLE_QUOTE);
                result = true;
            }
            else
            {
                resultValue = null;
            }

            return result;
        }

        public static bool IsStringArray(this string value, out string[] array)
        {
            try
            {
                array = JsonSerializer.Deserialize<string[]>(value);
                return true;
            }
            catch
            {
                array = null;
                return false;
            }
        }
    }
}
