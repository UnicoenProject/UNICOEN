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
		public void VisitCollection<T, TSelf>(
				UnifiedElementCollection<T, TSelf> elements, VisitorState state)
				where T : class, IUnifiedElement
				where TSelf : UnifiedElementCollection<T, TSelf> {
			var decoration = state.Decoration;
			state.Writer.Write(decoration.MostLeft);
			var splitter = "";
			foreach (var e in elements) {
				state.Writer.Write(splitter);
				state.Writer.Write(decoration.EachLeft);
				e.TryAccept(this, state);
				state.Writer.Write(decoration.EachRight);
				splitter = decoration.Delimiter;
			}
			state.Writer.Write(decoration.MostRight);
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedArgumentCollection element, VisitorState state) {
			VisitCollection(element, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedParameterCollection element, VisitorState state) {
			VisitCollection(element, state.Set(Paren));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedModifierCollection element, VisitorState state) {
			//JavaScriptでは修飾子は出現しない
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedExpressionCollection element, VisitorState state) {
			//現在は使用していない
			throw new InvalidOperationException();
		}
	}
}