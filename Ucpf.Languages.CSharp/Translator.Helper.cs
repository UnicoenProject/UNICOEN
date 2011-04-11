using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.NRefactory.Ast;
using Ucpf.Core.Model;

namespace Ucpf.Languages.CSharp
{
	internal partial class Translator
	{
		private static UnifiedBinaryOperator ConvertBinaryOperator(
			BinaryOperatorType type)
		{
			switch (type) {
			case BinaryOperatorType.Add:
				return UnifiedBinaryOperator.Create("+", UnifiedBinaryOperatorType.Add);
			case BinaryOperatorType.Subtract:
				return UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Subtract);

			case BinaryOperatorType.LessThan:
				return UnifiedBinaryOperator.Create("<", UnifiedBinaryOperatorType.LessThan);
			case BinaryOperatorType.LessThanOrEqual:
				return UnifiedBinaryOperator.Create("<=",
					UnifiedBinaryOperatorType.LessThanOrEqual);
			case BinaryOperatorType.GreaterThan:
				return UnifiedBinaryOperator.Create(">",
					UnifiedBinaryOperatorType.GreaterThan);
			case BinaryOperatorType.GreaterThanOrEqual:
				return UnifiedBinaryOperator.Create(">=",
					UnifiedBinaryOperatorType.GreaterThanOrEqual);
			}
			throw new NotImplementedException();
		}

		private static UnifiedUnaryOperator ConvertUnaryOperator(
			UnaryOperatorType type)
		{
			switch (type) {
			case UnaryOperatorType.Plus:
				return UnifiedUnaryOperator.Create("+", UnifiedUnaryOperatorType.UnaryPlus);
			case UnaryOperatorType.Minus:
				return UnifiedUnaryOperator.Create("-", UnifiedUnaryOperatorType.Negate);

			case UnaryOperatorType.Increment:
				return UnifiedUnaryOperator.Create("++",
					UnifiedUnaryOperatorType.PreIncrementAssign);
			case UnaryOperatorType.PostIncrement:
				return UnifiedUnaryOperator.Create("++",
					UnifiedUnaryOperatorType.PostIncrementAssign);
			case UnaryOperatorType.Decrement:
				return UnifiedUnaryOperator.Create("--",
					UnifiedUnaryOperatorType.PreDecrementAssign);
			case UnaryOperatorType.PostDecrement:
				return UnifiedUnaryOperator.Create("--",
					UnifiedUnaryOperatorType.PostDecrementAssign);
			}
			throw new NotImplementedException();
		}

		private static UnifiedModifierCollection ConvertModifiler(Modifiers mods)
		{
			var ret = UnifiedModifierCollection.Create();
			if ((mods & Modifiers.Private) != 0) {
				ret.Add(UnifiedModifier.Create("private"));
			}
			if ((mods & Modifiers.Protected) != 0) {
				ret.Add(UnifiedModifier.Create("protected"));
			}
			if ((mods & Modifiers.Public) != 0) {
				ret.Add(UnifiedModifier.Create("public"));
			}

			if ((mods & Modifiers.Static) != 0) {
				ret.Add(UnifiedModifier.Create("static"));
			}
			return ret;
		}

		private static UnifiedType ConvertTypeIgnoringIsArray(TypeReference type)
		{
			string typeName = type.Type;
			if (String.IsNullOrEmpty(typeName))
				return null;

			if (type.IsKeyword) {
				typeName = GetTypeAlias(typeName) ?? typeName;
			}
			var typeParameter = UnifiedTypeArgumentCollection.Create();
			foreach (var gType in type.GenericTypes) {
				var uType = ConvertType(gType);
				typeParameter.Add(UnifiedTypeArgument.Create(uType));
			}
			return UnifiedType.Create(typeName, typeParameter);
		}

		private static UnifiedType ConvertType(TypeReference type)
		{
			var uType = ConvertTypeIgnoringIsArray(type);

			var buff = new StringBuilder(uType.Name.Value);
			if (type.IsArrayType) {
				foreach (int rank in type.RankSpecifier) {
					buff.Append("[");
					for (int i = 0; i < rank; i++)
						buff.Append(",");
					buff.Append("]");
				}
			}
			return UnifiedType.Create(buff.ToString(),
				uType.Arguments.DeepCopy<UnifiedTypeArgumentCollection>());
		}

		private static string GetTypeAlias(string fullTypeName)
		{
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

		private static UnifiedBlock ToFlattenBlock(IEnumerable<object> contents)
		{
			var block = UnifiedBlock.Create();
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