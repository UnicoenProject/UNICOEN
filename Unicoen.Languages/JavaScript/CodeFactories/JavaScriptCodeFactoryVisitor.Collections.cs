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
	public partial class JavaScriptCodeFactoryVisitor {
		public override bool Visit(
				UnifiedArgumentCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(
				UnifiedParameterCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(Paren));
			return false;
		}

		public override bool Visit(
				UnifiedModifierCollection element, VisitorArgument arg) {
			//JavaScriptでは修飾子は出現しない
			return false;
		}

		public override bool Visit(
				UnifiedExpressionCollection element, VisitorArgument arg) {
			//現在は使用していない
			throw new InvalidOperationException();
		}

		public override bool Visit(UnifiedCaseCollection element, VisitorArgument arg) {
			arg = arg.IncrementDepth();
			foreach (var caseElement in element) {
				WriteIndent(arg);
				caseElement.TryAccept(this, arg);
			}
			return false;
		}

		public override bool Visit(UnifiedThrowsTypeCollection element, VisitorArgument arg) {
			//JavaScriptでは型の列挙は出現しない
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedGenericParameterCollection element, VisitorArgument arg) {
			//JavaScriptでは型パラメータは出現しない
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedIdentifierCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(CommaDelimiter));
			return false;
		}

		public override bool Visit(
				UnifiedMatcherCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(UnifiedAnnotation element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedAnnotationCollection element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedVariableDefinitionList element, VisitorArgument arg) {
			if (element.Parent.GetType() == typeof(UnifiedFor)) {
				Writer.Write("var ");
				VisitCollection(element, arg.Set(CommaDelimiter));
			} else {
				VisitCollection(element, arg.Set(SemiColonDelimiter));
			}
			return true;
		}

		public override bool Visit(
				UnifiedVariableDefinition element, VisitorArgument arg) {
			//for文の場合、varは１つしか記述できないため、collection側でvarを出力済み
			if (arg.Decoration.Delimiter != ", ")
				Writer.Write("var ");
			element.Name.TryAccept(this, arg);
			if (element.InitialValue != null) {
				Writer.Write(" = ");
				element.InitialValue.TryAccept(this, arg.Set(Bracket));
			}
			element.Arguments.TryAccept(this, arg.Set(Paren));
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedClassDefinition element, VisitorArgument arg) {
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return true;
		}
	}
}