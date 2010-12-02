using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript
{
    // program
    // : LT!* sourceElements LT!* EOF!

    // sourceElements
    // : sourceElement (LT!* sourceElement)*

    // sourceElement
    // : functionDeclaration
    // | statement

    public class Program
    {
        private XElement _rootNode;

        public Program(XElement rootNode) {
            _rootNode = rootNode;
        }

        public IEnumerable<FunctionDeclaration> Functions
        {
            get
            {
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
        public FunctionBody FunctionBody
        {
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
            get
            {
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

        public FunctionBody(XElement xElement)
        {
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
        public Expression ConditionalExpression
        {
            get
            {
                return Expression.CreateExpression(_node.Element("expression"));
            }
        }
        public Statement TrueBlock
        {
            get
            {
                // want to get the first "statement" node only
                return new Statement(_node.Element("statement"));
            }
        }
        public IEnumerable<Statement> ElseBlock
        {
            get
            {
                // want to get all "statement" node except the first one
                return _node.Elements("statement").Skip(1).Select(e => new Statement(e));
            }
        }

        public IfStatement(XElement xElement)
            : base(xElement)
        {
            _node = xElement;
        }
    }

    // returnStatement
    // : 'return' expression? (LT | ';')
    public class ReturnStatement : Statement
    {
        private XElement _node;
        public Expression ReturnExpression
        {
            get
            {
                // returnStatement has no expression (It means "return;")
                return new Expression(_node.Element("expression"));
            }
        }
        public ReturnStatement(XElement xElement)
            : base(xElement)
        {
            _node = xElement;
        }
    }

    // expression
    // : assignmentExpression (LT!* ',' LT!* assignmentExpression)*
    public class Expression
    {
        private XElement _node;
        public Expression(XElement eNode)
        {
            _node = eNode;
        }

        protected Expression()
        {
            throw new NotImplementedException();
        }

        public static Expression CreateExpression(XElement xElement)
        {
            String[] binaryOperator = {
                "+", "-", "*", "/", "%"
            };

            var element = xElement.Element("expression").Elements().First();
            var targetElement =
                element.Descendants().Where(e =>
                {
                    var c = e.Elements().Count();
                    return c > 1 || (c == 1 && e.Element("TOKEN") != null);
                }).First();

            //case TOKEN
            if (targetElement.Elements().Count() == 1)
            {
                return new PrimaryExpression(targetElement);
            }

            //case Unary
            // public UnaryExpression(XElement expression, XElement op)
            if (targetElement.Name.LocalName == "UnaryExpression")
            {
                var tempNode = targetElement.Element("postfixExpression");
                if (tempNode != null && tempNode.Elements().Count() == 2)
                {
                    return
                        new UnaryExpression(
                            tempNode.Elements().ElementAt(0),
                            tempNode.Elements().ElementAt(1));
                }
                return
                    new UnaryExpression(
                        targetElement.Elements().ElementAt(1),
                        targetElement.Elements().ElementAt(0));
            }

            //case Binary
            if (binaryOperator.Contains(targetElement.Elements().ElementAt(1).Value))
            {
                return
                    new BinaryExpression(
                        targetElement.Elements().ElementAt(0),
                        targetElement.Elements().ElementAt(1),
                        targetElement.Elements().ElementAt(2));
            }

            return null;
        }
    }

    public class UnaryExpression : Expression
    {
        private XElement _expressionNode;
        private XElement _operatorNode;
        Expression expression
        {
            get
            {
                return CreateExpression(_expressionNode);
            }
        }
        Operator op
        {
            get
            {
                //How distinguish PRE or POST?
                return new Operator(_operatorNode);
            }
        }
        public UnaryExpression(XElement eNode, XElement opNode)
            : base(eNode)
        {
            _expressionNode = eNode;
            _operatorNode = opNode;
        }
    }

    public class BinaryExpression : Expression
    {
        XElement _opNode;
        XElement _lNode;
        XElement _rNode;
        Expression lhs
        {
            get
            {
                return CreateExpression(_lNode);
            }
        }
        Expression rhs
        {
            get
            {
                return CreateExpression(_rNode);
            }
        }
        Operator op
        {
            get
            {
                return CreateOperator(_opNode);
            }
        }

        public static Operator CreateOperator(XElement opNode)
        {
            if (opNode.Value == "+")
            {
                return new PlusOperator(opNode);
            }
            return null;
        }

        public BinaryExpression(XElement firstExpression, XElement operaterName, XElement secondExpression)
        {
            _lNode = firstExpression;
            _rNode = secondExpression;
            _opNode = operaterName;
        }
    }

    public class PlusOperator : Operator
    {
        public PlusOperator(XElement opNode)
        {
            throw new NotImplementedException();
        }
    }

    public class PrimaryExpression : Expression
    {
        private XElement _node;
        String Identifier
        {
            get
            {
                return _node.Value;
            }
        }
        public PrimaryExpression(XElement value)
        {
            _node = value;
        }
    }

    public class CallExpression : Expression
    {
        private XElement _node;
        String Identifier;
        IEnumerable<Expression> Arguments;
        public CallExpression(XElement xElement)
            : base(xElement)
        {
            _node = xElement;
        }
    }

    public class Operator
    {
        XElement _node;
        String operatorName
        {
            get { return _node.Value; }
        }
        public Operator(XElement xElement)
        {
            _node = xElement;
        }

        protected Operator()
        {
            throw new NotImplementedException();
        }
    }

    public class IncreamentBeforeOperator : Operator
    {
        private String _operatorName
        {
            get
            {
                return "++";
            }
        }
        public IncreamentBeforeOperator(XElement _node) : base(_node) { }
    }

}
