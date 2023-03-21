using ExpressionEvaluator;
using Microsoft.Extensions.DependencyInjection;

namespace BETSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDefaultBETExpressionEvaluator();

            var provider = services.BuildServiceProvider();

            var expressions = new string[]
        {
                        "4.1+4.1-4.1*4.1/4.1>=100",
                        "1+2*3 == 5",
                        "(1+2) * 3 / 3.14 + 5 - 3",
                        "(((1+2) * 3 / 3.14 + 5 - 3) == (4+6)) || (1/3 + (3+5) == 8)",
                        "1 == 2",
                        "1!=2",
                        "-11>=-5.6",
                        "\"bob\" == \"jan\"",
                        "1<2.2",
                        "\"2022-11-21\" > \"2019-11-22 23:46:22\"",
                        "1>=2",
                        "1<=2",
                        "[\"bob\",\"jack\"] ## \"bob\"",
                        "[\"bob\",\"jack\"] ## \"ben\"",
                        "[\"bob\",\"jack\"] !# \"bob\"",
                        "[\"bob\",\"jack\"] !# \"jan\"",
                        "[\"bob\",\"jack\"] !# [\"jan\"]",
                        "[\"bob\",\"jack\"] ## [\"jan\"]",
                        "1==1 && 1<2",
                        "1==1 || 2==1",
                        "1==3 || true == false",
                        "true==false && 3==1",
                        "\"梓杰的的代码又快又省内存\" ## \"代码\"",
                        "\"梓杰的代码\" ## \"垃圾代码\"",
                        "\"梓杰的代码\" !# \"垃圾代码\""
        };

            var expressionEvaluator = provider.GetService<IStringExpressionEvaluator>();
            foreach (var expression in expressions)
            {
                Console.WriteLine($"{expression} = {expressionEvaluator.Evaluate(expression)}");
            }
        }
    }
}