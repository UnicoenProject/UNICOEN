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
	public partial class Python2CodeFactoryVisitor {
		public override bool Visit(
				UnifiedParameterCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(Paren));
			return false;
		}

		public override bool Visit(
				UnifiedModifierCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(SpaceDelimiter));
			return false;
		}

		// e.g. throws E1, E2 ...
		public override bool Visit(UnifiedThrowsTypeCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		// e.g. {...}catch(Exception1 e1){...}catch{Exception2 e2}{....}... ?
		public override bool Visit(
				UnifiedCatchCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(NewLineDelimiter));
			return false;
		}

		// e.g. Foo<A, B> ?
		public override bool Visit(
				UnifiedGenericParameterCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(InequalitySignParen));
			return false;
		}

		public override bool Visit(
				UnifiedIdentifierCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(
				UnifiedArgumentCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(
				UnifiedExpressionCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(
				UnifiedGenericArgumentCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(InequalitySignParen));
			return false;
		}

		public override bool Visit(UnifiedCaseCollection element, VisitorArgument arg) {
			arg = arg.IncrementDepth();
			foreach (var caseElement in element) {
				WriteIndent(arg);
				caseElement.TryAccept(this, arg);
			}
			return false;
		}

		public override bool Visit(
				UnifiedMatcherCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(UnifiedAnnotation element, VisitorArgument arg) {
			Writer.Write("@");
			element.Name.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(Paren));
			Writer.WriteLine();
			return false;
		}

		public override bool Visit(
				UnifiedAnnotationCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(
				UnifiedVariableDefinitionList element, VisitorArgument arg) {
			var klass = element.GrandParent() as UnifiedEnum;
			if (klass != null) {
				VisitCollection(element, arg.Set(CommaDelimiter));
			} else {
				VisitCollection(element, arg.Set(SemiColonDelimiter));
			}
			return true;
		}

		public override bool Visit(UnifiedSimpleType element, VisitorArgument arg) {
			element.BasicType.TryAccept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedList element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(UnifiedIterable element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(UnifiedArray element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(UnifiedSet element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(UnifiedTuple element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(
				UnifiedIterableComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedSetComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedInterface element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedStruct element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedEnum element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedModule element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedUnion element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedAnnotationDefinition element, VisitorArgument arg) {
			throw new NotImplementedException();
		}
	}
}