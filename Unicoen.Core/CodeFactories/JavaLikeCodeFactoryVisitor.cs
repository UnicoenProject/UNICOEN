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

		protected static readonly Decoration Bracket =
				new Decoration { MostLeft = "{", Delimiter = ", ", MostRight = "}" };

		protected static readonly Decoration SquareBracket =
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
		protected TextWriter Writer;
		protected string ForeachKeyword = "for";
		protected string ForeachDelimiter = " : ";

		protected JavaLikeCodeFactoryVisitor(TextWriter writer) {
			Writer = writer;
		}

		protected void WriteIndent(VisitorArgument arg) {
			for (int i = 0; i < arg.IndentDepth; i++)
				Writer.Write(arg.IndentSign);
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