using System;
using System.Collections.Generic;
using System.Text;

namespace Expression.Cores.Format
{
    public class InfixFormat : ExpressionFormat
    {
        public override string Arrange(List<string> expressions, string @operator)
        {
            string s = "(";
            for (int loop = 0; loop < expressions.Count - 1; loop++)
            {
                s = s + expressions[loop] + " " + @operator + " " + expressions[loop + 1];
            }
            s = s + ")";
            return s;
        }
    }
}
