using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Languages.Java.CodeModel.Expressions;

namespace Ucpf.Languages.Java.CodeModel
{
    public class IfStatement : JavaStatement
    {
		JavaExpression ConditionalExpression;
        Block TrueBlock;
        Block ElseBlock;
    }
}
