using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ucpf.Languages.Java
{

    public class FunctionDeclaration
    {
        private XElement _node;
        public IEnumerable<String> Modifiers
        {
            get
            {
                return _node.Element("modifiers").Elements().Select(e => e.Value);
            }
        }

        public String Identifier
        {
            get
            {
                return _node.Element("Identifier").Value;
            }
        }
        public String ReturnType
        {
            get
            {
                return _node.Element("Type").Elements().ElementAt(0).Value;
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

        public FunctionDeclaration(XElement node)
        {
            _node = node;
        }
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
