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

namespace Unicoen.Languages.Java.CodeFactories {
	public class VisitorState {
		public TextWriter Writer { get; set; }
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

		public void Write(string text) {
			Writer.Write(text);
		}

		public void WriteLine() {
			Writer.WriteLine();
		}

		public void WriteLine(string text) {
			Writer.WriteLine(text);
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