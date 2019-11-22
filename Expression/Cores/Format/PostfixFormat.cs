using System;
using System.Collections.Generic;
using System.Text;

namespace Expression.Cores.Format
{
    public class PostfixFormat : ExpressionFormat
    {
        public override string Arrange(List<string> expressions, string @operator)
        {
            string s = "";
            for (int loop = 0; loop < expressions.Count; loop++)
            {
                s = s + expressions[loop] + " ";
            }

            s = s + @operator;
            return s;
        }
    }
}
