using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;

namespace Ucpf.Languages.Java.CodeGeneraotr
{
	public partial class JavaCodeGenerator
	{
		// e.g. (Int)a  or (int)(a + b)
		public bool Visit(UnifiedCast element, TokenInfo data)
		{
			var expression = element.Expression;

			_writer.Write("(");
			element.Type.TryAccept(this, data);
			_writer.Write(")");
			_writer.Write("(");
			expression.TryAccept(this, data);
			_writer.Write(")");
			return true;
		}

		public bool Visit(UnifiedTernaryExpression element, TokenInfo data)
		{
			element.FirstExpression.TryAccept(this, data);
			WriteSpace();
			element.SecondExpression.TryAccept(this, data);
			WriteSpace();
			element.LastExpression.TryAccept(this, data);
			return true;
		}

		public bool Visit(UnifiedImport element, TokenInfo data)
		{
			_writer.Write("import ");
			element.Modifiers.TryAccept(this, data);
			element.Name.TryAccept(this, data);
			return true;
		}

		public bool Visit(UnifiedBinaryExpression element, TokenInfo data)
		{
			_writer.Write("(");
			element.LeftHandSide.TryAccept(this, data);
			element.Operator.TryAccept(this, data);
			element.RightHandSide.TryAccept(this, data);
			_writer.Write(")");
			return true;
		}

		public bool Visit(UnifiedSpecialExpression element, TokenInfo data)
		{
			_writer.Write(GetKeyword(element.Kind));
			if (element.Value != null) {
				WriteSpace();
				element.Value.TryAccept(this, data);
			}
			return true;
		}

		public bool Visit(UnifiedCall element, TokenInfo data)
		{
			element.TypeArguments.TryAccept(this, data);
			element.Function.TryAccept(this, data);
			element.Arguments.TryAccept(this,
				new TokenInfo { MostLeft = "(", Delimiter = ", ", MostRight = ")" });
			return true;
		}

		// e.g. int a = 5
		public bool Visit(UnifiedVariableDefinition element, TokenInfo data)
		{
			element.Modifiers.TryAccept(this, data);
			WriteSpace();
			element.Type.TryAccept(this, data);
			WriteSpace();
			element.Bodys.TryAccept(this, data);
			return true;
		}

		public bool Visit(UnifiedNew element, TokenInfo data)
		{
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

		public bool Visit(UnifiedUnaryExpression element, TokenInfo data)
		{
			if (element.Operator.Kind == UnifiedUnaryOperatorKind.PostIncrementAssign ||
			    element.Operator.Kind == UnifiedUnaryOperatorKind.PostDecrementAssign) {
				element.Operand.TryAccept(this, data);
				element.Operator.TryAccept(this, data);
			} else {
				element.Operator.TryAccept(this, data);
				element.Operand.TryAccept(this, data);
			}
			return true;
		}
	}
}