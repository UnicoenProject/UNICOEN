using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Code2Xml.Languages.Java.XmlGenerators;
using Ucpf.Core.Model;



namespace Ucpf.Languages.Java.Model {
	public class JavaModelFactory
	{

		#region Expression

		public static UnifiedExpression CreateExpression(XElement node) {
			
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
				//case Variable
				if (System.Text.RegularExpressions.Regex.IsMatch(topExpressionElement.Value, @"[a-zA-Z]{1}[a-zA-Z0-9]*")) {
					return CreateVariable(topExpressionElement);
				}
				return CreateLiteral(topExpressionElement);
			}

			//case BinaryExpression
			if (binaryOperator.Contains(topExpressionElement.Elements().ElementAt(1).Value)) {
				return CreateBinaryExpression(topExpressionElement);
			}

			//case CallExpression
			if (topExpressionElement.Name.LocalName == "primary") {
				return CreateCallExpression(topExpressionElement);
			}

			//TODO IMPLEMENT: other cases
			throw new NotImplementedException();
		}

		public static UnifiedBinaryExpression CreateBinaryExpression(XElement node) {
			return new UnifiedBinaryExpression {
				LeftHandSide = CreateExpression(node.Elements().ElementAt(0)),
				Operator = CreateBinaryOperator(node.Elements().ElementAt(1)),
				RightHandSide = CreateExpression(node.Elements().ElementAt(2))
			};
		}

		public static UnifiedCall CreateCallExpression(XElement node) {
			//Top node is <primary>
			return new UnifiedCall {
				Arguments = CreateArgumentCollection(node),
				//Function = CreateExpression(node)
				Function = CreateVariable(node.Element("IDENTIFIER"))
			};
		}

		public static UnifiedVariable CreateVariable(XElement node) {
			return new UnifiedVariable {
				Name = node.Value
			};
		}

		public static UnifiedLiteral CreateLiteral(XElement node) {
			int i;
			if( Int32.TryParse(node.Value,NumberStyles.Any, null, out i) )
			{
				return new UnifiedIntegerLiteral {
					Value = i
				};
			}

			//TODO IMPLEMENT: other literal cases
			throw new NotImplementedException();
		}

		#endregion

		#region Operator

		public static UnifiedBinaryOperator CreateBinaryOperator(XElement node) {
			//TODO implement more OperatorType cases
			var name = node.Value;
			UnifiedBinaryOperatorType type;

			switch (name) {
			//Arithmetic
				case "+": type = UnifiedBinaryOperatorType.Addition; break;
				case "-": type = UnifiedBinaryOperatorType.Subtraction; break;
				case "*": type = UnifiedBinaryOperatorType.Multiplication; break;
				case "/": type = UnifiedBinaryOperatorType.Division; break;
				case "%": type = UnifiedBinaryOperatorType.Modulo; break;
			//Shift
				case "<<": type = UnifiedBinaryOperatorType.LeftShift; break;
				case ">>": type = UnifiedBinaryOperatorType.RightShift; break;
			//Comparison
				case ">": type = UnifiedBinaryOperatorType.Greater; break;
				case ">=": type = UnifiedBinaryOperatorType.GreaterEqual; break;
				case "<": type = UnifiedBinaryOperatorType.Lesser; break;
				case "<=": type = UnifiedBinaryOperatorType.LesserEqual; break;
				case "==": type = UnifiedBinaryOperatorType.Equal; break;
				case "!=": type = UnifiedBinaryOperatorType.NotEqual; break;
			//Logocal
				case "&&": type = UnifiedBinaryOperatorType.LogicalAnd; break;
				case "||": type = UnifiedBinaryOperatorType.LogicalOr; break;
			//Bit
				case "&": type = UnifiedBinaryOperatorType.BitAnd; break;
				case "|": type = UnifiedBinaryOperatorType.BitOr; break;
				case "^": type = UnifiedBinaryOperatorType.BitXor; break;
			//Assignment
				case "=": type = UnifiedBinaryOperatorType.Assignment; break;
				case "+=": type = UnifiedBinaryOperatorType.AddAssignment; break;
				case "-=": type = UnifiedBinaryOperatorType.SubAssignment; break;
				case "*=": type = UnifiedBinaryOperatorType.MulAssignment; break;
				case "/=": type = UnifiedBinaryOperatorType.DivAssignment; break;
				case "%=": type = UnifiedBinaryOperatorType.ModAssignment; break;
				default:
					throw new InvalidOperationException();
			}
			return new UnifiedBinaryOperator(name, type);
		}

		#endregion

		#region Statement

		public static UnifiedExpression CreateStatement(XElement node) {
			var element = node.Elements().First();

			switch (element.Name.LocalName) {
				case "block": return CreateBlock(element);
				case "IF": return CreateIf(node);
				case "RETURN": return CreateReturn(node);
				default: throw new NotImplementedException();
			}
		}
		
		public static UnifiedBlock CreateBlock(XElement node) {
			if (node.Element("blockStatement") == null)
				return new UnifiedBlock();

			return new UnifiedBlock(
				node.Element("blockStatement").Elements("statement").Select(CreateStatement).ToList()
			);
		}

		public static UnifiedIf CreateIf(XElement node) {
			return new UnifiedIf {
				Condition = CreateExpression(node.Element("parExpression").Element("expression")),
				TrueBlock = (UnifiedBlock)CreateStatement(node.Element("statement")),
				FalseBlock = (UnifiedBlock)CreateStatement(node.Elements("statement").ElementAt(1))
			};
		}
		
		public static UnifiedReturn CreateReturn(XElement node) {
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
			return new UnifiedModifier {
				Name = node.Value
			};
		}

		public static UnifiedModifier CreateModifier(XElement node) {
			return new UnifiedModifier {
				Name = node.Value
			};
		}

		public static UnifiedModifierCollection CreateModifierCollection(XElement node) {
			return new UnifiedModifierCollection(node.Element("modifiers").Elements().Select(e => CreateModifier(e)));
		}

		public static UnifiedType CreateType(XElement node) {
			return new UnifiedType {
				Name = node.Element("type").Value
			};
		}

		public static UnifiedParameter CreateParameter(XElement node) {
			return new UnifiedParameter {
				Modifiers = new UnifiedModifierCollection(node.Element("variableModifiers").Elements().Select(e => CreateVariableModifier(e))),
				Name = node.Element("IDENTIFIER").Value,
				Type = CreateType(node)
			};
		}

		private static UnifiedParameterCollection CreateParameterCollection(XElement node) {
			var element = node.Element("formalParameters");
			return new UnifiedParameterCollection(
				element.Element("formalParameterDecls").Elements("normalParameterDecl")
					.Select(e => CreateParameter(e))
					);
		}

		public static UnifiedArgument CreateArgument(XElement node) {
			return new UnifiedArgument {
				Value = CreateExpression(node)
			};
		}

		public static UnifiedArgumentCollection CreateArgumentCollection(XElement node) {
			var element =
				node.Element("identifierSuffix").Element("arguments").Element(
					"expressionList").Elements().Select(e => CreateArgument(e));
			return new UnifiedArgumentCollection(element);
		}

		#endregion

		public static UnifiedBooleanLiteral CreateBooleanLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "true" || node.Name.LocalName == "false");
			return new UnifiedBooleanLiteral {
				Value = node.Name.LocalName == "true"
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
			//Top node is <classDeclaration>
			return new UnifiedClassDefinition {
				//var modifiers = CreateModifierCollection(node);
				Name = node.Element("normalClassDeclaration").Element("IDENTIFIER").Value,
				Body = CreateClassBody(node.Element("normalClassDeclaration").Element("classBody"))
			};
		}

		public static UnifiedBlock CreateClassBody(XElement node) {
			//Top node is <classBody>
			return new UnifiedBlock(node.Elements("classBodyDeclaration")
				.Select(CreateMember).ToList());
		}

		public static UnifiedExpression CreateMember(XElement node) {
			//Top node is <classBodyDeclaration>
			var memType = node.Element("memberDecl").Elements().First();
			switch (memType.Name.LocalName) {
				case "fieldDeclaration":  return null; //TODO IMPLEMENT:
				case "methodDeclaration": return CreateDefineFunction(memType);
				case "classDeclaration":  return CreateClass(memType);
				default:
					throw new NotImplementedException();
			}
		}

		public static UnifiedProgram CreateProgram(XElement node) {
			return new UnifiedProgram {
				CreateClass(node.Element("typeDeclaration")
				.Element("classOrInterfaceDeclaration").Element("classDeclaration"))
			};
		}

		public static UnifiedProgram CreateModel(string source) {
			var ast = JavaXmlGenerator.Instance.Generate(source);
			return CreateProgram(ast);
		}
	}
}