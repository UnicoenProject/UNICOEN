using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Ast;
using Ucpf.Core.Model;



namespace Ucpf.Languages.CSharp {

	partial class Translator {

		private static UnifiedBinaryOperator ConvertBinaryOperator(BinaryOperatorType type) {
			switch (type) {
			case BinaryOperatorType.Add:
				return new UnifiedBinaryOperator("+", UnifiedBinaryOperatorType.Add);
			case BinaryOperatorType.Subtract:
				return new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtract);

			case BinaryOperatorType.LessThan:
				return new UnifiedBinaryOperator("<", UnifiedBinaryOperatorType.LessThan);
			case BinaryOperatorType.LessThanOrEqual:
				return new UnifiedBinaryOperator("<=", UnifiedBinaryOperatorType.LessThanOrEqual);
			case BinaryOperatorType.GreaterThan:
				return new UnifiedBinaryOperator(">", UnifiedBinaryOperatorType.GreaterThan);
			case BinaryOperatorType.GreaterThanOrEqual:
				return new UnifiedBinaryOperator(">=", UnifiedBinaryOperatorType.GreaterThanOrEqual);
			}
			throw new NotImplementedException();
		}

		private static UnifiedUnaryOperator ConvertUnaryOperator(UnaryOperatorType type) {
			switch (type) {
			case UnaryOperatorType.Plus:
				return new UnifiedUnaryOperator("+", UnifiedUnaryOperatorType.UnaryPlus);
			case UnaryOperatorType.Minus:
				return new UnifiedUnaryOperator("-", UnifiedUnaryOperatorType.Negate);

			case UnaryOperatorType.Increment:
				return new UnifiedUnaryOperator("++",
					UnifiedUnaryOperatorType.PreIncrementAssign);
			case UnaryOperatorType.PostIncrement:
				return new UnifiedUnaryOperator("++",
					UnifiedUnaryOperatorType.PostIncrementAssign);
			case UnaryOperatorType.Decrement:
				return new UnifiedUnaryOperator("--",
					UnifiedUnaryOperatorType.PreDecrementAssign);
			case UnaryOperatorType.PostDecrement:
				return new UnifiedUnaryOperator("--",
					UnifiedUnaryOperatorType.PostDecrementAssign);
			}
			throw new NotImplementedException();
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
			if (String.IsNullOrEmpty(typeName))
				return null;

			if (type.IsKeyword) {
				typeName = GetTypeAlias(typeName) ?? typeName;
			}
			var typeParameter = new UnifiedTypeParameterCollection();
			foreach (var gType in type.GenericTypes) {
				var uType = ConvertType(gType);
				typeParameter.Add(new UnifiedTypeParameter { Value = uType });
			}
			return new UnifiedType { Name = typeName, Parameters = typeParameter };
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
			return new UnifiedType {
					Name = buff.ToString(),
					Parameters = uType.Parameters.DeepCopy<UnifiedTypeParameterCollection>()
			};
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
				if (item == null)
					continue;
				var expr = item as IUnifiedExpression;
				if (expr != null) {
					block.Add(expr);
					continue;
				}
				var exprs = item as IEnumerable<IUnifiedExpression>;
				if (exprs != null) {
					foreach (var iExpr in exprs)
						block.Add(iExpr);
					continue;
				}
				throw new NotImplementedException("ToFlattenBlock");
			}
			return block;
		}
	}
}
