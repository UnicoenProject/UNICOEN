﻿using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace Unicoen {
	[Serializable]
	public struct CodePosition : IEquatable<CodePosition> {
		public int EndLine;
		public int EndPos;
		public int StartLine;
		public int StartPos;

		public CodePosition(int startLine, int endLine, int startPos, int endPos) {
			Contract.Requires(startLine <= endLine);
			StartLine = startLine;
			StartPos = startPos;
			EndLine = endLine;
			EndPos = endPos;
		}

		public string Line {
			get { return StartLine + " - " + EndLine; }
		}

		public string Position {
			get { return StartPos + " - " + EndPos; }
		}

		public string SmartLine {
			get {
				return StartLine == EndLine
				       	? StartLine.ToString() : (StartLine + " - " + EndLine);
			}
		}

		public string SmartPosition {
			get {
				return StartPos == EndPos
				       	? StartPos.ToString() : (StartPos + " - " + EndPos);
			}
		}

		#region IEquatable<CodePosition> Members

		public bool Equals(CodePosition other) {
			return other.EndLine == EndLine && other.EndPos == EndPos &&
			       other.StartLine == StartLine && other.StartPos == StartPos;
		}

		#endregion

		public override bool Equals(object obj) {
			if (ReferenceEquals(null, obj)) return false;
			if (obj.GetType() != typeof(CodePosition)) return false;
			return Equals((CodePosition)obj);
		}

		public override int GetHashCode() {
			unchecked {
				int result = EndLine;
				result = (result * 397) ^ EndPos;
				result = (result * 397) ^ StartLine;
				result = (result * 397) ^ StartPos;
				return result;
			}
		}

		public static bool operator ==(CodePosition left, CodePosition right) {
			return left.Equals(right);
		}

		public static bool operator !=(CodePosition left, CodePosition right) {
			return !left.Equals(right);
		}

		public override string ToString() {
			return "Line: " + SmartLine + ", Pos: " + SmartPosition;
		}

		public static CodePosition Read(BinaryReader reader) {
			var startLine = reader.ReadInt32();
			var endLine = reader.ReadInt32();
			var startPos = reader.ReadInt32();
			var endPos = reader.ReadInt32();
			return new CodePosition(startLine, endLine, startPos, endPos);
		}

		public void Write(BinaryWriter writer) {
			writer.Write(StartLine);
			writer.Write(EndLine);
			writer.Write(StartPos);
			writer.Write(EndPos);
		}
	}
}