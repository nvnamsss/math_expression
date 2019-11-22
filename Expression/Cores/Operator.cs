using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Expression.Cores
{
    public enum Operator
    {
        [Description("+")]
        Plus,
        [Description("-")]
        Minus,
        [Description("*")]
        Multiple,
        [Description("/")]
        Divided,

    }
}
