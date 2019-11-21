using System;
using System.Collections.Generic;
using System.Text;

namespace Expression.Cores
{
    public interface IComplexExpression
    {
        List<IExpression> Expressions { get; set; }
        Operator Operator { get; set; }
        void Add(IExpression expression);
    }
}
