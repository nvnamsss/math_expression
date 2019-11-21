using System;
using System.Collections.Generic;
using System.Text;

namespace Expression.Cores
{
    public abstract class Expression : IExpression
    {
        public double Coefficient { get; }

        public int Exponential { get; }

        public double Variable { get; set; }
        protected double Value
        {
            get
            {
                return Coefficient * Math.Pow(Variable, Exponential);
            }
        }

        public abstract IExpression Derive();

        protected Expression()
        {
            Coefficient = 0;
            Variable = 0;
            Exponential = 0;
        }

        public Expression(double coefficient, double variable, int exponential)
        {
            Coefficient = coefficient;
            Exponential = exponential;
            Variable = variable;
        }

        public virtual double Evaluate()
        {
            return Value;
        }

        public double Evaluate(double variable)
        {
            Variable = variable;
            return Evaluate();
        }

        public string ToString(ExpressionFormat format)
        {
            return base.ToString();
        }

    }
}
