using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Ast;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Expressions;
using Ucpf.Core.Model.Expressions.Operators;

namespace Ucpf.Languages.CSharp {

	partial class Translator {

		private static UnifiedBinaryOperator ConvertOperator(BinaryOperatorType type) {
			switch (type) {
				case BinaryOperatorType.Add:
					return new UnifiedBinaryOperator("+", UnifiedBinaryOperatorType.Addition);
				case BinaryOperatorType.Subtract:
					return new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtraction);

				case BinaryOperatorType.LessThan:
					return new UnifiedBinaryOperator("<", UnifiedBinaryOperatorType.Lesser);
				case BinaryOperatorType.LessThanOrEqual:
					return new UnifiedBinaryOperator("<=", UnifiedBinaryOperatorType.LesserEqual);
				case BinaryOperatorType.GreaterThan:
					return new UnifiedBinaryOperator(">", UnifiedBinaryOperatorType.Greater);
				case BinaryOperatorType.GreaterThanOrEqual:
					return new UnifiedBinaryOperator(">=", UnifiedBinaryOperatorType.GreaterEqual);
			}
			return null;
		}

		private static UnifiedModifierCollection ConvertModifiler(Modifiers mods) {
			var ret = new UnifiedModifierCollection();
			if ((mods & Modifiers.Private) != 0) {
				ret.Add(new UnifiedModifier { Name = "private" });
			}
			if ((mods & Modifiers.Protected) != 0) {
				ret.Add(new UnifiedModifier { Name = "protected" });
			}
			if ((mods & Modifiers.Public) != 0) {
				ret.Add(new UnifiedModifier { Name = "public" });
			}

			if ((mods & Modifiers.Static) != 0) {
				ret.Add(new UnifiedModifier { Name = "static" });
			}
			return ret;
		}

		private static UnifiedType GetTypeName(TypeReference type) {
			if (type.IsKeyword) {
				switch (type.Type) {
				case "System.Int32":
					return new UnifiedType { Name = "int" };
				case "System.Void":
					return new UnifiedType { Name = "void" };
				case "Sytem.String":
					return new UnifiedType { Name = "string" };
				}
			}
			return new UnifiedType { Name = type.Type };
		}

		private static UnifiedBlock ToBlock(IEnumerable<object> contents) {
			var block = new UnifiedBlock();
			foreach (var item in contents) {
				var expr = item as UnifiedExpression;
				if (expr != null) {
					block.Add(expr);
					continue;
				}
				throw new NotImplementedException();
			}
			return block;
		}
	}
}
