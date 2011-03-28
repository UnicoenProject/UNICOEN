using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Paraiba.Xml.Linq;
using Ucpf.Core.Model;
using Code2Xml.Languages.Java.XmlGenerators;
using System.Collections.Generic;

namespace Ucpf.Languages.Java.Model {
	public class JavaModelFactory
	{
		#region Expression

		public static UnifiedExpression CreateExpression(XElement node) {
			Contract.Requires(node != null);
			
			//TODO IMPLEMENT: more operators
			String[] binaryOperator = {
				"+", "-", "*", "/", "%", "<", ">"
			};

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

			//case PrimaryExpression: IDENTIFIER or TOKEN
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

			//case CallExpression
			if (topExpressionElement.Name.LocalName == "primary") {
				return CreateCallExpression(topExpressionElement);
			}

			// case parExpression
			// expression を () で囲ったような場合
			if (topExpressionElement.Name.LocalName == "parExpression") {
				return CreateExpression(topExpressionElement.Elements().ElementAt(1));
			}
			

			//TODO IMPLEMENT: other cases
			throw new NotImplementedException();
		}

		public static UnifiedBinaryExpression CreateBinaryExpression(XElement node) {
			Contract.Requires(node != null);
			return new UnifiedBinaryExpression {
				LeftHandSide = CreateExpression(node.NthElement(0)),
				Operator = CreateBinaryOperator(node.NthElement(1)),
				RightHandSide = CreateExpression(node.NthElement(2))
			};
		}

		public static UnifiedUnaryExpression CreateUnaryExpression(XElement node) {
			Contract.Requires(node != null);
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

		public static UnifiedCall CreateCallExpression(XElement node) {
			Contract.Requires(node != null);
			//Top node is <primary>
			return new UnifiedCall {
				Arguments = CreateArgumentCollection(node),
				//Function = CreateExpression(node)
				Function = CreateVariable(node.Element("IDENTIFIER"))
			};
		}

		public static UnifiedVariable CreateVariable(XElement node) {
			Contract.Requires(node != null);
			return new UnifiedVariable {
				Name = node.Value
			};
		}

		public static UnifiedLiteral CreateLiteral(XElement node) {
			Contract.Requires(node != null);
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

		public static UnifiedExpression CreateStatement(XElement node) {
			Contract.Requires(node != null);
			var element = node.FirstElement();

			switch (element.Name.LocalName) {
				case "block": return CreateBlock(element);
				case "IF": return CreateIf(node);
				case "RETURN": return CreateReturn(node);
				case "forstatement": return CreateFor(node);
				case "WHILE": return CreateWhile(node);
				case "DO": return CreateDoWhile(node);
				case "SWITCH": return CreateSwitch(node);
				case "BREAK": return CreateBreak(node);
				default: throw new NotImplementedException();
			}
		}
		
		public static UnifiedBlock CreateBlock(XElement node) {
			Contract.Requires(node != null);
			var block = node.Element("blockStatement");
			if (block == null)
				return new UnifiedBlock();

			return new UnifiedBlock(
				block.Elements("statement")
					.Select(CreateStatement)
					.ToList()
			);
		}

		public static UnifiedIf CreateIf(XElement node) {
			Contract.Requires(node.Elements().First().Name.LocalName == "IF");
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
			Contract.Requires(node.Elements().First().Name.LocalName == "WHILE");
			return new UnifiedWhile {
				Condition =
					CreateExpression(node.Element("parExpression").Element("expression")),
				Body = new UnifiedBlock {
					CreateStatement(node.Element("statement"))
				}
			};
		}

		public static UnifiedDoWhile CreateDoWhile(XElement node) {
			Contract.Requires(node.Elements().First().Name.LocalName == "DO");
			return new UnifiedDoWhile {
				Body = new UnifiedBlock {
						CreateStatement(node.Element("statement"))
				},
				Condition = 
					CreateExpression(node.Element("parExpression").Element("expression"))
			};
		}

		public static UnifiedExpression CreateFor(XElement node) {
			Contract.Requires(node.Elements().First().Name.LocalName == "forstatement");
			/*	forstatement :   
					// enhanced for loop
					'for' '(' variableModifiers type IDENTIFIER ':' 
					expression ')' statement
					// normal for loop
				|   'for' '(' 
							(forInit
							)? ';' 
							(expression
							)? ';' 
							(expressionList
							)? ')' statement
						return new UnifiedFor();
			 * */
			var forstatement = node.FirstElement();
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

				var body = CreateStatement(forstatement);
				return new UnifiedFor {
					Initializer = initializer,
					Condition = condition,
					Step = step,
					Body = new UnifiedBlock{ body }
				};
			}
		}

		public static UnifiedSwitch CreateSwitch(XElement node) {
			Contract.Requires(node.Elements().First().Name.LocalName == "SWITCH");
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
			//var body = CreateBlock(node.Element("blockStatement"));
			var body = CreateBlock(node);
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
			return new UnifiedBreak();
		}

		public static UnifiedExpression CreateForInit(XElement node) {
			switch(node.FirstElement().Name.LocalName) {
				case "localVariableDeclaration":
					return CreateLocalVariableDeclaration(node.FirstElement());
				case "expressionList":
				return CreateExpressionList(node.FirstElement());
			}
			throw new InvalidOperationException();
		}
		
		private static UnifiedExpression CreateLocalVariableDeclaration(XElement xElement) {
			/*
			 * localVariableDeclaration 
				:   variableModifiers type variableDeclarator (',' variableDeclarator )*
				;*/
			return CreateExpression(xElement);
			//TODO: 構文に沿ったように実装する
			//var variables = new List<UnifiedExpression>();
			//return new UnifiedExpressionCollection(variables);

		}

		public static UnifiedExpression CreateExpressionList(XElement node) {
			/*
			 * expressionList : expression (',' expression )* ;
			 */
			return CreateExpression(node.Element("expression"));
			//TODO: 構文に沿ったように実装する
		}

		public static UnifiedReturn CreateReturn(XElement node) {
			Contract.Requires(node != null);
			UnifiedExpression value = null;
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
		 *   modifiers (typeParameters)? IDENTIFIER formalParameters ('throws' qualifiedNameList)? '{' (explicitConstructorInvocation)? (blockStatement)* '}'
		 * | modifiers (typeParameters)? (type | 'void') IDENTIFIER formalParameters ('[' ']')* ('throws' qualifiedNameList)? (block | ';');
		 * 
		 */
		public static UnifiedFunctionDefinition CreateDefineFunction(XElement node) {
			Contract.Requires(node != null);
			return new UnifiedFunctionDefinition {
				Modifiers  = CreateModifierCollection(node),
				Type       = CreateType(node),
				Name       = node.Element("IDENTIFIER").Value,
				Parameters = CreateParameterCollection(node),
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
			var typeNode = node.Element("type");
			return new UnifiedType {
				Name = typeNode != null ? typeNode.Value : "void"
			};
		}

		public static UnifiedParameter CreateParameter(XElement node) {
			Contract.Requires(node != null);
			return new UnifiedParameter {
				Modifiers = new UnifiedModifierCollection(node
					.Element("variableModifiers")
					.Elements()
					.Select(CreateVariableModifier)),
				Name = node.Element("IDENTIFIER").Value,
				Type = CreateType(node)
			};
		}

		private static UnifiedParameterCollection CreateParameterCollection(XElement node) {
			Contract.Requires(node != null);
			var element = node
				.Element("formalParameters")
				.Element("formalParameterDecls");
			if (element == null) return new UnifiedParameterCollection();
			return new UnifiedParameterCollection(element
				.Elements("normalParameterDecl")
				.Select(CreateParameter));
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

		public static UnifiedBooleanLiteral CreateBooleanLiteral(XElement node) {
			Contract.Requires(node.Elements().First().Value == "true" || node.Elements().First().Value == "false");
			var tokenNode = node.FirstElement();
			return new UnifiedBooleanLiteral {
				Value = tokenNode.Value == "true"
								? UnifiedBoolean.True : UnifiedBoolean.False,
			};
		}

		public static UnifiedStringLiteral CreateStringLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "str");
			return new UnifiedStringLiteral {
				Value = node.Value,
			};
		}

		public static UnifiedIntegerLiteral CreateIntegerLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "lit");
			return UnifiedIntegerLiteral.Create(BigInteger.Parse(node.Value));
		}

		public static UnifiedDecimalLiteral CreateDecimalLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "lit");
			return new UnifiedDecimalLiteral {
				Value = Decimal.Parse(node.Value)
			};
		}

		public static UnifiedClassDefinition CreateClass(XElement node) {
			Contract.Requires(node != null);
			//Top node is <classDeclaration>
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
			//Top node is <classBody>
			return new UnifiedBlock(node
				.Elements("classBodyDeclaration")
				.Select(CreateMember).ToList());
		}

		public static UnifiedExpression CreateMember(XElement node) {
			Contract.Requires(node != null);
			//Top node is <classBodyDeclaration>
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
			var ast = JavaXmlGenerator.Instance.Generate(source);
			return CreateProgram(ast);
		}
	}
}