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

namespace Unicoen.Languages.Java.CodeFactories {
	public partial class JavaCodeFactory {
		private static Tuple<string, string> GetRequiredParen(IUnifiedElement element) {
			var parent = element.Parent;
			if (parent is UnifiedUnaryExpression ||
			    parent is UnifiedBinaryExpression ||
			    parent is UnifiedTernaryExpression)
				return Tuple.Create("(", ")");
			return Tuple.Create("", "");
		}

		// e.g. (Int)a  or (int)(a + b)
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCast element, VisitorState state) {
			state.Writer.Write("(");
			element.Type.TryAccept(this, state);
			state.Writer.Write(")");
			element.Expression.TryAccept(this, state.Set(Paren));
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTernaryExpression element, VisitorState state) {
			var paren = GetRequiredParen(element);
			state.Writer.Write(paren.Item1);
			element.Condition.TryAccept(this, state.Set(Paren));
			state.Writer.Write(" ? ");
			element.TrueExpression.TryAccept(this, state.Set(Paren));
			state.Writer.Write(" : ");
			element.FalseExpression.TryAccept(this, state.Set(Paren));
			state.Writer.Write(paren.Item2);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedImport element, VisitorState state) {
			state.Writer.Write("import ");
			element.Modifiers.TryAccept(this, state);
			element.Name.TryAccept(this, state);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedBinaryExpression element, VisitorState state) {
			var paren = GetRequiredParen(element);
			state.Writer.Write(paren.Item1);
			element.LeftHandSide.TryAccept(this, state.Set(Paren));
			state.WriteSpace();
			element.Operator.TryAccept(this, state);
			state.WriteSpace();
			element.RightHandSide.TryAccept(this, state.Set(Paren));
			state.Writer.Write(paren.Item2);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedSpecialExpression element, VisitorState state) {
			state.Writer.Write(GetKeyword(element.Kind));
			if (element.Value != null) {
				state.WriteSpace();
				element.Value.TryAccept(this, state);
			}
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCall element, VisitorState state) {
			var prop = element.Function as UnifiedProperty;
			if (prop != null) {
				prop.Owner.TryAccept(this, state);
				state.Writer.Write(prop.Delimiter);
				element.TypeArguments.TryAccept(this, state);
				prop.Name.TryAccept(this, state);
			} else {
				// Javaでifが実行されるケースは存在しないが、言語変換のため
				if (element.TypeArguments != null)
					state.Writer.Write("this.");
				element.TypeArguments.TryAccept(this, state);
				element.Function.TryAccept(this, state);
			}
			element.Arguments.TryAccept(this, state.Set(Paren));
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedNew element, VisitorState state) {
			state.Writer.Write("new ");
			element.TypeArguments.TryAccept(this, state);
			element.Target.TryAccept(this, state);
			element.Arguments.TryAccept(this, state.Set(Paren));
			element.InitialValue.TryAccept(this, state.Set(Bracket));
			element.Body.TryAccept(this, state);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedUnaryExpression element, VisitorState state) {
			if (element.Operator.Kind == UnifiedUnaryOperatorKind.PostIncrementAssign ||
			    element.Operator.Kind == UnifiedUnaryOperatorKind.PostDecrementAssign) {
				element.Operand.TryAccept(this, state.Set(Paren));
				element.Operator.TryAccept(this, state);
			} else {
				element.Operator.TryAccept(this, state);
				element.Operand.TryAccept(this, state.Set(Paren));
			}
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedProperty element, VisitorState state) {
			element.Owner.TryAccept(this, state);
			state.Writer.Write(element.Delimiter);
			element.Name.TryAccept(this, state);
			return true;
		}
	}
}