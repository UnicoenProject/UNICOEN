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

namespace Unicoen.Languages.JavaScript.CodeFactories {
	public partial class JavaScriptCodeFactory {
		private static Tuple<string, string> GetRequiredParen(IUnifiedElement element) {
			var parent = element.Parent;
			if (parent is UnifiedUnaryExpression ||
			    parent is UnifiedBinaryExpression ||
			    parent is UnifiedTernaryExpression)
				return Tuple.Create("(", ")");
			return Tuple.Create("", "");
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
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCall element, VisitorArgument arg) {
			//JavaScriptではTypeArgumentsが存在しない(?)
			var prop = element.Function as UnifiedProperty;
			if (prop != null) {
				prop.Owner.TryAccept(this, arg);
				arg.Write(prop.Delimiter);
				element.TypeArguments.TryAccept(this, arg);
				prop.Name.TryAccept(this, arg);
			} else {
				//TODO このif文が行っていることがわからない
				// Javaでifが実行されるケースは存在しないが、言語変換のため
				if (element.TypeArguments != null)
					arg.Write("this.");
				element.TypeArguments.TryAccept(this, arg);
				element.Function.TryAccept(this, arg);
			}
			element.Arguments.TryAccept(this, arg.Set(Paren));
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedNew element, VisitorArgument arg) {
			//e.g. var a = [1, 2, 3];
			if (element.InitialValue != null) {
				element.InitialValue.TryAccept(this, arg.Set(Bracket));
				return true;
			}
			//e.g. var a = new X();
			arg.Write("new ");
			element.Target.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(Paren));
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCast element, VisitorArgument arg) {
			arg.Write("(");
			element.Type.TryAccept(this, arg);
			arg.Write(")");
			element.Expression.TryAccept(this, arg.Set(Paren));
			return true;
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
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedBreak element, VisitorArgument arg) {
			arg.Write("break ");
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedContinue element, VisitorArgument arg) {
			arg.Write("continue ");
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedReturn element, VisitorArgument arg) {
			arg.Write("return ");
			element.Value.TryAccept(this, arg);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedGoto element, VisitorArgument arg) {
			arg.Write("goto ");
			element.Value.TryAccept(this, arg);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedYieldReturn element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDelete element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedThrow element, VisitorArgument arg) {
			arg.Write("throw ");
			element.Value.TryAccept(this, arg);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedAssert element, VisitorArgument arg) {
			arg.Write("assert(");
			element.Value.TryAccept(this, arg);
			arg.Write(")");
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedExec element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedStringConversion element, VisitorArgument data) {
			throw new NotImplementedException();
		}
	}
}