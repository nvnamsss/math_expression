using System;
using System.Collections.Generic;
using System.Text;

namespace Expression.Cores
{
    public abstract class ExpressionFormat
    {
        public abstract string Arrange(List<string> expressions, string @operator);

    }
}
