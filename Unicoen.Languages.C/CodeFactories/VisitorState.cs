using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Unicoen.Languages.C.CodeFactories
{
	public class VisitorState
	{
		public TextWriter Writer { get; private set; }
		public string IndentSign { get; private set; }
		public int IndentDepth { get; private set; }
		public Decoration Decoration { get; private set; }

		public VisitorState(TextWriter writer, string indentSign) {
			Writer = writer;
			IndentSign = indentSign;
			Decoration = new Decoration();
		}

		public VisitorState Set(Decoration decoration) {
			return new VisitorState(Writer, IndentSign) {
				Decoration = decoration,
				IndentDepth = IndentDepth,
			};
		}

		public VisitorState IncrementIndentDepth() {
			return new VisitorState(Writer, IndentSign) {
				Decoration = Decoration,
				IndentDepth = IndentDepth + 1,
			};
		}

		public void WriteIndent() {
			for (int i = 0; i < IndentDepth; i++)
				Writer.Write(IndentSign);
		}

		public void WriteSpace() {
			Writer.Write(" ");
		}

	}
}
