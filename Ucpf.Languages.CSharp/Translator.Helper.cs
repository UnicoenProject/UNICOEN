using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Ast;
using Ucpf.Common.Model;

namespace Ucpf.Languages.CSharp {

	partial class Translator {

		private static UnifiedBinaryOperator ConvertBinaryOperator(BinaryOperatorType type) {
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
			throw new NotImplementedException();
			return null;
		}

		private static UnifiedUnaryOperator ConvertUnaryOperator(UnaryOperatorType type) {
			switch (type) {
				case UnaryOperatorType.Plus:
					return new UnifiedUnaryOperator("+", UnifiedUnaryOperatorType.Plus);
				case UnaryOperatorType.Minus:
					return new UnifiedUnaryOperator("-", UnifiedUnaryOperatorType.Minus);

				case UnaryOperatorType.Increment:
					return new UnifiedUnaryOperator("++",
						UnifiedUnaryOperatorType.PrefixIncrement);
				case UnaryOperatorType.PostIncrement:
					return new UnifiedUnaryOperator("++",
						UnifiedUnaryOperatorType.PostfixIncrement);
				case UnaryOperatorType.Decrement:
					return new UnifiedUnaryOperator("--",
						UnifiedUnaryOperatorType.PrefixDecrement);
				case UnaryOperatorType.PostDecrement:
					return new UnifiedUnaryOperator("--",
						UnifiedUnaryOperatorType.PostfixDecrement);
			}
			throw new NotImplementedException();
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

		private static UnifiedType ConvertTypeIgnoringIsArray(TypeReference type) {
			string typeName = type.Type;
			if (type.IsKeyword) {
				typeName = GetTypeAlias(typeName) ?? typeName;
			}
			return new UnifiedType { Name = typeName };
		}

		private static UnifiedType ConvertType(TypeReference type) {
			var uType = ConvertTypeIgnoringIsArray(type);

			var buff = new StringBuilder(uType.Name);
			if (type.IsArrayType) {
				foreach (int rank in type.RankSpecifier) {
					buff.Append("[");
					for (int i = 0; i < rank; i++)
						buff.Append(",");
					buff.Append("]");
				}
			}
			return new UnifiedType { Name = buff.ToString() };
		}

		private static string GetTypeAlias(string fullTypeName) {
			switch (fullTypeName) {
				case "System.Int32":
					return "int";
				case "System.Void":
					return "void";
				case "Sytem.String":
					return "string";
			}
			return null;
		}

		private static UnifiedBlock ToFlattenBlock(IEnumerable<object> contents) {
			var block = new UnifiedBlock();
			foreach (var item in contents) {
				var expr = item as UnifiedExpression;
				if (expr != null) {
					block.Add(expr);
					continue;
				}
				var exprs = item as IEnumerable<UnifiedExpression>;
				if (exprs != null) {
					foreach (var iExpr in exprs)
						block.Add(iExpr);
					continue;
				}
				throw new NotImplementedException();
			}
			return block;
		}
	}
}
