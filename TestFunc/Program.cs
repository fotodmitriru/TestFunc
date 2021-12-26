using System;
using System.Linq.Expressions;

namespace TestFunc
{
    class Program
    {
        static void Main()
        {
            Func<int, int> xfunc = LocalFunction;
            RunFunc(xfunc);

            int num = 11;

            Expression conditionExpr = Expression.Condition(
                Expression.Constant(num > 10),
                Expression.Constant("num is greater than 10"),
                Expression.Constant("num is smaller than 10")
            );

            Console.WriteLine(conditionExpr.ToString());

            Console.WriteLine(Expression.Lambda<Func<string>>(conditionExpr).Compile()());

            Console.ReadKey();
        }

        public static void RunFunc(Func<int, int> localFunc)
        {
            Console.WriteLine(localFunc.Invoke(3));
        }

        public static int LocalFunction(int z)
        {
            return ++z;
        }
    }
}
