using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Paraiba.Xml.Linq;
using Ucpf.Core.Model;
using Code2Xml.Languages.Java.XmlGenerators;

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
				node.Descendants().Where(e => {
					var c = e.Elements().Count();
					return c > 1 || (c == 1 && e.Element("IDENTIFIER") != null) ||
						   (c == 1 && e.Element("TOKEN") != null);
				});

			//Ensure that node has some expression
			if (expressionList.Count() == 0) {
				throw new NotImplementedException();
			}

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
			if (topExpressionElement.Name.LocalName == "unaryExpression") {
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
			return new UnifiedUnaryExpression {
				Operator = CreateUnaryOperator(node.NthElement(0)),
				Operand = CreateExpression(node.NthElement(1))
			};
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
			var element = node.Elements().First();

			switch (element.Name.LocalName) {
				case "block": return CreateBlock(element);
				case "IF": return CreateIf(node);
				case "RETURN": return CreateReturn(node);
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
			Contract.Requires(node != null);
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
		
		public static UnifiedReturn CreateReturn(XElement node) {
			Contract.Requires(node != null);
			return new UnifiedReturn {
				Value = CreateExpression(node.Element("expression"))
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