using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Ucpf.Core.Model;



namespace Ucpf.Languages.Java.Model {
	public class JavaModelFactory {

		#region Function

		/*
		 * methodDeclaration
		 * :
		 *   modifiers (typeParameters)? IDENTIFIER formalParameters ('throws' qualifiedNameList)? '{' (explicitConstructorInvocation)? (blockStatement)* '}'
         * | modifiers (typeParameters)? (type | 'void') IDENTIFIER formalParameters ('[' ']')* ('throws' qualifiedNameList)? (block | ';');
		 * 
		 */
		public static UnifiedFunctionDefinition CreateDefineFunction(XElement node) {
			var modifiers = new UnifiedModifierCollection(node.Element("modifiers")
				.Elements().Select(e => new UnifiedModifier { Name = e.Value } ));
			var returnType = node.Element("type").Elements().ElementAt(0).Value;
			var name = node.Element("IDENTIFIER").Value;
			var parameter = CreateParameterCollection(node.Element("formalParameters"));
			//TODO IMPLEMENT:
			var block = new UnifiedBlock();

			return new UnifiedFunctionDefinition {
				Modifiers = modifiers,
				Type = new UnifiedType { Name = returnType },
				Name = name,
				Parameters = parameter,
				Body = block
			};
		}

		public static UnifiedModifier CreateVariableModifier(XElement node) {
			return new UnifiedModifier {
				Name = node.Value
			};
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

		private static UnifiedParameterCollection CreateParameterCollection(XElement element) {
			return new UnifiedParameterCollection(
				element.Element("formalParameterDecls").Elements("normalParameterDecl")
					.Select(e => CreateParameter(e))
					);
		}

		#endregion



		public static UnifiedBooleanLiteral CreateBooleanLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "true" || node.Name.LocalName == "false");
			return new UnifiedBooleanLiteral {
				Value = node.Name.LocalName == "true"
				             	? UnifiedBoolean.True : UnifiedBoolean.False,
			};
		}

				private static UnifiedBlock CreateBlock(XElement xElement) {
			var unifiedBlock = new UnifiedBlock();

			var element = xElement.Element("blockStatement")
				.Element("statement");

			if (element.Elements().First().Name.LocalName == "TOKEN" 
				&& element.Elements().First().Value == "if") {
				unifiedBlock.Add(CreateIfExpression(element));
			}
			throw new NotImplementedException("in CreateBlock");
		}

		private static UnifiedIf CreateIfExpression(XElement xElement) {
			throw new NotImplementedException();
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

		public static object CreateModel(string source) {
			throw new NotImplementedException();
		}
	}
}