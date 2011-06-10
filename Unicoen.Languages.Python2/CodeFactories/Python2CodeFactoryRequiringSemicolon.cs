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
using Unicoen.Core.Processor;

namespace Unicoen.Languages.Python2.CodeFactories {
	public partial class Python2CodeFactory {
		private static Tuple<string, string> GetRequiredParen(IUnifiedElement element) {
			var parent = element.Parent;
			if (parent is UnifiedUnaryExpression ||
			    parent is UnifiedBinaryExpression ||
			    parent is UnifiedTernaryExpression)
				return Tuple.Create("(", ")");
			return Tuple.Create("", "");
		}

		// e.g. (Int)a  or (int)(a + b)
		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCast element, VisitorArgument arg) {
			arg.Write("(");
			element.Type.TryAccept(this, arg);
			arg.Write(")");
			element.Expression.TryAccept(this, arg.Set(Paren));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTernaryExpression element, VisitorArgument arg) {
			var paren = GetRequiredParen(element);
			arg.Write(paren.Item1);
			element.Condition.TryAccept(this, arg.Set(Paren));
			arg.Write(" ? ");
			element.TrueExpression.TryAccept(this, arg.Set(Paren));
			arg.Write(" : ");
			element.FalseExpression.TryAccept(this, arg.Set(Paren));
			arg.Write(paren.Item2);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedImport element, VisitorArgument arg) {
			arg.Write("import ");
			element.Modifiers.TryAccept(this, arg);
			element.Name.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedBinaryExpression element, VisitorArgument arg) {
			var paren = GetRequiredParen(element);
			arg.Write(paren.Item1);
			element.LeftHandSide.TryAccept(this, arg.Set(Paren));
			arg.WriteSpace();
			element.Operator.TryAccept(this, arg);
			arg.WriteSpace();
			element.RightHandSide.TryAccept(this, arg.Set(Paren));
			arg.Write(paren.Item2);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSpecialExpression element, VisitorArgument arg) {
			if (element.Kind == UnifiedSpecialExpressionKind.StringConversion) {
				arg.Write("`");
				element.Value.TryAccept(this, arg);
				arg.Write("`");
				return false;
			}
			arg.Write(GetKeyword(element.Kind));
			if (element.Value != null) {
				arg.WriteSpace();
				element.Value.TryAccept(this, arg);
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCall element, VisitorArgument arg) {
			var prop = element.Function as UnifiedProperty;
			if (prop != null) {
				prop.Owner.TryAccept(this, arg);
				arg.Write(prop.Delimiter);
				element.TypeArguments.TryAccept(this, arg);
				prop.Name.TryAccept(this, arg);
			} else {
				// Javaでifが実行されるケースは存在しないが、言語変換のため
				if (element.TypeArguments != null)
					arg.Write("this.");
				element.TypeArguments.TryAccept(this, arg);
				element.Function.TryAccept(this, arg);
			}
			element.Arguments.TryAccept(this, arg.Set(Paren));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedNew element, VisitorArgument arg) {
			arg.Write("new ");
			element.TypeArguments.TryAccept(this, arg);
			element.Target.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(Paren));
			element.InitialValue.TryAccept(this, arg.Set(Bracket));
			element.Body.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedUnaryExpression element, VisitorArgument arg) {
			if (element.Operator.Kind == UnifiedUnaryOperatorKind.PostIncrementAssign ||
			    element.Operator.Kind == UnifiedUnaryOperatorKind.PostDecrementAssign) {
				element.Operand.TryAccept(this, arg.Set(Paren));
				element.Operator.TryAccept(this, arg);
			} else {
				element.Operator.TryAccept(this, arg);
				element.Operand.TryAccept(this, arg.Set(Paren));
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedProperty element, VisitorArgument arg) {
			element.Owner.TryAccept(this, arg);
			arg.Write(element.Delimiter);
			element.Name.TryAccept(this, arg);
			return false;
		}
	}
}