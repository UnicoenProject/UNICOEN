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

using System.IO;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.CodeFactories {
	public abstract partial class JavaLikeCodeFactoryVisitor
			: ExplicitDefaultUnifiedVisitor<VisitorArgument, bool> {
		/// <summary>
		///   Expressionが括弧を付けるためのDecorationです
		/// </summary>
		protected static readonly Decoration Paren =
				new Decoration { MostLeft = "(", Delimiter = ", ", MostRight = ")" };

		protected static readonly Decoration Brace =
				new Decoration { MostLeft = "{", Delimiter = ", ", MostRight = "}" };

		protected static readonly Decoration Bracket =
				new Decoration { MostLeft = "[", Delimiter = ", ", MostRight = "]" };

		protected static readonly Decoration InequalitySignParen =
				new Decoration { MostLeft = "<", Delimiter = ", ", MostRight = ">" };

		protected static readonly Decoration Throws =
				new Decoration { MostLeft = "throws ", Delimiter = ", " };

		protected static readonly Decoration ColonMostLeft =
				new Decoration { MostLeft = ":" };

		protected static readonly Decoration NullDelimiter =
				new Decoration { Delimiter = null };

		protected static readonly Decoration AndDelimiter =
				new Decoration { Delimiter = " & " };

		protected static readonly Decoration CommaDelimiter =
				new Decoration { Delimiter = ", " };

		protected static readonly Decoration SpaceEachRight =
				new Decoration { EachRight = " " };

		protected static readonly Decoration NewLineDelimiter =
				new Decoration { Delimiter = "\n" };

		protected static readonly Decoration SemiColonDelimiter =
				new Decoration { Delimiter = ";" };

		protected static readonly Decoration ForBlock =
				new Decoration { MostLeft = "{", EachRight = "\n", MostRight = "}" };

		protected static readonly Decoration ForTopBlock =
				new Decoration { EachRight = "\n" };

		// 一時的に変化させることあり
		public TextWriter Writer { get; protected set; }
		protected string ForeachKeyword = "for";
		protected string ForeachDelimiter = " : ";
		protected string ImportKeyword = "import ";
		protected string IndentSign;

		protected JavaLikeCodeFactoryVisitor(TextWriter writer) : this(writer, "\t") {}

		protected JavaLikeCodeFactoryVisitor(TextWriter writer, string indentSign) {
			Writer = writer;
			IndentSign = indentSign;
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

		protected void WriteIndent(VisitorArgument arg) {
			WriteIndent(arg.IndentDepth);
		}

		protected string GetIndent(VisitorArgument arg) {
			return GetIndent(arg.IndentDepth);
		}

		protected void WriteIndent(int indentDepth) {
			for (int i = 0; i < indentDepth; i++)
				Writer.Write(IndentSign);
		}

		protected string GetIndent(int indentDepth) {
			var ret = "";
			for (int i = 0; i < indentDepth; i++)
				ret += IndentSign;
			return ret;
		}

		protected string GetString(IUnifiedElement element, VisitorArgument arg) {
			var oldWriter = Writer;
			Writer = new StringWriter();
			element.TryAccept(this, arg);
			var ret = Writer.ToString();
			Writer = oldWriter;
			return ret;
		}
			}
}