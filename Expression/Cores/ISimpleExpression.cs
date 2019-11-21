using System;
using System.Collections.Generic;
using System.Text;

namespace Expression.Cores
{
    public interface ISimpleExpression : IExpression
    {
        IExpression Simplify();
    }
}
