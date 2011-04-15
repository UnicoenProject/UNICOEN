using System;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;

namespace Ucpf.Languages.Java.CodeGeneraotr {
	public partial class JavaCodeGenerator {
		// e.g. (Int)a  or (int)(a + b)
		public bool Visit(UnifiedCast element, TokenInfo data) {
			_writer.Write("(");
			element.Type.TryAccept(this, data);
			_writer.Write(")");
			element.Expression.TryAccept(this, WithParen);
			return true;
		}

		private static Tuple<string, string> GetKeyword(
				UnifiedTernaryOperatorKind kind) {
			switch (kind) {
			case UnifiedTernaryOperatorKind.Conditional:
				return Tuple.Create("?", ":");
			default:
				throw new ArgumentOutOfRangeException("kind");
			}
		}

		public bool Visit(UnifiedTernaryExpression element, TokenInfo data) {
			var keywords = GetKeyword(element.Operator.Kind);
			element.FirstExpression.TryAccept(this, WithParen);
			_writer.Write(" " + keywords.Item1 + " ");
			element.SecondExpression.TryAccept(this, WithParen);
			_writer.Write(" " + keywords.Item2 + " ");
			element.LastExpression.TryAccept(this, WithParen);
			return true;
		}

		public bool Visit(UnifiedImport element, TokenInfo data) {
			_writer.Write("import ");
			element.Modifiers.TryAccept(this, data);
			element.Name.TryAccept(this, data);
			return true;
		}

		public bool Visit(UnifiedBinaryExpression element, TokenInfo data) {
			_writer.Write(data.MostLeft);
			element.LeftHandSide.TryAccept(this, WithParen);
			WriteSpace();
			element.Operator.TryAccept(this, data);
			WriteSpace();
			element.RightHandSide.TryAccept(this, WithParen);
			_writer.Write(data.MostRight);
			return true;
		}

		public bool Visit(UnifiedSpecialExpression element, TokenInfo data) {
			_writer.Write(GetKeyword(element.Kind));
			if (element.Value != null) {
				WriteSpace();
				element.Value.TryAccept(this, data);
			}
			return true;
		}

		public bool Visit(UnifiedCall element, TokenInfo data) {
			var prop = element.Function as UnifiedProperty;
			if (prop != null) {
				prop.Owner.TryAccept(this, data);
				_writer.Write(prop.Delimiter);
				element.TypeArguments.TryAccept(this, data);
				prop.Name.TryAccept(this, data);
			} else {
				// Javaでifが実行されるケースは存在しないが、言語変換のため
				if (element.TypeArguments != null)
					_writer.Write("this.");
				element.TypeArguments.TryAccept(this, data);
				element.Function.TryAccept(this, data);
			}
			element.Arguments.TryAccept(this,
					new TokenInfo { MostLeft = "(", Delimiter = ", ", MostRight = ")" });
			return true;
		}

		// e.g. int a = 5
		public bool Visit(UnifiedVariableDefinition element, TokenInfo data) {
			element.Modifiers.TryAccept(this, data);
			WriteSpace();
			element.Type.TryAccept(this, data);
			WriteSpace();
			element.Bodys.TryAccept(this, data);
			return true;
		}

		public bool Visit(UnifiedNew element, TokenInfo data) {
			_writer.Write("new ");
			element.TypeArguments.TryAccept(this, data);
			element.Type.TryAccept(this, data);
			element.Arguments.TryAccept(this,
					new TokenInfo { MostLeft = "(", Delimiter = ", ", MostRight = ")" });
			element.InitialValues.TryAccept(this,
					new TokenInfo { MostLeft = "{", Delimiter = ", ", MostRight = "}" });
			element.Body.TryAccept(this, data);
			return true;
		}

		public bool Visit(UnifiedUnaryExpression element, TokenInfo data) {
			if (element.Operator.Kind == UnifiedUnaryOperatorKind.PostIncrementAssign ||
			    element.Operator.Kind == UnifiedUnaryOperatorKind.PostDecrementAssign) {
				element.Operand.TryAccept(this, WithParen);
				element.Operator.TryAccept(this, data);
			} else {
				element.Operator.TryAccept(this, WithParen);
				element.Operand.TryAccept(this, data);
			}
			return true;
		}

		public bool Visit(UnifiedProperty element, TokenInfo data) {
			element.Owner.TryAccept(this, data);
			_writer.Write(element.Delimiter);
			element.Name.TryAccept(this, data);
			return true;
		}
	}
}