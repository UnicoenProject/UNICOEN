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
		private static string GetKeyword(UnifiedTypeConstrainKind kind) {
			switch (kind) {
			case UnifiedTypeConstrainKind.Extends:
			case UnifiedTypeConstrainKind.ExtendsOrImplements:
				return "extends";
			case UnifiedTypeConstrainKind.Implements:
				return "implements";
			case UnifiedTypeConstrainKind.Super:
				return "super";
			default:
				break;
			}
			return "";
		}

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
				UnifiedParameterCollection element, VisitorState state) {
			VisitCollection(element, state.Set(Paren));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedModifierCollection element, VisitorState state) {
			VisitCollection(element, state.Set(SpaceDelimiter));
			return false;
		}

		// e.g. throws E1, E2 ...
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeCollection element, VisitorState state) {
			VisitCollection(element, state);
			return false;
		}

		// e.g. {...}catch(Exception1 e1){...}catch{Exception2 e2}{....}... ?
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCatchCollection element, VisitorState state) {
			VisitCollection(element, state.Set(NewLineDelimiter));
			return false;
		}

		// e.g. Foo<A, B> ?
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeParameterCollection element, VisitorState state) {
			VisitCollection(element, state.Set(InequalitySignParen));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeConstrainCollection element, VisitorState state) {
			UnifiedTypeConstrain last = null;
			for (int i = 0; i < element.Count; i++) {
				var current = element[i];
				var keyword = GetKeyword(current.Kind);
				if (last == null || last.Kind != current.Kind)
					state.Writer.Write(" " + keyword + " ");
				else
					state.Writer.Write(state.Decoration.Delimiter);
				current.Type.TryAccept(this, state);
				last = current;
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeSupplementCollection element, VisitorState state) {
			VisitCollection(element, state.Set(Empty));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedVariableDefinitionBodyCollection element,
				VisitorState state) {
			VisitCollection(element, state.Set(CommaDelimiter));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIdentifierCollection element, VisitorState state) {
			throw new InvalidOperationException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedArgumentCollection element, VisitorState state) {
			VisitCollection(element, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedExpressionCollection element, VisitorState state) {
			throw new InvalidOperationException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeArgumentCollection element, VisitorState state) {
			VisitCollection(element, state.Set(InequalitySignParen));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCaseCollection element, VisitorState state) {
			state = state.IncrementIndentDepth();
			foreach (var caseElement in element) {
				state.WriteIndent();
				caseElement.TryAccept(this, state);
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedExpressionList element, VisitorState state) {
			VisitCollection(element, state);
			return false;
		}

		public bool Visit(UnifiedMatcherCollection element, VisitorState state) {
			VisitCollection(element, state);
			return false;
		}

		public bool Visit(UnifiedListComprehension element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedIfExpression element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSlice element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedComment element, VisitorState state) {
			throw new NotImplementedException();
		}
	}
}