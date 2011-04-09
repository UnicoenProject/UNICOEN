using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Paraiba.Xml.Linq;
using Ucpf.Core.Model;
using Code2Xml.Languages.Java.XmlGenerators;
using System.Collections.Generic;

namespace Ucpf.Languages.Java.Model {
	public class JavaModelFactory
	{
		#region Expression

		public static IUnifiedExpression CreateExpression(XElement node) {
			Contract.Requires(node != null);
			//Contract.Requires(node.Name().ToLower().EndsWith("expression"));
			//UnaryExpressionの際に<primary>が来る可能性もある

			//TODO IMPLEMENT: more operators
			var binaryOperator = new[] { "+", "-", "*", "/", "%", "<", ">" };

			/* 
			 * in descendants of <expression> node, if
			 * it has more than 2 child-node OR
			 * it has only one child whose name is <IDENTIFIER> OR
			 * it has only one child whose name is <TOKEN> 
			 * these are some actual expression
			*/
			var expressionList =
				node.DescendantsAndSelf().Where(e => {
					var c = e.Elements().Count();
					return c > 1 || (c == 1 && e.Element("IDENTIFIER") != null) ||
						   (c == 1 && e.Element("TOKEN") != null);
				});

			//Ensure that node has some expression
			Debug.Assert(expressionList.Count() != 0);

			var topExpressionElement = expressionList.First();

			//case <primary>: child is IDENTIFIER or TOKEN
			if (topExpressionElement.Elements().Count() == 1) {
				//case true or false literal
				switch(topExpressionElement.Value) {
					case "true":
					case "false":
					return CreateBooleanLiteral(topExpressionElement);
				}
				
				//case Variable
				var regex = new Regex(@"^[a-zA-Z_]{1}[a-zA-Z0-9_]*$");
				if(regex.IsMatch(topExpressionElement.Value))
					return CreateVariable(topExpressionElement);

				//other cases
				return CreateLiteral(topExpressionElement);
			}

			//case BinaryExpression
			var binaryOperatorString = topExpressionElement.Elements().ElementAt(1).Value;
			if (binaryOperator.Contains(binaryOperatorString)) {
				return CreateBinaryExpression(topExpressionElement);
			}
			if(topExpressionElement.Name() == "expression") {
				return CreateBinaryExpression(topExpressionElement);
			}

			switch (topExpressionElement.Name()) {
			case "unaryExpression":
				return CreateUnaryExpression(topExpressionElement);
			case "unaryExpressionNotPlusMinus":
				return CreateUnaryExpressionNotPlusMinus(topExpressionElement);
			case "primary":
				//case CallExpression
				return CreatePrimary(topExpressionElement);
			case "parExpression":
				// expression を () で囲ったような場合
				return CreateExpression(topExpressionElement.Elements().ElementAt(1));
			case "castExpression":
				//case CastExpression
				return CreateCast(topExpressionElement);
			case "creator":
			case "arrayCreator":
				// "new"で始まるジェネリックや配列など
				return CreateNew(topExpressionElement);
			}

			//TODO IMPLEMENT: other cases
			throw new NotImplementedException();
		}

		public static UnifiedBinaryExpression CreateBinaryExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Elements().Count() == 3);
			/*
			 * AST上に<BinaryExpression>という名前の要素は存在しない
			   <multiplicativeExpression>などのいずれかが該当する
			   事前条件は"左辺","演算子","右辺"からなる子要素３つを持つこととする
			*/
			return UnifiedBinaryExpression.Create(CreateExpression(node.NthElement(0)), CreateBinaryOperator(node.NthElement(1)), CreateExpression(node.NthElement(2)));
		}

		public static IUnifiedExpression CreateUnaryExpressionNotPlusMinus(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name().StartsWith("unaryExpressionNotPlusMinus"));
			/*
			 * unaryExpressionNotPlusMinus 
			 *		: '~' unaryExpression
			 *		| '!' unaryExpression
			 *		| castExpression
			 *		| primary (selector)* ( '++' | '--' )?
			 */
			var firstElement = node.FirstElement();
			switch (firstElement.Name()) {
			case "castExpression":
				return CreateCast(firstElement);
			case "primary":
				var result = CreatePrimary(firstElement);

				result = node.Elements("selector")
					.Aggregate(result, CreateSelector);

				var lastNode = node.LastElement();
				if (!lastNode.HasElement()) {
					var ope = lastNode.Value;
					result = UnifiedUnaryExpression.Create(result,
							UnifiedUnaryOperator.Create(ope,
									ope == "++" ? UnifiedUnaryOperatorType.PostIncrementAssign
											: UnifiedUnaryOperatorType.PostDecrementAssign));
				}
				return result;
			}
			return UnifiedUnaryExpression.Create(
					CreateExpression(node.NthElement(1)),
					CreatePrefixUnaryOperator(firstElement.Value));
		}

		public static UnifiedCast CreateCast(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "castExpression");
			/* 
			 * castExpression 
				:   '(' primitiveType ')' unaryExpression
				|   '(' type ')' unaryExpressionNotPlusMinus 
			 */
			var type = node.NthElement(1).Name() == "type"
			           		? CreateTypeOrCreatedName(node.NthElement(1))
			           		: CreatePrimitiveType(node.NthElement(1));
			return UnifiedCast.Create(type, CreateExpression(node.NthElement(3)));
		} 

		public static IUnifiedExpression CreateSelector(IUnifiedExpression prefix, XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "selector");
			/*
			 *  selector  
				:   '.' IDENTIFIER (arguments)? //student.getName()
				|   '.' 'this' //OuterClass.this
				|   '.' 'super' superSuffix //Outer.super()
				|   innerCreator
				|   '[' expression ']' 
			 */
			var secondElement = node.NthElement(1);
			if (secondElement == null)
				return CreateInnerCreator(prefix, node.FirstElement());
			    
			if (secondElement.Name() == "IDENTIFIER") {
				prefix = UnifiedProperty.Create(prefix, secondElement.Value, ".");
				var arguments = node.Element("arguments");
				if (arguments != null) {
					prefix = UnifiedCall.Create(prefix, CreateArguments(arguments));
				}
				return prefix;
			}

			throw new NotImplementedException();
		}

		private static IUnifiedExpression CreateInnerCreator(IUnifiedExpression prefix, XElement node) {
			throw new NotImplementedException();
		}

		public static IUnifiedExpression CreateUnaryExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name().StartsWith("unaryExpression"));
			/*
			 * unaryExpression 
			 *	: '+' unaryExpression
			 *	| '-' unaryExpression
			 *	| '++' unaryExpression
			 *	| '--' unaryExpression
			 *	| unaryExpressionNotPlusMinus
			*/
			var firstElement = node.FirstElement();
			if (firstElement.Name() == "unaryExpressionNotPlusMinus") {
				return CreateUnaryExpressionNotPlusMinus(firstElement);
			}
			return UnifiedUnaryExpression.Create(
					CreateUnaryExpression(node.NthElement(1)),
					CreatePrefixUnaryOperator(firstElement.Value));
		}

		public static IUnifiedExpression CreatePrimary(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primary");
			/*
			 * primary 
			 * :   parExpression            
			 * |   'this' ('.' IDENTIFIER)* (identifierSuffix)?
			 * |   IDENTIFIER ('.' IDENTIFIER)* (identifierSuffix)?
			 * |   'super' superSuffix
			 * |   literal
			 * |   creator
			 * |   primitiveType ('[' ']')* '.' 'class'
			 * |   'void' '.' 'class'
			 */
			var first = node.FirstElement();
			if (first.HasContent("this") || first.Name() == "IDENTIFIER") {
				var variable = UnifiedIdentifier.CreateUnknown(first.Value);
				var prop = first.NextElements("IDENTIFIER")
						.Aggregate((IUnifiedExpression)variable,
								(e, v) => UnifiedProperty.Create(e, v.Value, "."));
				return CreateIdentifierSuffix(node.Element("identifierSuffix"), prop);
			}
			if (first.HasContent("super")) {
				var super = UnifiedIdentifier.CreateUnknown("super");
				return CreateSuperSuffix(node.Element("superSuffix"), super);
			}
			if (first.Name() == "literal") {
				return CreateLiteral(first);
			}
			if (first.Name() == "creator") {
				return CreateCreator(first);
			}
			if (first.Name() == "primitiveType") {
				var type = node.Elements()
						.Take(node.Elements().Count() - 2)
						.Aggregate("", (s, e) => s + e.Value);
				return UnifiedProperty.Create(UnifiedType.Create(type), "class", ".");
			}
			if (first.HasContent("void")) {
				return UnifiedProperty.Create(UnifiedIdentifier.CreateUnknown(first.Value), "class", ".");
			}
			throw new InvalidOperationException();
		}

		private static IUnifiedExpression CreateCreator(XElement first) {
			throw new NotImplementedException();
		}

		public static IUnifiedExpression CreateSuperSuffix(XElement node, IUnifiedExpression prefix) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "superSuffix");
			/*
			 * superSuffix  
			 * :   arguments
			 * |   '.' (typeArguments)? IDENTIFIER (arguments)?
			 */
			if (node.FirstElement().Name == "arguments") {
				return UnifiedCall.Create(prefix, CreateArguments(node.FirstElement()));
			}
			throw new NotImplementedException();
		}

		public static IUnifiedExpression CreateIdentifierSuffix(XElement node, IUnifiedExpression prefix) {
			Contract.Requires(node == null || node.Name() == "identifierSuffix");
			/*
			 * identifierSuffix
			 * :   ('[' ']')+ '.' 'class'	// java.lang.String[].class
			 * |   ('[' expression ']' )+	// strs[10]
			 * |   arguments				// func(1, 2)
			 * |   '.' 'class'				// java.lang.String.class
			 *			// this.<Integer>m(1), super.<Integer>m(1)
			 * |   '.' nonWildcardTypeArguments IDENTIFIER arguments
			 * |   '.' 'this'				// Outer.this
			 * |   '.' 'super' arguments	// new Outer().super();
			 * |   innerCreator				// new Outer().new <Integer> Inner<String>(1);
			 */

			if (node == null) {
				return prefix;
			}
			var second = node.NthElementOrDefault(1);
			if (second != null && second.Name() == "expression") {
				return node.Elements("expression")
						.Select(CreateExpression)
						.Aggregate(prefix, (current, exp) => 
							UnifiedIndexer.Create(current, UnifiedArgumentCollection.Create(UnifiedArgument.Create(exp)))
				);
			}
			if (node.FirstElement().Name() == "arguments") {
				return UnifiedCall.Create(prefix, CreateArguments(node.FirstElement()));
			}
			throw new NotImplementedException();
		}

		private static UnifiedArgumentCollection CreateArguments(XElement node) {
			Contract.Requires(node.Name() == "arguments");
			/*
			 * arguments : '(' (expressionList)? ')'
			 */

			var expressionListNode = node.Element("expressionList");
			if (expressionListNode == null)
				return UnifiedArgumentCollection.Create();

			var args = CreateExpressionList(expressionListNode)
					.ToList()
					.Select(e => {
						e.Remove();
						return UnifiedArgument.Create(e);
					});
			return UnifiedArgumentCollection.Create(args);
		}

		public static UnifiedExpressionCollection CreateExpressionList(XElement node) {
			Contract.Requires(node.Name() == "expressionList");
			/*
			 * expressionList : expression (',' expression )* ;
			 */

			var expressions = node.Elements("expression")
					.Select(CreateExpression);
			return UnifiedExpressionCollection.Create(expressions);
		}


		/* expressionList
		 * :   expression (',' expression)*
		 */

		/*
		 * innerCreator  
		 * :   '.' 'new' (nonWildcardTypeArguments)? IDENTIFIER (typeArguments)? classCreatorRest
		 */


		public static IUnifiedExpression CreateNew(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name().ToLower().EndsWith("creator"));
			/* 
			 * creator 
				:   'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest
				|   'new' classOrInterfaceType classCreatorRest
				|   arrayCreator

			   arrayCreator 
				:   'new' createdName
					'[' ']'
					( '[' ']' )*
					arrayInitializer
			    |   'new' createdName
					'[' expression ']'
					( '[' expression ']' )*
					( '[' ']' )*
			*/

			if(node.Name() == "creator") {
				if(node.Element("classCreatorRest").Element("arguments").Element("expressionList") == null)
					return UnifiedNew.Create(CreateClassOrInterfaceType(node.Element("classOrInterfaceType")), 
						UnifiedArgumentCollection.Create());
	
				return UnifiedNew.Create(CreateClassOrInterfaceType(node.Element("classOrInterfaceType")),
					UnifiedArgumentCollection.Create(node.Element("classCreatorRest")
							.Element("arguments")
							.Element("expressionList")
							.Elements("expression")
							.Select(CreateArgument))
							);
			}
			else { //case "arrayCreator"
				UnifiedExpressionCollection initVal = null;
				UnifiedArgumentCollection args = null;
				if(node.HasContent("arrayInitializer")) {
					initVal = (UnifiedExpressionCollection)node.Element("arrayInitializer")
					                                       		.Elements("variableInitializer")
					                                       		.Select(e => CreateExpression(e.Element("expression")));
				}
				else {
					args = UnifiedArgumentCollection.Create(node.Elements("expression").Select(CreateArgument));

				}
				return UnifiedArrayNew.Create(CreateTypeOrCreatedName(node.Element("createdName")), args, initVal); 
			}
		}

		public static UnifiedIdentifier CreateVariable(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primary" || node.Name() == "literal");
			return UnifiedIdentifier.CreateUnknown(node.Value);
		}

		public static UnifiedLiteral CreateLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primary" || node.Name() == "literal");

			int i;
			if( Int32.TryParse(node.Value, NumberStyles.Any, null, out i)) {
				return UnifiedIntegerLiteral.Create(i);
			}

			decimal d;
			if (Decimal.TryParse(node.Value, NumberStyles.Any, null, out d)) {
				return UnifiedDecimalLiteral.Create(d);
			}

			var regex = new Regex(@"^""[a-zA-Z0-9_]*""$");
			if(regex.IsMatch(node.Value)) {
				var r = new Regex(@"[a-zA-Z_]{1}[a-zA-Z0-9_]*");
				var match = r.Match(node.Value);
				return UnifiedStringLiteral.Create(match.Value);
			}

			//TODO IMPLEMENT: other literal cases
			throw new NotImplementedException();
		}

		#endregion

		#region Operator

		public static UnifiedBinaryOperator CreateBinaryOperator(XElement node) {
			Contract.Requires(node != null);
			//TODO implement more OperatorType cases
			var name = node.Value;
			UnifiedBinaryOperatorType type;

			switch (name) {
			//Arithmetic
				case "+": type = UnifiedBinaryOperatorType.Add; break;
				case "-": type = UnifiedBinaryOperatorType.Subtract; break;
				case "*": type = UnifiedBinaryOperatorType.Multiply; break;
				case "/": type = UnifiedBinaryOperatorType.Divide; break;
				case "%": type = UnifiedBinaryOperatorType.Modulo; break;
			//Shift
				case "<<": type = UnifiedBinaryOperatorType.ArithmeticLeftShift; break;
				case ">>": type = UnifiedBinaryOperatorType.ArithmeticRightShift; break;
			//Comparison
				case ">": type = UnifiedBinaryOperatorType.GreaterThan; break;
				case ">=": type = UnifiedBinaryOperatorType.GreaterThanOrEqual; break;
				case "<": type = UnifiedBinaryOperatorType.LessThan; break;
				case "<=": type = UnifiedBinaryOperatorType.LessThanOrEqual; break;
				case "==": type = UnifiedBinaryOperatorType.Equal; break;
				case "!=": type = UnifiedBinaryOperatorType.NotEqual; break;
			//Logocal
				case "&&": type = UnifiedBinaryOperatorType.AndAlso; break;
				case "||": type = UnifiedBinaryOperatorType.OrElse; break;
			//Bit
				case "&": type = UnifiedBinaryOperatorType.And; break;
				case "|": type = UnifiedBinaryOperatorType.Or; break;
				case "^": type = UnifiedBinaryOperatorType.ExclusiveOr; break;
			//Assignment
				case "=": type = UnifiedBinaryOperatorType.Assign; break;
				case "+=": type = UnifiedBinaryOperatorType.AddAssign; break;
				case "-=": type = UnifiedBinaryOperatorType.SubtractAssign; break;
				case "*=": type = UnifiedBinaryOperatorType.MultiplyAssign; break;
				case "/=": type = UnifiedBinaryOperatorType.DivideAssign; break;
				case "%=": type = UnifiedBinaryOperatorType.ModuloAssign; break;
				default:
					throw new InvalidOperationException();
			}
			return UnifiedBinaryOperator.Create(name, type);
		}

		public static UnifiedUnaryOperator CreatePrefixUnaryOperator(string name)
		{
			Contract.Requires(name != null);
			UnifiedUnaryOperatorType type;
			switch (name) {
			case "+":
				type = UnifiedUnaryOperatorType.UnaryPlus;
				break;
			case "-":
				type = UnifiedUnaryOperatorType.Negate;
				break;
			case "++":
				type = UnifiedUnaryOperatorType.PreIncrementAssign;
				break;
			case "--":
				type = UnifiedUnaryOperatorType.PreDecrementAssign;
				break;
			case "~":
				type = UnifiedUnaryOperatorType.OnesComplement;
				break;
			case "!":
				type = UnifiedUnaryOperatorType.Not;
				break;
			default:
				throw new InvalidOperationException();
			}
			return UnifiedUnaryOperator.Create(name, type);
		}

		#endregion

		#region Statement

		public static IUnifiedExpression CreateStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			/*
			 * statement 
			 * :   block
			 * |   ('assert') expression (':' expression)? ';'
			 * |   'assert'  expression (':' expression)? ';'            
			 * |   'if' parExpression statement ('else' statement)?          
			 * |   forstatement
			 * |   'while' parExpression statement
			 * |   'do' statement 'while' parExpression ';'
			 * |   trystatement
			 * |   'switch' parExpression '{' switchBlockStatementGroups '}'
			 * |   'synchronized' parExpression block
			 * |   'return' (expression )? ';'
			 * |   'throw' expression ';'
			 * |   'break' (IDENTIFIER )? ';'
			 * |   'continue' (IDENTIFIER)? ';'
			 * |   expression  ';'     
			 * |   IDENTIFIER ':' statement
			 * |   ';'
			 * ;*/
			var element = node.FirstElement();

			switch (element.Name()) {
				case "block": return CreateBlock(element);
				case "IF": return CreateIf(node);
				case "forstatement": return CreateForstatement(element);
				case "WHILE": return CreateWhile(node);
				case "DO": return CreateDo(node);
				case "SWITCH": return CreateSwitch(node);
				case "RETURN": return CreateReturn(node);	
				case "BREAK": return CreateBreak(node);
				case "expression": return CreateExpression(element);
				default: throw new NotImplementedException();
			}
		}

		public static UnifiedBlock CreateBlock(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "block");
			/*
			 * block : '{' (blockStatement )* '}'
			 */

			var list = new List<IUnifiedExpression>();

			foreach (var e in node.Elements()) {
				if (e.Name() == "blockStatement") {
					list.Add(CreateBlockStatement(e));
				}
			}
			return UnifiedBlock.Create(list);
			
		}
		
		public static IUnifiedExpression CreateBlockStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "blockStatement");
			/*  blockStatement
			 * :   localVariableDeclarationStatement
			 * |   classOrInterfaceDeclaration
			 * |   statement
			 */
			var e = node.Elements().First();
			switch(e.Name()) {
				case "statement":
					return CreateStatement(e);
				case "localVariableDeclarationStatement":
					return CreateLocalVariableDeclarationStatement(e);
				case "classOrInterfaceDeclaration":
					throw new NotImplementedException();
				default:
					throw new InvalidOperationException();
			}
		}

		public static UnifiedIf CreateIf(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.Elements().First().Name() == "IF");
			/*  'if' parExpression statement ('else' statement)? */
			var trueBody = UnifiedBlock.Create(new IUnifiedExpression[] {
				CreateStatement(node.Element("statement")),
			});

			UnifiedBlock falseBody = null;
			if (node.Elements("statement").Count() == 2) {
				var falseNode = node.Elements("statement").ElementAt(1);
				falseBody = UnifiedBlock.Create(new IUnifiedExpression[] {
						CreateStatement(falseNode),
				});
			}
			return UnifiedIf.Create(CreateExpression(node
					.Element("parExpression")
					.Element("expression")),
					trueBody, falseBody);
		}

		public static UnifiedWhile CreateWhile(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.Elements().First().Name() == "WHILE");
			/* 'while' parExpression statement */
			return UnifiedWhile.Create(
				UnifiedBlock.Create(new IUnifiedExpression[] {
					CreateStatement(node.Element("statement"))
				}),
				CreateExpression(node.Element("parExpression").Element("expression"))
			);
		}

		public static UnifiedDoWhile CreateDo(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.Elements().First().Name() == "DO");
			/* 'do' statement 'while' parExpression ';' */
			return UnifiedDoWhile.Create(
				UnifiedBlock.Create(new IUnifiedExpression[] {
						CreateStatement(node.Element("statement"))
				}),
				CreateExpression(node.Element("parExpression").Element("expression"))
			);
		}

		public static IUnifiedExpression CreateForstatement(XElement forstatement) {
			Contract.Requires(forstatement != null);
			Contract.Requires(forstatement.Name() == "forstatement");
			/*	forstatement :   
			 * // enhanced for loop
			 *     'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement
			 * // normal for loop
			 * |   'for' '(' (forInit)? ';' (expression)? ';' (expressionList)? ')' statement
			 * ; */
			if (forstatement.NthElement(2).Name() == "variableModifiers") {
				return UnifiedForeach.Create(
					UnifiedVariableDefinition.Create(
						CreateTypeOrCreatedName(forstatement.Element("type")),
						CreateVariableModifiers(forstatement.Element("variableModifiers")),
						null,
						forstatement.Element("IDENTIFIER").Value
					),
					CreateExpression(forstatement.Element("expression")),
					UnifiedBlock.Create(
						CreateStatement(forstatement.Element("statement"))
					)
				);
			} else {
				var forInit = forstatement.Element("forInit");
				var initializer = forInit != null ? CreateForInit(forInit) : null;

				var expression = forstatement.Element("expression");
				var condition = expression != null ? CreateExpression(expression) : null;

				var expressionList = forstatement.Element("expressionList");
				var step = expressionList != null
							? CreateExpressionList(expressionList) : null;

				var body = CreateStatement(forstatement.Element("statement"));
				return UnifiedFor.Create(
					initializer,
					condition,
					step,
					UnifiedBlock.Create(body)
				);
			}
		}

		public static UnifiedSwitch CreateSwitch(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("switch"));
			/* 'switch' parExpression '{' switchBlockStatementGroups '}' */
			return UnifiedSwitch.Create(CreateExpression(node.Element("parExpression").Element("expression")),
				CreateCaseCollection(node.Element("switchBlockStatementGroups")));
		}

		public static UnifiedCaseCollection CreateCaseCollection(XElement node) {
			//Top node is <switchBlockStatementGroups>.
			return UnifiedCaseCollection.Create(node.Elements("switchBlockStatementGroup").Select(CreateCase));
		}

		public static UnifiedCase CreateCase(XElement node) {
			//Top node is <switchBlockStatementGroup>.
			var cond = node.Element("switchLabel").Element("expression");
			var body = UnifiedBlock.Create(new IUnifiedExpression[] {
				CreateBlockStatement(node.Element("blockStatement"))
			});
			//var body = CreateBlock(node);
			if(cond == null) {
				return UnifiedCase.Create(null, body);
			}
			return UnifiedCase.Create(CreateExpression(cond), body);
		}

		public static UnifiedJump CreateBreak(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("break"));
			/* 'break' (IDENTIFIER )? ';' */
			if (node.Elements().Count() > 2)
				throw new NotImplementedException();
			return UnifiedJump.CreateBreak();
		}

		private static IUnifiedExpression CreateForInit(XElement node) {
			Contract.Requires(node.Name() == "forInit");
		/* forInit : localVariableDeclaration | expressionList ;
		 */
			switch(node.FirstElement().Name()) {
				case "localVariableDeclaration":
					return CreateLocalVariableDeclarationOrFieldDeclaration(node.FirstElement());
				case "expressionList":
				return CreateExpressionList(node.FirstElement());
			}
			throw new InvalidOperationException();
		}

		private static UnifiedModifierCollection CreateVariableModifiers(XElement xElement) {
			/*
			 * variableModifiers : ( 'final' | annotation )* ;
			 */
			if (xElement.Elements().Count() == 0) return UnifiedModifierCollection.Create();
			else throw new NotImplementedException();
		}

		public static UnifiedJump CreateReturn(XElement node) {
			Contract.Requires(node != null);
			IUnifiedExpression value = null;
			var i = node.Elements().Count();
			if (node.Elements().Count() == 3) {
				value = CreateExpression(node.Element("expression"));
			}
			return UnifiedJump.CreateReturn( value);
		}

		#endregion

		#region Function

		/*
		 * methodDeclaration
		 * :
		 * // Constructor
		 *   modifiers (typeParameters)? IDENTIFIER formalParameters ('throws' qualifiedNameList)? '{' (explicitConstructorInvocation)? (blockStatement)* '}'
		 * // Method
		 * | modifiers (typeParameters)? (type | 'void') IDENTIFIER formalParameters ('[' ']')* ('throws' qualifiedNameList)? (block | ';');
		 * 
		 */
		public static IUnifiedExpression CreateDefineFunction(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "methodDeclaration");

			if(node.Element("type") == null && node.Element("VOID") == null) { //case Constructor
				return UnifiedConstructorDefinition.Create(
						UnifiedBlock.Create(new IUnifiedExpression[] {
								CreateBlockStatement(node.Element("blockStatement"))
						}),
						CreateModifierCollection(node),
						CreateFormalParameters(node.Element("formalParameters"))
				);
			}
			//if (node.Element("IDENTIFIER").PreviousElement().Name() == "")
			return UnifiedFunctionDefinition.Create(
				node.Element("IDENTIFIER").Value,
				CreateTypeOrCreatedName(node.Element("type")),
				CreateModifierCollection(node),
				CreateFormalParameters(node.Element("formalParameters")),
				//TODO IMPLEMENT:
				CreateBlock(node.Element("block"))
			);
		}

		public static UnifiedModifier CreateVariableModifier(XElement node) {
			Contract.Requires(node != null);
			return UnifiedModifier.Create(node.Value);
		}

		public static UnifiedModifier CreateModifier(XElement node) {
			Contract.Requires(node != null);
			return UnifiedModifier.Create(node.Value);
		}

		public static UnifiedModifierCollection CreateModifierCollection(XElement node) {
			Contract.Requires(node != null);
			return UnifiedModifierCollection.Create(node
				.Element("modifiers")
				.Elements()
				.Select(CreateModifier));
		}

		public static UnifiedType CreateTypeOrCreatedName(XElement node) {
			Contract.Requires(node == null || node.Name() == "type" || node.Name() == "createdName");
			/* 
			 * type 
				:   classOrInterfaceType ('[' ']')*
				|   primitiveType ('[' ']')*
			*/

			if(node == null)
				return UnifiedType.Create("void");

			var firstNode = node.FirstElement();
			switch (firstNode.Name()) {
				case "classOrInterfaceType":
					return CreateClassOrInterfaceType(firstNode);
				case "primitiveType":
					return CreatePrimitiveType(firstNode);
				default:
					throw new InvalidOperationException();
			}
		}

		public static UnifiedType CreateClassOrInterfaceType(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classOrInterfaceType");
			/* 
			 * classOrInterfaceType 
				:   IDENTIFIER (typeArguments)? ('.' IDENTIFIER (typeArguments)? )*
			  
			   typeArguments 
			 * :   '<' typeArgument (',' typeArgument )* '>'
			 */
			//TODO 末尾修飾子が付く場合にはどのように名前を与えるか
			//-> とりあえず、CreateClassOrInterfaceType()の中で親の値に遡って代入する

			var name = node.Parent.Name() == "type" ?  
				node.Parent.Value : node.Element("IDENTIFIER").Value;
			if(node.HasElement("typeArguments")) {
				return UnifiedType.Create(name, UnifiedTypeParameterCollection.Create(
						node.Element("typeArguments")
						.Elements("typeArgument")
						.Select(CreatTypeParameter)));
			}
			return UnifiedType.Create(name);
			//TODO ('.' IDENTIFIER (typeArguments)? )*はどう扱えばいいのか
		}

		public static UnifiedType CreatePrimitiveType(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primitiveType");
			/*
			 * primitiveType  
				:   'boolean' | 'char' | 'byte' | 'short' | 'int' | 'long' | 'float' | 'double' 
			 */
			return UnifiedType.Create(node.Value);
		}

		public static UnifiedTypeParameter CreatTypeParameter(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeArgument");
			/* 
			 * typeArgument 
				:   type
				|   '?' ( ('extends'|'super' ) type )?
			 */
			if(node.FirstElement().Name() == "type") {
				return UnifiedTypeParameter.Create(CreateTypeOrCreatedName(node.Element("type")),
						null);
			}
			throw new NotImplementedException();
			//TODO ?はどのように扱うのか
			var modifier = node.NthElement(1) != null ? UnifiedModifierCollection.Create() : null;
			var type = node.NthElement(2) != null ? CreateTypeOrCreatedName(node.Element("type")) : null;
			return UnifiedTypeParameter.Create(type, modifier);
		}

		public static UnifiedParameterCollection CreateFormalParameters(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameters");
			var element = node.Element("formalParameterDecls");
			if (element == null)
				return UnifiedParameterCollection.Create();

			return UnifiedParameterCollection.Create(element
				.Elements()
				.Select(e => {
					if (e.Name() == "normalParameterDecl")
						return CreateNormalParameterDecl(e);
					if (e.Name() == "ellipsisParameterDecl")
						return CreateEllipsisParameterDecl(e);
					return null;
				})
				.Where(e => e != null));
		}

		public static UnifiedParameter CreateNormalParameterDecl(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalParameterDecl");
			/* 
			 * normalParameterDecl 
				:   variableModifiers type IDENTIFIER ('[' ']')* 
			 */
			return UnifiedParameter.Create(
				node.Element("IDENTIFIER").Value,
				CreateTypeOrCreatedName(node.Element("type")),
				UnifiedModifierCollection.Create(node
					.Element("variableModifiers")
					.Elements()
					.Select(CreateVariableModifier)));
		}

		public static UnifiedParameter CreateEllipsisParameterDecl(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "ellipsisParameterDecl");
			throw new NotImplementedException();
		}

		public static UnifiedArgument CreateArgument(XElement node) {
			Contract.Requires(node != null);
			return UnifiedArgument.Create(CreateExpression(node));
		}

		public static UnifiedArgumentCollection CreateArgumentCollection(XElement node) {
			Contract.Requires(node != null);
			var element = node
				.Element("identifierSuffix")
				.Element("arguments")
				.Element("expressionList")
				.Elements()
				.Select(CreateArgument);
			return UnifiedArgumentCollection.Create(element);
		}

		#endregion

		public static UnifiedVariableDefinition CreateLocalVariableDeclarationStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "localVariableDeclarationStatement");
			return CreateLocalVariableDeclarationOrFieldDeclaration(node.Element("localVariableDeclaration"));

		}
		public static UnifiedVariableDefinition CreateLocalVariableDeclarationOrFieldDeclaration(XElement node) {
			Contract.Requires(node.Name() == "localVariableDeclaration" || node.Name() == "fieldDeclaration");
			/* localVariableDeclaration 
			 *   :   variableModifiers type variableDeclarator (',' variableDeclarator )* ;
			 */
			
			/*
			 * fieldDeclaration 
			 *   :   modifiers type variableDeclarator (',' variableDeclarator )* ';' 
			 */

			var init =
					node.Element("variableDeclarator").Element("variableInitializer") != null
							? CreateExpression(node.Element("variableDeclarator")
							.Element("variableInitializer")
							.Element("expression")) : null;
			return UnifiedVariableDefinition.Create(
					/*InitialValue = CreateExpression(
						node.Element("variableDeclarator")
						.Element("variableInitializer")
						.Element("expression")), */
					CreateTypeOrCreatedName(node.Element("type")),
					UnifiedModifierCollection.Create(
						node.ElementAt(0)
						.Elements()
						.Select(CreateVariableModifier)),
					init,
					node.Element("variableDeclarator").Element("IDENTIFIER").Value
			);
		}

		public static UnifiedBooleanLiteral CreateBooleanLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Elements().First().Value == "true" || node.Elements().First().Value == "false");
			var tokenNode = node.FirstElement();
			return UnifiedBooleanLiteral.Create(tokenNode.Value == "true");
		}

		public static UnifiedClassDefinition CreateClassDeclaration(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classDeclaration");
			/*
			 * classDeclaration 
			    :   normalClassDeclaration
				|   enumDeclaration 
			 */
			if(node.HasElement("normalClassDeclaration")) {
						//var modifiers = CreateModifierCollection(node);
				var name = node
						.Element("normalClassDeclaration")
						.Element("IDENTIFIER")
						.Value;
				var body = CreateClassBody(node
						.Element("normalClassDeclaration")
						.Element("classBody"));
				return UnifiedClassDefinition.CreateClass(name, body);
			}
			throw new NotImplementedException();
		}

		public static UnifiedBlock CreateClassBody(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classBody");
			/*
			 * classBody 
			    :   '{' (classBodyDeclaration)* '}' 
			 */
			return UnifiedBlock.Create(node
				.Elements("classBodyDeclaration")
				.Select(CreateClassBodyDeclaration).ToList());
		}

		public static IUnifiedExpression CreateClassBodyDeclaration(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classBodyDeclaration");
			/*
			 * memberDecl 
				:    fieldDeclaration
				|    methodDeclaration
				|    classDeclaration
				|    interfaceDeclaration 
			 */
			var memType = node.Element("memberDecl").FirstElement();
			switch (memType.Name()) {
				case "fieldDeclaration":  return CreateLocalVariableDeclarationOrFieldDeclaration(memType);
				case "methodDeclaration": return CreateDefineFunction(memType);
				case "classDeclaration":  return CreateClassDeclaration(memType);
				default:
					throw new NotImplementedException();
			}
		}

		public static UnifiedProgram CreateProgram(XElement node) {
			Contract.Requires(node != null);
			var model = UnifiedProgram.Create(
				CreateClassDeclaration(node
					.Element("typeDeclaration")
					.Element("classOrInterfaceDeclaration")
					.Element("classDeclaration"))
			);
			model.Normalize();
			return model;
		}

		public static UnifiedProgram CreateModel(string source) {
			Contract.Requires(source != null);
			var ast = JavaXmlGenerator.Instance.Generate(source);
			return CreateProgram(ast);
		}
	}
}