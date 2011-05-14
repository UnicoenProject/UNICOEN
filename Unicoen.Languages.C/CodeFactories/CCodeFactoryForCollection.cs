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
			VisitCollection(element, state.Set(SpaceDelimiter));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedExpressionCollection element, VisitorState state) {
			throw new InvalidOperationException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeArgumentCollection element, VisitorState state) {
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element + " */");
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
				UnifiedTypeCollection element, VisitorState state) {
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCatchCollection element, VisitorState state) {
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeParameterCollection element, VisitorState state) {
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeConstrainCollection element, VisitorState state) {
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeSupplementCollection element, VisitorState state) {
			VisitCollection(element, state.Set(Empty));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedVariableDefinitionBodyCollection element, VisitorState state) {
			VisitCollection(element, state.Set(CommaDelimiter));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIdentifierCollection element, VisitorState state) {
			throw new InvalidOperationException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedExpressionList element, VisitorState state) {
			VisitCollection(element, state);

			return false;
		}

		public bool Visit(UnifiedMatcher element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedMatcherCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedUsing element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedListComprehension element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedList element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedKeyValue element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedDictionaryComprehension element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedKeyValueCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedDictonary element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSlice element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedComment element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedAnnotation element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedAnnotationCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedVariableDefinitionList element, VisitorState state) {
			throw new NotImplementedException();
		}
	}
}
