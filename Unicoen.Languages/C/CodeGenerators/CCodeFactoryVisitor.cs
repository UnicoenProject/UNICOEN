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
using System.IO;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Languages.C.CodeGenerators {
	public partial class CCodeFactoryVisitor : 
		ExplicitDefaultUnifiedVisitor<VisitorArgument, bool> {
		
		public TextWriter Writer { get; protected set; }
		protected string IndentSign;

		// Decorations
		protected static readonly Decoration ForTopBlock = new Decoration { EachRight = "\n" };
		
		protected static readonly Decoration ForBlock = new Decoration { MostLeft = "{", EachRight = "\n", MostRight = "}" };
		
		protected static readonly Decoration Paren = new Decoration { MostLeft = "(", Delimiter = ", ", MostRight = ")" };

		// constructor
		protected CCodeFactoryVisitor(TextWriter writer) : this(writer, "\t") {}

		public CCodeFactoryVisitor(TextWriter writer, string indentSign) {
			Writer = writer;
			IndentSign = indentSign;
		}

		// 出力汎用メソッド
		protected void WriteIndent(VisitorArgument arg) {
			WriteIndent(arg.IndentDepth);
		}

		protected void WriteIndent(int indentDepth) {
			for (var i = 0; i < indentDepth; i++)
				Writer.Write(IndentSign);
		}

		protected void VisitCollection<T, TSelf>(
				UnifiedElementCollection<T, TSelf> elements, VisitorArgument arg)
				where T : class, IUnifiedElement
				where TSelf : UnifiedElementCollection<T, TSelf> {
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

		// プログラム全体(UnifiedProgram)
		public override bool Visit(UnifiedProgram element, VisitorArgument arg) {
			// Console.Write(element);
			element.Body.TryAccept(this, arg.Set(ForTopBlock));
			return false;
		}
		// ブロック(UnifiedBlock)
		public override bool Visit(UnifiedBlock element, VisitorArgument arg) {
			// 要素の左端に記述すべきものがある場合はそれを出力する
			// プログラム全体の場合は何も出力しないが、関数の場合には中括弧が必要になるなど
			if (!string.IsNullOrEmpty(arg.Decoration.MostLeft)) {
				Writer.WriteLine(arg.Decoration.MostLeft);
				arg = arg.IncrementDepth();
			}

			// ブロック内の要素を列挙する
			// セミコロンが必要な要素の場合にはセミコロンを出力する
			foreach (var stmt in element) {
				WriteIndent(arg);
				if (stmt.TryAccept(this, arg))
					Writer.Write(";");
				Writer.Write(arg.Decoration.EachRight);
			}

			// 要素の右端に記述すべきものがある場合はインデントを元に戻しそれを出力する
			if (!string.IsNullOrEmpty(arg.Decoration.MostRight)) {
				arg = arg.DecrementDepth();
				WriteIndent(arg);
				Writer.WriteLine(arg.Decoration.MostRight);
			}
			return false;
		}
		// 関数定義(UnifiedFunctionDefinition)
		public override bool Visit(UnifiedFunctionDefinition element, VisitorArgument arg) {
			// int main(int param) { ... };
			element.Type.TryAccept(this, arg);
			Writer.Write(" ");
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return element.Body == null;
		}
		// 型(UnifiedBasicType)
		public override bool Visit(UnifiedBasicType element, VisitorArgument arg) {
			element.BasicTypeName.TryAccept(this, arg);
			return false;
		}
		// 変数名(UnifiedVariableIdentifier)
		public override bool Visit(UnifiedVariableIdentifier element, VisitorArgument arg) {
			Writer.Write(element.Name);
			return false;
		}
		// Rerurn文(UnifiedReturn)
		public override bool Visit(UnifiedReturn element, VisitorArgument arg) {
			Writer.Write("return ");
			element.Value.TryAccept(this, arg);
			return true;
		}
		// intリテラル(UnifiedInt32Literal)
		public override bool Visit(UnifiedInt32Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}
		// パラメータ(UnifiedParameterCollection)
		public override bool Visit(UnifiedParameterCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(Paren));
			return false;
		}
		// 関数呼び出し(UnifiedCall)
		public override bool Visit(UnifiedCall element, VisitorArgument arg) {
			var prop = element.Function as UnifiedProperty;
			if (prop != null) {
				prop.Owner.TryAccept(this, arg);
				Writer.Write(prop.Delimiter);
				element.GenericArguments.TryAccept(this, arg);
				prop.Name.TryAccept(this, arg);
			} else {
				// Javaでifが実行されるケースは存在しないが、言語変換のため
				if (element.GenericArguments != null)
					Writer.Write("this.");
				element.GenericArguments.TryAccept(this, arg);
				element.Function.TryAccept(this, arg);
			}
			element.Arguments.TryAccept(this, arg.Set(Paren));
			return true;
		}
		// 実引数(UnifiedArgumentCollection)
		public override bool Visit(UnifiedArgumentCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}
	}
}