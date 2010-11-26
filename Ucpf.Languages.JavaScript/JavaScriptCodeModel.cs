using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Paraiba.Xml.Linq;

namespace Ucpf.Languages.JavaScript
{
    // program
	// : LT!* sourceElements LT!* EOF!

    // sourceElements
	// : sourceElement (LT!* sourceElement)*

    // sourceElement
	// : functionDeclaration
	// | statement

    class Program {
        private XElement _rootNode;
        public IEnumerable<FunctionDeclaration> Functions
        {
            get {
                return _rootNode.Element("sourceElements").Elements(
                    "sourceElement")
                    .SelectMany(e => 
                        e.Elements("functionDeclaration").Select(
                            e2 => new FunctionDeclaration(e2))
                    );

            }
        }
        public IEnumerable<Statement> Statements
        {
            get 
            {
                return _rootNode.Elements("statement").Select(e => new Statement(e));
            }
        }
    }

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
        public IEnumerable<Variable> Parameters
        {
            get 
            { 
                return _node.Element("formalParameterList").Elements("Identifier").Select(e => new Variable(e)); 
            }
        }
        public FunctionBody FunctionBody {
            get 
            {
                return new FunctionBody(_node.Element("functionBody"));
            }
        }
        public FunctionDeclaration(XElement xElement) 
        {
            _node = xElement;
        }
    }

    //callExpression
    class FunctionInvocation
    {
        String FunctionName;
        IEnumerable<Value> Arguments;
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

    class FunctionBody
    {
        private XElement _node;
        public IEnumerable<FunctionDeclaration> FunctionDeclaration 
        {
            get 
            {
                return _node.Elements("functionDeclaration").Select(e => new FunctionDeclaration(e)); ;
            }
        }
        public IEnumerable<Statement> Statements
        {
            get {
                _node.Elements("statement")
                    .Where(
                        e =>
                        e.Ancestors().TakeWhile(e2 => e2 != _node).All(
                            e2 => e2.Name.LocalName != "statement"));
                return _node.Elements("statement").Select(e => new Statement(e)); ;
            }
        }

        private Statement createStatement(XElement xElement)
        {
            var element = xElement.Element("Statement").Elements().First();
            if (element.Name.LocalName == "TOKEN" && element.Value == "if") return new IfStatement();
            throw new NotImplementedException();
        } 

        public FunctionBody(XElement xElement) {
            _node = xElement;
        }
    }

    class Statement 
    {
        private XElement _node;
        public Statement(XElement xElement) 
        {
            _node = xElement;
        }
    }

    class IfStatement : Statement {
        Expression ConditionalExpression;
        FunctionBody TrueBlock;
        FunctionBody ElseBlock;
        public IfStatement(XElement xElement)
            : base(xElement)
        {
            
        }
    }

    class ReturnStatement : Statement
    {
        Expression ReturnExpression;
        public ReturnStatement(XElement xElement)
            : base(xElement)
        {
            
        }
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
