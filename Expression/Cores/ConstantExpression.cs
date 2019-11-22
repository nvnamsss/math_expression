using System;
using System.Collections.Generic;
using System.Text;

namespace Expression.Cores
{
    public class ConstantExpression : Expression
    {
        public ConstantExpression(float value) : base(value, 1, 0)
        {

        }

        public override IExpression Derive()
        {
            return new ConstantExpression(0);
        }

        public override string ToString(ExpressionFormat format)
        {
            return Coefficient.ToString();
        }
    }
}
