using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.Java.CodeModel.Expressions
{
    class javaBinaryExpression : JavaExpression
    {
        JavaOperator Operator;
        Value lValue;
        Value rValue;
    }
}
