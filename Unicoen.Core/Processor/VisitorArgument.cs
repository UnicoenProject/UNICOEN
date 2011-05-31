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

namespace Unicoen.Core.Processor {
	public class VisitorArgument {
		private readonly TextWriter _writer;

		public string IndentSign { get; private set; }
		public int IndentDepth { get; private set; }
		public Decoration Decoration { get; private set; }

		public VisitorArgument(TextWriter writer, string indentSign) {
			_writer = writer;
			IndentSign = indentSign;
			Decoration = new Decoration();
		}

		public VisitorArgument Set(Decoration decoration) {
			return new VisitorArgument(_writer, IndentSign) {
					Decoration = decoration,
					IndentDepth = IndentDepth,
			};
		}

		public VisitorArgument IncrementIndentDepth() {
			return new VisitorArgument(_writer, IndentSign) {
					Decoration = Decoration,
					IndentDepth = IndentDepth + 1,
			};
		}

		public void WriteIndent() {
			for (int i = 0; i < IndentDepth; i++)
				_writer.Write(IndentSign);
		}

		public void WriteSpace() {
			_writer.Write(" ");
		}

		#region Delegate Methods
		public void WriteLine(string format, params object[] arg) {
			_writer.WriteLine(format, arg);
		}

		public void WriteLine(string format, object arg0, object arg1, object arg2) {
			_writer.WriteLine(format, arg0, arg1, arg2);
		}

		public void WriteLine(string format, object arg0, object arg1) {
			_writer.WriteLine(format, arg0, arg1);
		}

		public void WriteLine(string format, object arg0) {
			_writer.WriteLine(format, arg0);
		}

		public void WriteLine(object value) {
			_writer.WriteLine(value);
		}

		public void WriteLine(string value) {
			_writer.WriteLine(value);
		}

		public void WriteLine(decimal value) {
			_writer.WriteLine(value);
		}

		public void WriteLine(double value) {
			_writer.WriteLine(value);
		}

		public void WriteLine(float value) {
			_writer.WriteLine(value);
		}

		public void WriteLine(ulong value) {
			_writer.WriteLine(value);
		}

		public void WriteLine(long value) {
			_writer.WriteLine(value);
		}

		public void WriteLine(uint value) {
			_writer.WriteLine(value);
		}

		public void WriteLine(int value) {
			_writer.WriteLine(value);
		}

		public void WriteLine(bool value) {
			_writer.WriteLine(value);
		}

		public void WriteLine(char[] buffer, int index, int count) {
			_writer.WriteLine(buffer, index, count);
		}

		public void WriteLine(char[] buffer) {
			_writer.WriteLine(buffer);
		}

		public void WriteLine(char value) {
			_writer.WriteLine(value);
		}

		public void WriteLine() {
			_writer.WriteLine();
		}

		public void Write(string format, params object[] arg) {
			_writer.Write(format, arg);
		}

		public void Write(string format, object arg0, object arg1, object arg2) {
			_writer.Write(format, arg0, arg1, arg2);
		}

		public void Write(string format, object arg0, object arg1) {
			_writer.Write(format, arg0, arg1);
		}

		public void Write(string format, object arg0) {
			_writer.Write(format, arg0);
		}

		public void Write(object value) {
			_writer.Write(value);
		}

		public void Write(string value) {
			_writer.Write(value);
		}

		public void Write(decimal value) {
			_writer.Write(value);
		}

		public void Write(double value) {
			_writer.Write(value);
		}

		public void Write(float value) {
			_writer.Write(value);
		}

		public void Write(ulong value) {
			_writer.Write(value);
		}

		public void Write(long value) {
			_writer.Write(value);
		}

		public void Write(uint value) {
			_writer.Write(value);
		}

		public void Write(int value) {
			_writer.Write(value);
		}

		public void Write(bool value) {
			_writer.Write(value);
		}

		public void Write(char[] buffer, int index, int count) {
			_writer.Write(buffer, index, count);
		}

		public void Write(char[] buffer) {
			_writer.Write(buffer);
		}

		public void Write(char value) {
			_writer.Write(value);
		}
		#endregion
	}
}