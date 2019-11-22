using System;
using System.Collections.Generic;
using System.Text;

namespace Expression.Cores
{
    public class SimpleExpression : Expression, ISimpleExpression
    {
        public SimpleExpression(double coefficent, double variable, int exponential) :
            base(coefficent, variable, exponential)
        {

        }

        public SimpleExpression(double coefficent, int exponential) :
            base(coefficent, 0, exponential)
        {

        }

        public override IExpression Derive()
        {
            SimpleExpression derive = new SimpleExpression(Coefficient * Exponential,
                Variable,
                Exponential - 1);
            return derive;
        }

        public IExpression Simplify()
        {
            if (Coefficient == 0)
            {
                return new ConstantExpression(0);
            }

            if (Exponential == 0)
            {
                return new ConstantExpression((float)Coefficient);
            }

            return this;
        }

        public override string ToString(ExpressionFormat format)
        {
            return (Coefficient > 1 ? Coefficient.ToString() : "") + "x" + 
                (Exponential > 1 ? "^" + Exponential : "");
        }
    }
}
