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
	public partial class CCodeFactory {
		public void VisitCollection<T, TSelf>(
				UnifiedElementCollection<T, TSelf> elements, VisitorArgument arg)
				where T : class, IUnifiedElement
				where TSelf : UnifiedElementCollection<T, TSelf> {
			var decoration = arg.Decoration;
			arg.Write(decoration.MostLeft);
			var splitter = "";
			foreach (var e in elements) {
				arg.Write(splitter);
				arg.Write(decoration.EachLeft);
				e.TryAccept(this, arg);
				arg.Write(decoration.EachRight);
				splitter = decoration.Delimiter;
			}
			arg.Write(decoration.MostRight);
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedArgumentCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedParameterCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(Paren));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedModifierCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(SpaceDelimiter));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedExpressionCollection element, VisitorArgument arg) {
			throw new InvalidOperationException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeArgumentCollection element, VisitorArgument arg) {
			arg.WriteLine("/* ElementNotInC */");
			arg.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCaseCollection element, VisitorArgument arg) {
			arg = arg.IncrementDepth();
			foreach (var caseElement in element) {
				arg.WriteIndent();
				caseElement.TryAccept(this, arg);
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeCollection element, VisitorArgument arg) {
			arg.WriteLine("/* ElementNotInC */");
			arg.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCatchCollection element, VisitorArgument arg) {
			arg.WriteLine("/* ElementNotInC */");
			arg.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeParameterCollection element, VisitorArgument arg) {
			arg.WriteLine("/* ElementNotInC */");
			arg.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeConstrainCollection element, VisitorArgument arg) {
			arg.WriteLine("/* ElementNotInC */");
			arg.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeSupplementCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(Empty));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIdentifierCollection element, VisitorArgument arg) {
			throw new InvalidOperationException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedMatcher element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedMatcherCollection element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedUsing element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedListComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedList element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedKeyValue element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDictionaryComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedKeyValueCollection element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDictonary element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSlice element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedComment element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedAnnotation element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedAnnotationCollection element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedVariableDefinitionList element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedVariableDefinition element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSupplementType element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedGenericType element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSimpleType element, VisitorArgument arg) {
			element.NameExpression.TryAccept(this, arg);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(UnifiedIterable element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(UnifiedArray element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(UnifiedSet element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(UnifiedTuple element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedIterableComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSetComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedInterface element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedClass element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedStruct element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedEnum element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedModule element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedUnion element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedAnnotationDefinition element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedArrayType element, VisitorArgument arg) {
			throw new NotImplementedException();
		}
	}
}