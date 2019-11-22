using System;
using System.Collections.Generic;
using System.Text;

namespace Expression.Cores.Format
{
    public class PrefixFormat : ExpressionFormat
    {
        public override string Arrange(List<string> expressions, string @operator)
        {
            string s = @operator + " ";
            for (int loop = 0; loop < expressions.Count; loop++)
            {
                s = s + expressions[loop] + " ";
            }
            return s;
        }
    }
}
