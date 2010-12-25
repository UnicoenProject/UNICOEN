using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.Java.CodeModel.Expressions
{
    class javaBinaryExpression : JavaExpression
    {
        Operator Operator;
        Value lValue;
        Value rValue;
    }
}
