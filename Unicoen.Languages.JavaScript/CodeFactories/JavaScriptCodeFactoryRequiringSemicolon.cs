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
				UnifiedCall element, VisitorState state) {
			//JavaScriptではTypeArgumentsが存在しない(?)
			var prop = element.Function as UnifiedProperty;
			if (prop != null) {
				prop.Owner.TryAccept(this, state);
				state.Writer.Write(prop.Delimiter);
				element.TypeArguments.TryAccept(this, state);
				prop.Name.TryAccept(this, state);
			} else {
				//TODO このif文が行っていることがわからない
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
			//e.g. var a = [1, 2, 3];
			if (element.InitialValue != null) {
				element.InitialValue.TryAccept(this, state.Set(Bracket));
				return true;
			}
			//e.g. var a = new X();
			state.Writer.Write("new ");
			element.Target.TryAccept(this, state);
			element.Arguments.TryAccept(this, state.Set(Paren));
			return true;
		}
	}
}