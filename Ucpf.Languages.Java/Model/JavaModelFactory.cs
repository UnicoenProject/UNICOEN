using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Threading;
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
			String[] binaryOperator = { "+", "-", "*", "/", "%", "<", ">" };

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
				if (System.Text.RegularExpressions.Regex.IsMatch(topExpressionElement.Value, @"[a-zA-Z]{1}[a-zA-Z0-9]*")) {
					return CreateVariable(topExpressionElement);
				}
				//other cases
				return CreateLiteral(topExpressionElement);
			}

			//case BinaryExpression
			var binaryOperatorString = topExpressionElement.Elements().ElementAt(1).Value;
			if (binaryOperator.Contains(binaryOperatorString)) {
				return CreateBinaryExpression(topExpressionElement);
			}

			//case UnaryExpression
			if (topExpressionElement.Name.LocalName.StartsWith("unaryExpression")) {
				return CreateUnaryExpression(topExpressionElement);
			}

			switch (topExpressionElement.Name.LocalName) {
				case "primary":
					//case CallExpression
					return CreatePrimary(topExpressionElement);
				case "parExpression":
					// expression を () で囲ったような場合
					return CreateExpression(topExpressionElement.Elements().ElementAt(1));
				case "creator":
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
			return new UnifiedBinaryExpression {
				LeftHandSide = CreateExpression(node.NthElement(0)),
				Operator = CreateBinaryOperator(node.NthElement(1)),
				RightHandSide = CreateExpression(node.NthElement(2))
			};
		}

		public static UnifiedUnaryExpression CreateUnaryExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name().StartsWith("unaryExpression"));
			/*
			 * unaryExpression 
			    : '+' unaryExpression | '-' unaryExpression
			    | '++' unaryExpression | '--' unaryExpression
			    |   unaryExpressionNotPlusMinus ;

				unaryExpressionNotPlusMinus 
				: '~' unaryExpression | '!' unaryExpression | castExpression
			    | primary (selector)* ( '++' | '--' )? ;
			*/
			String[] unaryOperator = { "+", "-", "++", "--", "~", "!" };
			var firstElement = node.NthElement(0);
			var secondElement = node.NthElement(1);
			if (unaryOperator.Contains(firstElement.Value)) {
				return new UnifiedUnaryExpression {
					Operator = CreateUnaryOperator(firstElement),
					Operand = CreateExpression(secondElement)
				};
			} else if (unaryOperator.Contains(secondElement.Value)) {
				UnifiedUnaryOperatorType operatorType;
				switch (secondElement.Value) {
					case "++":
					operatorType = UnifiedUnaryOperatorType.PostIncrementAssign;
					break;
					case "--":
					operatorType = UnifiedUnaryOperatorType.PostDecrementAssign;
					break;
					default:
						throw new InvalidOperationException();
				}
				return new UnifiedUnaryExpression {
					Operator = new UnifiedUnaryOperator(secondElement.Value, operatorType),
					Operand = CreateExpression(firstElement)
				};
			} else {
				//TODO: 構文に沿ったように実装する
				throw new NotImplementedException();
			}
		}

		public static UnifiedExpression CreatePrimary(XElement node) {
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
				var variable = UnifiedVariable.Create(first.Value);
				var prop = first.NextElements("IDENTIFIER")
						.Aggregate((UnifiedExpression)variable,
								(e, v) => new UnifiedProperty {
										Owner = e,
										Name = v.Value,
								});
				return CreateIdentifierSuffix(node.Element("identifierSuffix"), prop);
			}
			if (first.HasContent("super")) {
				var super = UnifiedVariable.Create("super");
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
				return new UnifiedProperty {
					Owner = UnifiedType.Create(type),
					Name = "class",
				};
			}
			if (first.HasContent("void")) {
				return new UnifiedProperty {
						Owner = UnifiedVariable.Create(first.Value),
						Name = "class",
				};
			}
		}

		private static UnifiedExpression CreateCreator(XElement first) {
			throw new NotImplementedException();
		}

		/*
		 * superSuffix  
		 * :   arguments
		 * |   '.' (typeArguments)? IDENTIFIER (arguments)?
		 */
		public static UnifiedExpression CreateSuperSuffix(XElement node, UnifiedExpression prefix) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "superSuffix");
			throw new NotImplementedException();
		}

		/*
		 * identifierSuffix
		 * :   ('[' ']')+ '.' 'class'	// java.lang.String[].class
		 * |   ('[' expression ']' )+	// strs[10]
		 * |   arguments				// func(1, 2)
		 * |   '.' 'class'				// java.lang.String.class
		 * // this.<Integer>m(1), super.<Integer>m(1)
		 * |   '.' nonWildcardTypeArguments IDENTIFIER arguments
		 * |   '.' 'this'				// Outer.this
		 * |   '.' 'super' arguments	// new Outer().super();
		 * |   innerCreator				// new Outer().new <Integer> Inner<String>(1);
		 */
		public static UnifiedExpression CreateIdentifierSuffix(XElement node, UnifiedExpression prefix) {
			Contract.Requires(node == null || node.Name() == "identifierSuffix");
			if (node == null) {
				return prefix;
			}
			throw new NotImplementedException();
		}

		/*
		 * arguments 
		 * :   '(' (expressionList)? ')'
		 */

		/* expressionList
		 * :   expression (',' expression)*
		 */

		/*
		 * innerCreator  
		 * :   '.' 'new' (nonWildcardTypeArguments)? IDENTIFIER (typeArguments)? classCreatorRest
		 */


		public static UnifiedNew CreateNew(XElement node) {
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

			//とりあえずCreateNewGenericType()向けに実装したので、
			//インスタンス生成の際など、明らかに他に何かをnewする機会はあると思われる
			return new UnifiedNew {
					Arguments = new UnifiedArgumentCollection(),
					Type = CreateClassOrInterfaceType(node.Element("classOrInterfaceType"))
			};
		}

		public static UnifiedVariable CreateVariable(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primary");
			//Contract.Requires(node.Name() == "IDENTIFIER" || node.Name() == "TOKEN");
			return new UnifiedVariable {
				Name = node.Value
			};
		}

		public static UnifiedLiteral CreateLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primary" || node.Name() == "literal");
			//Contract.Requires(node.Name() == "IDENTIFIER" || node.Name() == "TOKEN");
			int i;
			if( Int32.TryParse(node.Value, NumberStyles.Any, null, out i)) {
				return new UnifiedIntegerLiteral {
					Value = i
				};
			}

			decimal d;
			if (Decimal.TryParse(node.Value, NumberStyles.Any, null, out d)) {
				return new UnifiedDecimalLiteral() {
					Value = d
				};
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
			return new UnifiedBinaryOperator(name, type);
		}

		public static UnifiedUnaryOperator CreateUnaryOperator(XElement node)
		{
			Contract.Requires(node != null);
			//TODO implement more OperatorType cases
			var name = node.Value;
			UnifiedUnaryOperatorType type;

			switch (name)
			{
				//Arithmetic
				case "+":
				type = UnifiedUnaryOperatorType.UnaryPlus; break;
				case "-":
				type = UnifiedUnaryOperatorType.Negate; break;
				default:
					throw new NotImplementedException();
					throw new InvalidOperationException();
			}
			return new UnifiedUnaryOperator(name, type);
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

			switch (element.Name.LocalName) {
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
			 * block : '{' (blockStatement )* '}' ;
			 */

			var block = node;
			if (block == null)
				return new UnifiedBlock();

			var list = new List<IUnifiedExpression>();

			foreach (var e in block.Elements()) {
				if (e.Name.LocalName == "blockStatement") {
					list.Add(CreateBlockStatement(e));
				}
			}

			return new UnifiedBlock(
				list
				//					block.Elements("statement")
				//					.Select(CreateStatement)
				//					.ToList()
			);
			
		}
		
		public static UnifiedExpression CreateBlockStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "blockStatement");
			/*  blockStatement :
			 * localVariableDeclarationStatement
			 * |   classOrInterfaceDeclaration
			 * |   statement
			 * ;
			 */
			var e = node.Elements().First();
			switch(e.Name.LocalName) {
				case "statement":
					return CreateStatement(e);
				case "localVariableDeclarationStatement":
					return CreateVariableDefinition(e);
				case "classOrInterfaceDeclaration":
					throw new NotImplementedException();
				default:
					throw new InvalidOperationException();
			}
		}

		public static UnifiedIf CreateIf(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "statement");
			Contract.Requires(node.Elements().First().Name.LocalName == "IF");
			/*  'if' parExpression statement ('else' statement)? */
			var trueBody = new UnifiedBlock {
				CreateStatement(node.Element("statement")),
			};

			UnifiedBlock falseBody = null;
			if (node.Elements("statement").Count() == 2) {
				var falseNode = node.Elements("statement").ElementAt(1);
				falseBody = new UnifiedBlock {
						CreateStatement(falseNode),
				};
			}
			return new UnifiedIf {
				Condition = CreateExpression(node
					.Element("parExpression")
					.Element("expression")),
				TrueBody = trueBody,
				FalseBody = falseBody
			};
		}

		public static UnifiedWhile CreateWhile(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "statement");
			Contract.Requires(node.Elements().First().Name.LocalName == "WHILE");
			/* 'while' parExpression statement */
			return new UnifiedWhile {
				Condition =
					CreateExpression(node.Element("parExpression").Element("expression")),
				Body = new UnifiedBlock {
					CreateStatement(node.Element("statement"))
				}
			};
		}

		public static UnifiedDoWhile CreateDo(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "statement");
			Contract.Requires(node.Elements().First().Name.LocalName == "DO");
			/* 'do' statement 'while' parExpression ';' */
			return new UnifiedDoWhile {
				Body = new UnifiedBlock {
						CreateStatement(node.Element("statement"))
				},
				Condition = 
					CreateExpression(node.Element("parExpression").Element("expression"))
			};
		}

		public static UnifiedExpression CreateForstatement(XElement forstatement)
		{
			Contract.Requires(forstatement != null);
			Contract.Requires(forstatement.Name.LocalName == "forstatement");
			/*	forstatement :   
			 * // enhanced for loop
			 *     'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement
			 * // normal for loop
			 * |   'for' '(' (forInit)? ';' (expression)? ';' (expressionList)? ')' statement
			 * ; */
			if (forstatement.NthElement(2).Name.LocalName == "variableModifiers") {
				//TODO
				throw new NotImplementedException();
			} else {
				var forInit = forstatement.Element("forInit");
				var initializer = forInit != null ? CreateForInit(forInit) : null;

				var expression = forstatement.Element("expression");
				var condition = expression != null ? CreateExpression(expression) : null;

				var expressionList = forstatement.Element("expressionList");
				var step = expressionList != null
							? CreateExpressionList(expressionList) : null;

				var body = CreateStatement(forstatement.Element("statement"));
				return new UnifiedFor {
					Initializer = initializer,
					Condition = condition,
					Step = step,
					Body = new UnifiedBlock{ body }
				};
			}
		}

		public static UnifiedSwitch CreateSwitch(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "statement");
			Contract.Requires(node.Elements().First().Name.LocalName == "SWITCH");
			/* 'switch' parExpression '{' switchBlockStatementGroups '}' */
			return new UnifiedSwitch {
					Cases = CreateCaseCollection(node.Element("switchBlockStatementGroups")),
					Value = CreateExpression(node.Element("parExpression").Element("expression"))
			};
		}

		public static UnifiedCaseCollection CreateCaseCollection(XElement node) {
			//Top node is <switchBlockStatementGroups>.
			return new UnifiedCaseCollection(node.Elements("switchBlockStatementGroup").Select(CreateCase));
		}

		public static UnifiedCase CreateCase(XElement node) {
			//Top node is <switchBlockStatementGroup>.
			var cond = node.Element("switchLabel").Element("expression");
			var body = new UnifiedBlock {
				CreateBlockStatement(node.Element("blockStatement"))
			};
			//var body = CreateBlock(node);
			if(cond == null) {
				return new UnifiedCase {
					Condition = null,
					Body = body

				};
			}
			return new UnifiedCase {
					Condition = CreateExpression(cond),
					Body = body
			};
		}

		public static UnifiedBreak CreateBreak(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name.LocalName == "statement");
			Contract.Requires(node.Elements().First().Name.LocalName == "break");
			/* 'break' (IDENTIFIER )? ';' */
			if (node.Elements().Count() > 2) throw new NotImplementedException();
			return new UnifiedBreak();
		}

		private static IUnifiedExpression CreateForInit(XElement node) {
			Contract.Requires(node.Name.LocalName == "forInit");
		/* forInit : localVariableDeclaration | expressionList ;
		 */
			switch(node.FirstElement().Name.LocalName) {
				case "localVariableDeclaration":
					return CreateLocalVariableDeclaration(node.FirstElement());
				case "expressionList":
				return CreateExpressionList(node.FirstElement());
			}
			throw new InvalidOperationException();
		}


		private static UnifiedModifierCollection CreateVariableModifiers(XElement xElement) {
			/*
			 * variableModifiers : ( 'final' | annotation )* ;
			 */
			if (xElement.Elements().Count() == 0) return null;
			else throw new NotImplementedException();
		}

		public static IUnifiedExpression CreateExpressionList(XElement node) {
			/*
			 * expressionList : expression (',' expression )* ;
			 */
			return CreateExpression(node.Element("expression"));
			//TODO: 構文に沿ったように実装する
		}

		public static UnifiedReturn CreateReturn(XElement node) {
			Contract.Requires(node != null);
			IUnifiedExpression value = null;
			var i = node.Elements().Count();
			if (node.Elements().Count() == 3) {
				value = CreateExpression(node.Element("expression"));
			}
			return new UnifiedReturn {
				Value = value
			};
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
		public static UnifiedFunctionDefinition CreateDefineFunction(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "methodDeclaration");
			//if (node.Element("IDENTIFIER").PreviousElement().Name() == "")
			return new UnifiedFunctionDefinition {
				Modifiers  = CreateModifierCollection(node),
				Type       = CreateType(node),
				Name       = node.Element("IDENTIFIER").Value,
				Parameters = CreateFormalParameters(node.Element("formalParameters")),
				//TODO IMPLEMENT:
				Body       = CreateBlock(node.Element("block"))
			};
		}

		public static UnifiedModifier CreateVariableModifier(XElement node) {
			Contract.Requires(node != null);
			return new UnifiedModifier {
				Name = node.Value
			};
		}

		public static UnifiedModifier CreateModifier(XElement node) {
			Contract.Requires(node != null);
			return new UnifiedModifier {
				Name = node.Value
			};
		}

		public static UnifiedModifierCollection CreateModifierCollection(XElement node) {
			Contract.Requires(node != null);
			return new UnifiedModifierCollection(node
				.Element("modifiers")
				.Elements()
				.Select(CreateModifier));
		}

		public static UnifiedType CreateType(XElement node) {
			Contract.Requires(node != null);
			//Contract.Requires(node.Name() == "type");
			//このメソッドにはtypeノードが入ってくるように他のメソッドを修正する？
			/* 
			 * type 
				:   classOrInterfaceType
					('[' ']'
					)*
				|   primitiveType
					('[' ']'
					)*
			*/
			var typeNode = node.Element("type");
			if(typeNode == null)
				return new UnifiedType {
						Name ="void"
				};

			switch (typeNode.FirstElement().Name()) {
				case "classOrInterfaceType":
					return CreateClassOrInterfaceType(typeNode.FirstElement());
				case "primitiveType":
					return new UnifiedType {
							Name = typeNode.Value
					};
				default:
					throw new InvalidOperationException();
			}
		}

		public static UnifiedType CreateClassOrInterfaceType(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classOrInterfaceType");
			/* 
			 * classOrInterfaceType 
				:   IDENTIFIER
					(typeArguments)?
					('.' IDENTIFIER (typeArguments)? )*
			  
			   typeArguments 
				:   '<' typeArgument
					(',' typeArgument )* 
					'>'
			 */
			return new UnifiedType {
				Name = node.Element("IDENTIFIER").Value,
				Parameters = new UnifiedTypeParameterCollection(
					node.Element("typeArguments").Elements("typeArgument").Select(CreatTypeParameter))
			};
		}

		public static UnifiedTypeParameter CreatTypeParameter(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeArgument");
			/* 
			 * typeArgument 
				:   type
				|   '?' 
					(
						('extends'
						|'super'
						)
						type
					)?
			 */
			var t = node.Element("type").FirstElement();
			if(t.Name.LocalName == "classOrInterfaceType") {
				return  new UnifiedTypeParameter {
					Modifiers = null,
					Value = CreateClassOrInterfaceType(t)
				};
			}
			return new UnifiedTypeParameter {
					Modifiers = null,
					Value = CreateType(node)
			};
		}

		public static UnifiedParameterCollection CreateFormalParameters(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameters");
			var element = node.Element("formalParameterDecls");
			if (element == null)
				return new UnifiedParameterCollection();

			return new UnifiedParameterCollection(element
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
			return new UnifiedParameter {
				Modifiers = new UnifiedModifierCollection(node
					.Element("variableModifiers")
					.Elements()
					.Select(CreateVariableModifier)),
				Name = node.Element("IDENTIFIER").Value,
				Type = CreateType(node)
			};
		}

		public static UnifiedParameter CreateEllipsisParameterDecl(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "ellipsisParameterDecl");
			throw new NotImplementedException();
		}

		public static UnifiedArgument CreateArgument(XElement node) {
			Contract.Requires(node != null);
			return new UnifiedArgument {
				Value = CreateExpression(node)
			};
		}

		public static UnifiedArgumentCollection CreateArgumentCollection(XElement node) {
			Contract.Requires(node != null);
			var element = node
				.Element("identifierSuffix")
				.Element("arguments")
				.Element("expressionList")
				.Elements()
				.Select(CreateArgument);
			return new UnifiedArgumentCollection(element);
		}

		#endregion

		public static UnifiedVariableDefinition CreateVariableDefinition(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "localVariableDeclarationStatement");
			//Top node is <localVariableDeclarationStatement>.
			//var variableDeclaration = node.Element("localVariableDeclaration");
			return CreateLocalVariableDeclaration(node.Element("localVariableDeclaration"));

		}
		public static UnifiedVariableDefinition CreateLocalVariableDeclaration(XElement node) {
			Contract.Requires(node.Name.LocalName == "localVariableDeclaration");
			/* localVariableDeclaration 
			 *   :   variableModifiers type variableDeclarator (',' variableDeclarator )* ;
			 */
			return new UnifiedVariableDefinition {
					InitialValue = CreateExpression(
						node.Element("variableDeclarator")
						.Element("variableInitializer")
						.Element("expression")),
					Modifiers = new UnifiedModifierCollection(node
						.Element("variableModifiers")
						.Elements()
						.Select(CreateVariableModifier)),
					Name = node.Element("variableDeclarator").Element("IDENTIFIER").Value,
					Type = CreateType(node)
			};
		}

		public static UnifiedBooleanLiteral CreateBooleanLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Elements().First().Value == "true" || node.Elements().First().Value == "false");
			var tokenNode = node.FirstElement();
			return new UnifiedBooleanLiteral {
				Value = tokenNode.Value == "true"
								? UnifiedBoolean.True : UnifiedBoolean.False,
			};
		}

		public static UnifiedClassDefinition CreateClass(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classDeclaration");
			return new UnifiedClassDefinition {
				//var modifiers = CreateModifierCollection(node);
				Name = node.Element("normalClassDeclaration")
					.Element("IDENTIFIER")
					.Value,
				Body = CreateClassBody(node
					.Element("normalClassDeclaration")
					.Element("classBody"))
			};
		}

		public static UnifiedBlock CreateClassBody(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classBody");
			return new UnifiedBlock(node
				.Elements("classBodyDeclaration")
				.Select(CreateMember).ToList());
		}

		public static IUnifiedExpression CreateMember(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classBodyDeclaration");
			var memType = node.Element("memberDecl").FirstElement();
			switch (memType.Name()) {
				case "fieldDeclaration":  return null; //TODO IMPLEMENT:
				case "methodDeclaration": return CreateDefineFunction(memType);
				case "classDeclaration":  return CreateClass(memType);
				default:
					throw new NotImplementedException();
			}
		}

		public static UnifiedProgram CreateProgram(XElement node) {
			Contract.Requires(node != null);
			var model = new UnifiedProgram {
				CreateClass(node
					.Element("typeDeclaration")
					.Element("classOrInterfaceDeclaration")
					.Element("classDeclaration"))
			};
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