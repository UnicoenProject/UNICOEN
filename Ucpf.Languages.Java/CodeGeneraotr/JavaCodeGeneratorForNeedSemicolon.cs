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
			element.Type.Accept(this, data);
			_writer.Write(")");
			_writer.Write("(");
			expression.Accept(this, data);
			_writer.Write(")");
			return true;
		}

		public bool Visit(UnifiedTernaryExpression element, TokenInfo data)
		{
			element.FirstExpression.Accept(this, data);
			WriteSpace();
			element.SecondExpression.Accept(this, data);
			WriteSpace();
			element.LastExpression.Accept(this, data);
			return true;
		}

		public bool Visit(UnifiedImport element, TokenInfo data)
		{
			_writer.Write("import ");
			element.Name.Accept(this, data);
			return true;
		}

		public bool Visit(UnifiedBinaryExpression element, TokenInfo data)
		{
			_writer.Write("(");
			element.LeftHandSide.Accept(this, data);
			element.Operator.Accept(this, data);
			element.RightHandSide.Accept(this, data);
			_writer.Write(")");
			return true;
		}

		public bool Visit(UnifiedSpecialExpression element, TokenInfo data)
		{
			_writer.Write(GetKeyword(element.Kind));
			if (element.Value != null) {
				WriteSpace();
				element.Value.Accept(this, data);
			}
			return true;
		}

		public bool Visit(UnifiedCall element, TokenInfo data)
		{
			element.Function.Accept(this, data);
			element.Arguments.Accept(this,
				new TokenInfo { MostLeft = "(", Delimiter = ", ", MostRight = ")" });
			return true;
		}

		// e.g. int a = 5
		public bool Visit(UnifiedVariableDefinition element, TokenInfo data)
		{
			element.Modifiers.Accept(this, data);
			WriteSpace();
			element.Type.Accept(this, data);
			WriteSpace();
			element.Bodys.Accept(this, data);
			return true;
		}

		public bool Visit(UnifiedNew element, TokenInfo data)
		{
			_writer.Write("new ");
			element.Type.Accept(this, data);
			element.Arguments.TryAccept(this,
				new TokenInfo { MostLeft = "(", Delimiter = ", ", MostRight = ")" });
			element.Body.TryAccept(this, data);
			return true;
		}

		public bool Visit(UnifiedUnaryExpression element, TokenInfo data)
		{
			if (element.Operator.Kind == UnifiedUnaryOperatorKind.PostIncrementAssign ||
			    element.Operator.Kind == UnifiedUnaryOperatorKind.PostDecrementAssign) {
				element.Operand.Accept(this, data);
				element.Operator.Accept(this, data);
			} else {
				element.Operator.Accept(this, data);
				element.Operand.Accept(this, data);
			}
			return true;
		}
	}
}