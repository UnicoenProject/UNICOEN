#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using Unicoen.Core.Model;
using Unicoen.Core.Visitors;
using Unicoen.Languages.Java.CodeFactories;

namespace Unicoen.Languages.C.CodeFactories {
	public partial class CCodeFactory {
		public static Tuple<string, string> GetRequiredParen(IUnifiedElement element) {
			var parent = element.Parent;
			if (parent is UnifiedBinaryExpression || parent is UnifiedUnaryExpression
			    || parent is UnifiedTernaryExpression) {
				return Tuple.Create("(", ")");
			}
			return Tuple.Create("", "");
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedBinaryExpression element, VisitorState state) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				DeprecatedUnifiedVariableDefinition element, VisitorState state) {
			element.Modifiers.TryAccept(this, state);
			state.WriteSpace();
			element.Type.TryAccept(this, state);
			state.WriteSpace();
			element.Bodys.TryAccept(this, state);

			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedUnaryExpression element, VisitorState state) {
			var paren = GetRequiredParen(element);
			state.Writer.Write(paren.Item1);

			var ope = element.Operator;
			switch (ope.Kind) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedSpecialExpression element, VisitorState state) {
			var keyword = GetKeyword(element.Kind);
			state.Writer.Write(keyword);
			state.WriteSpace();
			element.Value.TryAccept(this, state);

			return true;
		}

		// (int)a, (int)(a + b)
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCast element, VisitorState state) {
			state.Writer.Write("(");
			element.Type.TryAccept(this, state);
			state.Writer.Write(")");
			element.Expression.TryAccept(this, state.Set(Paren));

			return true;
		}

		// a ? b : c;
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTernaryExpression element, VisitorState state) {
			var paren = GetRequiredParen(element);

			state.Writer.Write(paren.Item1);
			element.Condition.TryAccept(this, state.Set(Paren));
			state.Writer.Write(" ? ");
			element.TrueExpression.TryAccept(this, state.Set(Paren));
			state.Writer.Write(" : ");
			element.FalseExpression.TryAccept(this, state.Set(Paren));

			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				DeprecatedUnifiedVariableDefinitionBody element, VisitorState state) {
			element.Name.TryAccept(this, state);
			if (element.InitialValue != null) {
				state.Writer.Write(" = ");
				element.InitialValue.TryAccept(this, state);
			}

			return true;
		}
	}
}