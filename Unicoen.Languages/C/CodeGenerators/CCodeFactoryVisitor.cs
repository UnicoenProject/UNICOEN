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

		// constructor
		protected CCodeFactoryVisitor(TextWriter writer) : this(writer, "\t") {}

		public CCodeFactoryVisitor(TextWriter writer, string indentSign) {
			Writer = writer;
			IndentSign = indentSign;
		}


		# region Decorations

		// UnifiedProgramはブロックを持っているが、プログラム全体は中括弧でくくらないため特別なDecorationを用いる
		protected static readonly Decoration ForTopBlock = new Decoration { EachRight = "\n" };
		
		// ブロック構文の開始と終了を示す中括弧とブロック内の各要素を区切る改行記号
		protected static readonly Decoration ForBlock = new Decoration { MostLeft = "{", EachRight = "\n", MostRight = "}" };
		
		// パラメータや実引数を表現するために使用される
		protected static readonly Decoration Paren = new Decoration { MostLeft = "(", Delimiter = ", ", MostRight = ")" };

		// 変数宣言を1行に書く際に使用される e.g. int a, b;
		protected static readonly Decoration CommaDelimiter = new Decoration { Delimiter = ", " };

		# endregion

		# region Utility Functions
		
		// 現在のインデントに応じた\tを出力します
		protected void WriteIndent(VisitorArgument arg) {
			WriteIndent(arg.IndentDepth);
		}

		protected void WriteIndent(int indentDepth) {
			for (var i = 0; i < indentDepth; i++)
				Writer.Write(IndentSign);
		}
		
		// 現在のインデントの深さを取得します
		protected string GetIndent(VisitorArgument arg) {
			return GetIndent(arg.IndentDepth);
		}

		protected string GetIndent(int indentDepth) {
			var ret = "";
			for (int i = 0; i < indentDepth; i++)
				ret += IndentSign;
			return ret;
		}

		// あるオブジェクトをファイルに出力する前に、別のStringWriterで取得しそのString値を返します
		// 例えば、int a, b;のようなコードは、統合コードオブジェクト上ではint a, int bとして保存されるが、
		// 出力の際には元のコードのように出力させるために用いられます
		protected string GetString(IUnifiedElement element, VisitorArgument arg) {
			var oldWriter = Writer;
			Writer = new StringWriter();
			element.TryAccept(this, arg);
			var ret = Writer.ToString();
			Writer = oldWriter;
			return ret;
		}

		# endregion
	}
}