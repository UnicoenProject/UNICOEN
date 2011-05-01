using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;
using Unicoen.Core.Visitors;

namespace Unicoen.Languages.C.CodeFactories
{
	public partial class CCodeFactory
	{
		public static Tuple<string, string> GetRequiredParen(IUnifiedElement element)
		{
			var parent = element.Parent;
			if (parent is UnifiedBinaryExpression || parent is UnifiedUnaryExpression || parent is UnifiedTernaryExpression)
			{
				return Tuple.Create("(", ")");
			}
			return Tuple.Create("", "");
		}

		private static Tuple<string, string> GetKeyword(UnifiedTernaryOperatorKind kind)
		{
			switch (kind)
			{
				case UnifiedTernaryOperatorKind.Conditional:
					return Tuple.Create("?", ":");
				default:
					throw new ArgumentException("kind");
			}

		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedBinaryExpression element, VisitorState state)
		{
			var paren = GetRequiredParen(element);
			state.Writer.Write(paren.Item1);
			element.LeftHandSide.TryAccept(this, state);
			state.WriteSpace();
			element.Operator.TryAccept(this, state);
			state.WriteSpace();
			element.RightHandSide.TryAccept(this, state);
			state.Writer.Write(paren.Item2);

			return true;
		}


		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedVariableDefinition element, VisitorState state)
		{
			element.Modifiers.TryAccept(this, state);
			state.WriteSpace();
			element.Type.TryAccept(this, state);
			state.WriteSpace();
			element.Bodys.TryAccept(this, state);

			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedUnaryExpression element, VisitorState state)
		{
			var paren = GetRequiredParen(element);
			state.Writer.Write(paren.Item1);

			var ope = element.Operator;
			switch (ope.Kind)
			{
				case UnifiedUnaryOperatorKind.PostDecrementAssign:
				case UnifiedUnaryOperatorKind.PostIncrementAssign:
					element.Operand.TryAccept(this, state);
					ope.TryAccept(this, state);
					break;
				default:
					ope.TryAccept(this, state);
					element.Operand.TryAccept(this, state);
					break;
			}

			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedSpecialExpression element, VisitorState state)
		{
			var keyword = GetKeyword(element.Kind);
			state.Writer.Write(keyword);
			state.WriteSpace();
			element.Value.TryAccept(this, state);

			return true;

		}

		// (int)a, (int)(a + b)
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCast element, VisitorState state)
		{
			state.Writer.Write("(");
			element.Type.TryAccept(this, state);
			state.Writer.Write(")");
			element.Expression.TryAccept(this, state.Set(Paren));

			return true;
		}

		// a ? b : c;
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTernaryExpression element, VisitorState state)
		{
			var paren = GetRequiredParen(element);
			var keywords = GetKeyword(element.Operator.Kind);

			state.Writer.Write(paren.Item1);
			element.FirstExpression.TryAccept(this, state.Set(Paren));
			state.Writer.Write(" " + keywords.Item1 + " ");
			element.SecondExpression.TryAccept(this, state.Set(Paren));
			state.Writer.Write(" " + keywords.Item2 + " ");
			element.LastExpression.TryAccept(this, state.Set(Paren));

			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedVariableDefinitionBody element, VisitorState state)
		{
			element.Name.TryAccept(this, state);
			if (element.InitialValue != null)
			{
				state.Writer.Write(" = ");
				element.InitialValue.TryAccept(this, state);
			}

			return true;
		}




	}
}
