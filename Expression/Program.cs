using Expression.Cores;
using System;

namespace Expression
{
    class Program
    {
        static void Main(string[] args)
        {

            ComplexExpression fxt = new ComplexExpression(new SimpleExpression(5, 2),
                Operator.Plus,
                new ConstantExpression(3));
            ComplexExpression fx = new ComplexExpression(fxt,
                Operator.Multiple,
                new SimpleExpression(2, 1));

            Console.WriteLine(fx.Evaluate(2));
            Console.WriteLine("Hello World!");
        }
    }
}
