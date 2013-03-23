#region License

// Copyright (C) 2011-2012 The Unicoen Project
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

using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Languages.C.CodeGenerators {
	// CCodeFactoryVisitorのうち、コレクションに関する処理を行います
	public partial class CCodeFactoryVisitor {
		// コレクションオブジェクトをファイルに出力するための共通な処理を提供します
		protected void VisitCollection<T>(
				IUnifiedElementCollection<T> elements, VisitorArgument arg)
				where T : UnifiedElement {
			var decoration = arg.Decoration;
			Writer.Write(decoration.MostLeft);
			var splitter = "";
			foreach (var e in elements) {
				Writer.Write(splitter);
				Writer.Write(decoration.EachLeft);
				e.TryAccept(this, arg);
				Writer.Write(decoration.EachRight);
				splitter = decoration.Delimiter;
			}
			Writer.Write(decoration.MostRight);
		}

		// 修飾子(UnifiedSet<UnifiedModifier>)
		public override bool Visit(
				UnifiedSet<UnifiedModifier> element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		// 実引数(UnifiedSet<UnifiedArgument>)
		public override bool Visit(
				UnifiedSet<UnifiedArgument> element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		// パラメータ(UnifiedSet<UnifiedParameter>)
		public override bool Visit(
				UnifiedSet<UnifiedParameter> element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(Paren));
			return false;
		}

		// パラメータ名(UnifiedSet<UnifiedIdentifier>)
		// Python向けにパラメータは複数の識別子を保持できるようになっているが、
		// C言語ではUnifiedSet<UnifiedIdentifier>が持つ要素は1つのみである
		public override bool Visit(
				UnifiedSet<UnifiedIdentifier> element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		// Case文(UnifiedSet<UnifiedCase>)
		public override bool Visit(
				UnifiedSet<UnifiedCase> element, VisitorArgument arg) {
			arg = arg.IncrementDepth();
			foreach (var caseElement in element) {
				WriteIndent(arg.IndentDepth);
				caseElement.TryAccept(this, arg);
				Writer.Write("\n");
			}
			return false;
		}

		// 変数定義(UnifiedVariableDefinitionList)
		public override bool Visit(
				UnifiedVariableDefinitionList element, VisitorArgument arg) {
			// enumとしての変数宣言リストの場合
			// e.g. enum { RED, BLUE, YELLOW }のRED, BLUE, YELLOW
			if (element.GrandParent() is UnifiedEnumDefinition) {
				var comma = "";
				foreach (var e in element) {
					Writer.Write(comma);
					e.Name.TryAccept(this, arg);
					if (e.InitialValue != null) {
						Writer.Write(" = ");
						e.InitialValue.TryAccept(this, arg);
					}
					comma = ", ";
				}
				return false;
			}

			// 通常の変数宣言リストの場合
			// 変数宣言を1つにまとめて出力する
			// e.g. int a, b[];

			/*
			 * 統合コードオブジェクト上では、int a, b[]のような変数宣言は
			 * int aとint[] bの2つの変数宣言に分割してオブジェクト化されている。
			 * これらを再度1つの変数宣言式として出力するために、最初の変数宣言のみ型を出力し、
			 * 以降では最初の変数宣言の型(commonTypeStr)と異なる場合のみ、その型の差分を出力する
			 */
			var commonTypeStr = "";
			var isFirst = true;
			foreach (var e in element) {
				if (isFirst) {
					e.Modifiers.TryAccept(this, arg);
					// TODO なぜか修飾子の後で改行される問題を調査する
					commonTypeStr = GetString(e.Type, arg);
					Writer.Write(commonTypeStr + " ");
					e.Name.TryAccept(this, arg);
					isFirst = false;
				} else {
					Writer.Write(", ");
					e.Name.TryAccept(this, arg);
					Writer.Write(
							GetString(e.Type, arg).Substring(
									commonTypeStr.Length));
				}

				// 初期化子がある場合にはそれを出力する
				if (e.InitialValue != null) {
					Writer.Write(" = ");
					e.InitialValue.TryAccept(this, arg);
				}
			}
			return true;
		}
	}
}