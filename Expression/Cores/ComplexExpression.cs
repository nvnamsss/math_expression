using System;
using System.Collections.Generic;
using System.Text;

namespace Expression.Cores
{
    public class ComplexExpression : Expression, IComplexExpression
    {
        public List<IExpression> Expressions { get; set; }
        public Operator Operator { get; set; }

        public ComplexExpression(double coefficent, double variable, int exponential, Operator @operator) : 
            base(coefficent, variable, exponential)
        {
            Expressions = new List<IExpression>();
            Operator = @operator;
        }

        public ComplexExpression(double coefficent, int exponential, Operator @operator) : 
            this(coefficent, 0, exponential, @operator)
        {

        }

        public ComplexExpression(IExpression u, Operator @operator, IExpression v) :
            this(1, 0, 1, @operator)
        {
            Expressions.Add(u);
            Expressions.Add(v);
        }

        public ComplexExpression(ComplexExpression expression) : 
            this(expression.Coefficient, expression.Variable, expression.Exponential, expression.Operator)
        {
            Expressions.AddRange(expression.Expressions);
        }

        public ComplexExpression(ComplexExpression expression, double coefficient, int exponential) :
            this(coefficient, expression.Variable, exponential, expression.Operator)
        {
            Expressions.AddRange(expression.Expressions);
        }

        public override double Evaluate()
        {
            if (Operator == Operator.Plus)
            {
                double sum = 0;
                for (int loop = 0; loop < Expressions.Count; loop++)
                {
                    sum += Expressions[loop].Evaluate(Variable);
                }

                return sum;
            }

            if (Operator == Operator.Plus)
            {
                double sum = Expressions[0].Evaluate();
                for (int loop = 1; loop < Expressions.Count; loop++)
                {
                    sum -= Expressions[loop].Evaluate(Variable);
                }

                return sum;
            }

            if (Operator == Operator.Multiple)
            {
                double multiply = 1;
                for (int loop = 0; loop < Expressions.Count; loop++)
                {
                    multiply *= Expressions[loop].Evaluate(Variable);
                }

                return multiply;
            }

            if (Operator == Operator.Divided)
            {
                double multiply = Expressions[0].Evaluate();
                for (int loop = 1; loop < Expressions.Count; loop++)
                {
                    multiply /= Expressions[loop].Evaluate(Variable);
                }

                return multiply;
            }

            throw new NotImplementedException("Why we are here?");
        }

        public override IExpression Derive()
        {
            if (Operator == Operator.Plus || Operator == Operator.Minus)
            {
                ComplexExpression expression = new ComplexExpression(1, 1, 1, Operator);

                for (int loop = 0; loop < Expressions.Count; loop++)
                {
                    expression.Add(Expressions[loop].Derive());
                }

                return expression;
            }

            if (Operator == Operator.Multiple)
            {
                ComplexExpression expression = new ComplexExpression(1, 1, 1, Operator.Plus);

                for (int loop = 0; loop < Expressions.Count; loop++)
                {
                    ComplexExpression subExpression = new ComplexExpression(1, 1, Operator.Multiple);
                    for (int loop2 = 0; loop2 < Expressions.Count; loop2++)
                    {
                        if (loop2 == loop)
                        {
                            subExpression.Add(Expressions[loop2].Derive());
                        }
                        else
                        {
                            subExpression.Add(Expressions[loop2]);
                        }
                    }
                    expression.Add(subExpression);
                }

                return expression;
            }

            if (Operator == Operator.Divided)
            {
                ComplexExpression expression = new ComplexExpression(1, 1, 1, Operator.Divided);

                IExpression u = Expressions[0];
                ComplexExpression v = new ComplexExpression(1, 1, Operator.Multiple);

                for (int loop = 1; loop < Expressions.Count; loop++)
                {
                    v.Add(Expressions[loop]);
                }

                ComplexExpression up = new ComplexExpression(new ComplexExpression(u.Derive(), Operator.Multiple, v),
                    Operator.Minus,
                    new ComplexExpression(u, Operator.Multiple, v.Derive()));

                ComplexExpression down = new ComplexExpression(v, v.Coefficient, v.Exponential * 2);

                expression = new ComplexExpression(up, Operator.Divided, down);
                return expression;
            }

            throw new NotImplementedException("Why we are here?");
        }

        public void Add(IExpression expression)
        {
            Expressions.Add(expression);
        }
    }
}
