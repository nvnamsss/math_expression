using System;
using System.Collections.Generic;
using System.Text;

namespace Expression.Cores
{
    public interface IExpression
    {
        double Coefficient { get; }
        double Variable { get; set; }
        int Exponential { get; }
        double Evaluate();
        double Evaluate(double variable);
        IExpression Derive();
        
    }
}
