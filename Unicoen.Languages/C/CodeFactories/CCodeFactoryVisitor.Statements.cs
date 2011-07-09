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

namespace Unicoen.Languages.C.CodeFactories {
	public partial class CCodeFactoryVisitor {
		public static Tuple<string, string> GetRequiredParen(IUnifiedElement element) {
			var parent = element.Parent;
			if (parent is UnifiedBinaryExpression || parent is UnifiedUnaryExpression
			    || parent is UnifiedTernaryExpression) {
				return Tuple.Create("(", ")");
			}
			return Tuple.Create("", "");
		}

		public override bool Visit(
				UnifiedBinaryExpression element, VisitorArgument arg) {
			var paren = GetRequiredParen(element);
			arg.Write(paren.Item1);
			element.LeftHandSide.TryAccept(this, arg);
			arg.WriteSpace();
			element.Operator.TryAccept(this, arg);
			arg.WriteSpace();
			element.RightHandSide.TryAccept(this, arg);
			arg.Write(paren.Item2);

			return true;
		}

		public override bool Visit(
				UnifiedUnaryExpression element, VisitorArgument arg) {
			var paren = GetRequiredParen(element);
			arg.Write(paren.Item1);

			var ope = element.Operator;
			switch (ope.Kind) {
			case UnifiedUnaryOperatorKind.PostDecrementAssign:
			case UnifiedUnaryOperatorKind.PostIncrementAssign:
				element.Operand.TryAccept(this, arg);
				ope.TryAccept(this, arg);
				break;
			default:
				ope.TryAccept(this, arg);
				element.Operand.TryAccept(this, arg);
				break;
			}

			return true;
		}

		// (int)a, (int)(a + b)
		public override bool Visit(UnifiedCast element, VisitorArgument arg) {
			arg.Write("(");
			element.Type.TryAccept(this, arg);
			arg.Write(")");
			element.Expression.TryAccept(this, arg.Set(Paren));

			return true;
		}

		// a ? b : c;
		public override bool Visit(
				UnifiedTernaryExpression element, VisitorArgument arg) {
			var paren = GetRequiredParen(element);

			arg.Write(paren.Item1);
			element.Condition.TryAccept(this, arg.Set(Paren));
			arg.Write(" ? ");
			element.TrueExpression.TryAccept(this, arg.Set(Paren));
			arg.Write(" : ");
			element.FalseExpression.TryAccept(this, arg.Set(Paren));

			return true;
		}

		public override bool Visit(UnifiedBreak element, VisitorArgument arg) {
			arg.Write("break");
			return true;
		}

		public override bool Visit(UnifiedContinue element, VisitorArgument arg) {
			arg.Write("continue");
			return true;
		}

		public override bool Visit(UnifiedReturn element, VisitorArgument arg) {
			arg.Write("return");
			element.Value.TryAccept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedGoto element, VisitorArgument arg) {
			arg.Write("goto");
			element.Value.TryAccept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedYieldReturn element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedDelete element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedThrow element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedAssert element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedExec element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedStringConversion element, VisitorArgument data) {
			throw new NotImplementedException();
		}
	}
}