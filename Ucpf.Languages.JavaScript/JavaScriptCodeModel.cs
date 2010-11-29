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
                return _rootNode.Element("sourceElements").Elements(
                    "sourceElement")
                    .SelectMany(e => 
                        e.Elements("statement").Select(
                            e2 => new Statement(e2))
                    );
            }
        }
    }

    // functionDeclaration
	// : 'function' LT!* Identifier LT!* formalParameterList LT!* functionBody

    // formalParameterList
	// : '(' (LT!* Identifier (LT!* ',' LT!* Identifier)*)? LT!* ')'

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

    // callExpression
	// : memberExpression LT!* arguments (LT!* callExpressionSuffix)*
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

    // functionBody
	// : '{' LT!* sourceElements LT!* '}'

    // sourceElements
	// : sourceElement (LT!* sourceElement)*
	
    // sourceElement
	// : functionDeclaration
	// | statement
    class FunctionBody
    {
        private XElement _node;
        public IEnumerable<FunctionDeclaration> FunctionDeclarations 
        {
            get 
            {
                return _node.Element("sourceElements").Elements(
                    "sourceElement")
                    .SelectMany(e => 
                        e.Elements("statement").Select(
                            e2 => new FunctionDeclaration(e2))
                );
            }
        }
        public IEnumerable<Statement> Statements
        {
            get {
                return _node.Element("sourceElements").Elements(
                    "sourceElement")
                    .SelectMany(e => 
                        e.Elements("Statement").Select(
                            e2 => createStatement(e2))
                );
            }
        }

        // statement
        // : statementBlock
        // | variableStatement
        // | emptyStatement
        // | expressionStatement
        // | ifStatement
        // | iterationStatement
        // | continueStatement
        // | breakStatement
        // | returnStatement
        // | withStatement
        // | labelledStatement
        // | switchStatement
        // | throwStatement
        // | tryStatement
        private Statement createStatement(XElement xElement)
        {
            // Can "xElement.Element("statement").Elements().First()" get first childNode of statement?
            var element = xElement.Element("statement").Elements().First();
            if (element.Name.LocalName == "ifStatement") return new IfStatement(xElement);
            if (element.Name.LocalName == "returnStatement") return new ReturnStatement(xElement);
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

    // ifStatement
	// : 'if' LT!* '(' LT!* expression LT!* ')' LT!* statement (LT!* 'else' LT!* statement)?
    class IfStatement : Statement 
    {
        // Is it need that the declaration of field of "_node" when this class inherit the "Statement" class?
        private XElement _node;
        public Expression ConditionalExpression {
            get  {
                return new Expression(_node.Element("expression"));
            }
        }
        public Statement TrueBlock {
            get {
                // want to first "statement" node only
                return new Statement(_node.Element("statement"));
            }
        }
        public IEnumerable<Statement> ElseBlock {
            get {
                // want to all "statement" node except the first one
                return _node.Elements("statement").Select(e => new Statement(e)); 
            }
        }
        public IfStatement(XElement xElement)
            : base(xElement) {
            _node = xElement;
        }
    }

    class ReturnStatement : Statement
    {
        private XElement _node;
        public Expression ReturnExpression {
            get {
                return new Expression(_node.Element("expression"));
            }
        }
        public ReturnStatement(XElement xElement)
            : base(xElement) {
            _node = xElement;
        }
    }

    class Expression {
        private XElement _node;
        public Expression(XElement xElement) {
            _node = xElement;
        }
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
