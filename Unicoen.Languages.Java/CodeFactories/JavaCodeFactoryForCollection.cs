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
			}
			return "";
		}

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
				UnifiedParameterCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(Paren));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedModifierCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(SpaceDelimiter));
			return false;
		}

		// e.g. throws E1, E2 ...
		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		// e.g. {...}catch(Exception1 e1){...}catch{Exception2 e2}{....}... ?
		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCatchCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(NewLineDelimiter));
			return false;
		}

		// e.g. Foo<A, B> ?
		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeParameterCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(InequalitySignParen));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeConstrainCollection element, VisitorArgument arg) {
			UnifiedTypeConstrain last = null;
			for (int i = 0; i < element.Count; i++) {
				var current = element[i];
				var keyword = GetKeyword(current.Kind);
				if (last == null || last.Kind != current.Kind)
					arg.Write(" " + keyword + " ");
				else
					arg.Write(arg.Decoration.Delimiter);
				current.Type.TryAccept(this, arg);
				last = current;
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeSupplementCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(Empty));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIdentifierCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedArgumentCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedExpressionCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeArgumentCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(InequalitySignParen));
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
				UnifiedMatcherCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedKeyValueCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedAnnotation element, VisitorArgument arg) {
			arg.Write("@");
			element.Name.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(Paren));
			arg.WriteLine();
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedAnnotationCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedVariableDefinitionList element, VisitorArgument arg) {
			var klass = element.GrandParent() as UnifiedEnum;
			if (klass != null) {
				VisitCollection(element, arg.Set(CommaDelimiter));
			} else {
				VisitCollection(element, arg.Set(SemiColonDelimiter));
			}
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSimpleType element, VisitorArgument arg) {
			element.NameExpression.TryAccept(this, arg);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedList element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIterable element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedArray element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSet element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTuple element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public bool Visit(UnifiedIterableComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSetComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}
	}
}