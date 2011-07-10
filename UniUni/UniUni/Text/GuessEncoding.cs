using System;
using System.IO;
using System.Linq;
using System.Text;
using UniUni.Text.Gauche;

namespace UniUni.Text {
	public class GuessEncoding {
		public static Encoding GetEncodingFromMagicComment(byte[] bytes) {
			var text = Encoding.ASCII.GetString(bytes);
			return GetEncodingFromMagicComment(text);
		}

		public static Encoding GetEncodingFromMagicComment(string text) {
			const string codingString = "coding:";
			var magicComment = text.Replace("\r\n", "\n")
					.Replace("\r", "\n")
					.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(s => s.Trim())
					.Where(s => s.StartsWith("#"))
					.Take(10)
					.FirstOrDefault(s => s.Contains(codingString));
			if (magicComment == null)
				return null;
			var index = magicComment.IndexOf(codingString);
			magicComment = magicComment.Substring(index + codingString.Length).TrimStart();
			index = magicComment.IndexOf(' ');
			if (index < 0)
				index = magicComment.IndexOf('　');
			if (index < 0)
				index = magicComment.IndexOf('\t');
			if (index >= 0)
				magicComment = magicComment.Substring(0, index);
			switch (magicComment) {
			case "latin-1":
				magicComment = "windows-1252";
				break;
			}
			return Encoding.GetEncoding(magicComment);
		}

		public static Encoding GetEncodingUsingGauche(byte[] bytes) {
			return GaucheGuess.GuessEncodings(bytes);
		}

		public static Encoding GetEncoding(byte[] bytes) {
			return GetEncodingFromMagicComment(bytes)
			       ?? GetEncodingUsingGauche(bytes);
		}

		public static string GetStringFromBytes(byte[] bytes) {
			return GetEncoding(bytes).GetString(bytes);
		}

		public static string ReadAllText(string path) {
			var bytes = File.ReadAllBytes(path);
			var encoding = GetEncoding(bytes);
			var str = encoding.GetString(bytes);
			// BOMがあれば取り除く
			return str[0] != 65279 ? str : str.Substring(1);
		}
	}
}
