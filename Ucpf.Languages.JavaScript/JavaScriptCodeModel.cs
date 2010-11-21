using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript
{
    class FunctionDeclaration
    {
        private XElement _node;
        public String Identifier
        {
            get
            {
                return _node.Element("Identifier").Value;
            }
        }
        IEnumerable<Variable> Parameters
        {
            get 
            { 
                return _node.Element("formalParameterList").Elements("Identifier").Select(e => new Variable(e)); 
            }
        }
        Block block;
    }

    class FunctionInvocation
    {
        String FunctionName;
        List<Value> Arguments;
    }

    class Variable
    {
        String Identifier;

        public Variable(XElement xElement)
        {
            throw new NotImplementedException();
        }
    }

    class Value
    {
        //nothing
    }

    class Integer : Value
    {
        int NumericalValue;
    }

    class Block
    {
        List<Statement> Statements;
    }

    class Statement
    {
        //nothing
    }

    class IfStatement : Statement
    {
        Expression ConditionalExpression;
        Block TrueBlock;
        Block ElseBlock;
    }

    class ReturnStatement : Statement
    {
        Expression ReturnExpression;
    }

    class Expression
    {
        //nothing
    }

    class UnaryExpression : Expression
    {
        Operator Operator;
        Value Value;
    }

    class BinaryExpression : Expression
    {
        Operator Operator;
        Value lValue;
        Value rValue;
    }

    class Operator
    {
        String OperatorName;
    }

}
