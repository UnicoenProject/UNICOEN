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

    public class Program {
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

    public class FunctionDeclaration
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
    public class FunctionInvocation
    {
        String FunctionName;
        IEnumerable<Value> Arguments;
    }

    public class Variable
    {
        String Identifier;

        public Variable(XElement xElement)
        {
            throw new NotImplementedException();
        }
    }

    public class Value
    {
        //nothing
    }

    public class Integer : Value
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
    public class FunctionBody
    {
        private XElement _node;
        public IEnumerable<FunctionDeclaration> FunctionDeclarations 
        {
            get 
            {
                return _node.Element("sourceElements").Elements(
                    "sourceElement")
                    .SelectMany(e => 
                        e.Elements("functionDeclaration").Select(
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
                        e.Elements("statement").Select(
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

    public class Statement 
    {
        private XElement _node;
        public Statement(XElement xElement) 
        {
            _node = xElement;
        }
    }

    // ifStatement
	// : 'if' LT!* '(' LT!* expression LT!* ')' LT!* statement (LT!* 'else' LT!* statement)?
    public class IfStatement : Statement 
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
                // want to get the first "statement" node only
                return new Statement(_node.Element("statement"));
            }
        }
        public IEnumerable<Statement> ElseBlock {
            get {
                // want to get all "statement" node except the first one
                return _node.Elements("statement").Skip(1).Select(e => new Statement(e)); 
            }
        }
        public IfStatement(XElement xElement)
            : base(xElement) {
            _node = xElement;
        }
    }

    // returnStatement
	// : 'return' expression? (LT | ';')
    public class ReturnStatement : Statement
    {
        private XElement _node;
        public Expression ReturnExpression {
            get {
                // returnStatement has no expression (It means "return;")
                return new Expression(_node.Element("expression"));
            }
        }
        public ReturnStatement(XElement xElement)
            : base(xElement) {
            _node = xElement;
        }
    }

    public class Expression
    {
        private XElement _node;
        public Expression(XElement xElement) {
            _node = xElement;
        }
    }

    public class UnaryExpression : Expression
    {
        private XElement _node;
        private String name;
        Operator Operator;
        public UnaryExpression(XElement xElement)
            : base(xElement) {
            _node = xElement;
        }
    }

    public class BinaryExpression : Expression
    {
        private XElement _node;
        Operator Operator;
        Expression lValue;
        Expression rValue;
        public BinaryExpression(XElement xElement)
            : base(xElement) {
            _node = xElement;
        }
    }

    public class CallExpression : Expression
    {
        private XElement _node;
        String Identifier;
        IEnumerable<Expression> Arguments;
        public CallExpression(XElement xElement)
            : base(xElement) {
            _node = xElement;
        }
    }

    public class Operator
    {
        String OperatorName;
    }

}
