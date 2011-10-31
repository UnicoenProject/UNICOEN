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
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Languages.JavaScript.CodeGenerators {
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

		//JavaScriptでは修飾子は出現しない
		public override bool Visit(
				UnifiedModifierCollection element, VisitorArgument arg) {
			return false;
		}
		
		//JavaScriptではジェネリックタイプは出現しない
		public override bool Visit(
				UnifiedGenericArgumentCollection element, VisitorArgument arg) {
			return false;
		}

		public override bool Visit(
				UnifiedCatchCollection element, VisitorArgument arg) {
			//TODO VisitCollection()に置き換えられるか確認

			Writer.Write(arg.Decoration.MostLeft);
			var delimiter = "";
			foreach (var e in element) {
				Writer.Write(delimiter);
				e.TryAccept(this, arg);
				delimiter = arg.Decoration.Delimiter;
			}
			Writer.Write(arg.Decoration.MostRight);
			return false;
		}

		//現在は使用されていない
		public override bool Visit(
				UnifiedExpressionCollection element, VisitorArgument arg) {
			throw new InvalidOperationException();
		}

		public override bool Visit(UnifiedCaseCollection element, VisitorArgument arg) {
			arg = arg.IncrementDepth();
			foreach (var caseElement in element) {
				WriteIndent(arg.IndentDepth);
				caseElement.TryAccept(this, arg);
			}
			return false;
		}

		//JavaScriptでは例外型の列挙は出現しない
		public override bool Visit(UnifiedTypeCollection element, VisitorArgument arg) {
			return false;
		}

		//JavaScriptでは型パラメータは出現しない
		public override bool Visit(
				UnifiedGenericParameterCollection element, VisitorArgument arg) {
			return false;
		}

		public override bool Visit(
				UnifiedIdentifierCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(CommaDelimiter));
			return false;
		}

		//JavaScriptではアノテーションは出現しない
		public override bool Visit(UnifiedAnnotation element, VisitorArgument arg) {
			return false;
		}

		public override bool Visit(
				UnifiedAnnotationCollection element, VisitorArgument arg) {
			return false;
		}
		
		//変数宣言リスト : e.g. var a = 1, b = 2;
		public override bool Visit(
				UnifiedVariableDefinitionList element, VisitorArgument arg) {
			//for文の初期条件内では変数宣言を分解して出力できないため、
			//あらかじめ'var'を出力しておいて各UnifiedVariableDefinitionでは'var'を出力しない
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
			//for文の場合'var'は１つしか記述できないため、UnifiedVariableDefinitionListで'var'を出力済み
			if (arg.Decoration.Delimiter != ", ")
				Writer.Write("var ");
			element.Name.TryAccept(this, arg);
			if (element.InitialValue != null) {
				Writer.Write(" = ");
				element.InitialValue.TryAccept(this, arg.Set(Brace));
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