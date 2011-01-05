using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.Java.CodeModel.Statements
{
    public class IfStatement : JavaStatement
    {
        Expression ConditionalExpression;
        Block TrueBlock;
        Block ElseBlock;
    }
}
