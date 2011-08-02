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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UniUni.Text.Gauche;

namespace UniUni.Text {
	public class GuessEncoding {
		private static readonly Dictionary<string, string> Encodings =
				new Dictionary<string, string>();

		static GuessEncoding() {
			Encodings["utf8"] = "utf-8";
			Encodings["uft8"] = "utf-8";

			Encodings["latin1"] = "iso-8859-1";
			Encodings["isolatin1"] = "iso-8859-1";
			Encodings["isolatin1unix"] = "iso-8859-1";
			Encodings["isolatin1mac"] = "iso-8859-1";

			Encodings["latin2"] = "iso-8859-2";
			Encodings["isolatin2"] = "iso-8859-2";
			Encodings["isolatin2unix"] = "iso-8859-2";
			Encodings["isolatin2mac"] = "iso-8859-2";

			Encodings["latin3"] = "iso-8859-3";
			Encodings["isolatin3"] = "iso-8859-3";
			Encodings["isolatin3unix"] = "iso-8859-3";
			Encodings["isolatin3mac"] = "iso-8859-3";

			Encodings["latin4"] = "iso-8859-4";
			Encodings["isolatin4"] = "iso-8859-4";
			Encodings["isolatin4unix"] = "iso-8859-4";
			Encodings["isolatin4mac"] = "iso-8859-4";

			Encodings["latincyrillic"] = "iso-8859-5";

			Encodings["latinarabic"] = "iso-8859-6";
			Encodings["iso88596e"] = "iso-8859-6";
			Encodings["iso88596i"] = "iso-8859-6";

			Encodings["latingreek"] = "iso-8859-7";

			Encodings["latinhebrew"] = "iso-8859-8";
			Encodings["iso88598e"] = "iso-8859-8";

			Encodings["latin5"] = "iso-8859-9";
			Encodings["isolatin5"] = "iso-8859-9";
			Encodings["isolatin5unix"] = "iso-8859-9";
			Encodings["isolatin5mac"] = "iso-8859-9";

			Encodings["latin6"] = "iso-8859-10";
			Encodings["isolatin6"] = "iso-8859-10";
			Encodings["isolatin6unix"] = "iso-8859-10";
			Encodings["isolatin6mac"] = "iso-8859-10";

			Encodings["latin7"] = "iso-8859-13";
			Encodings["isolatin7"] = "iso-8859-13";
			Encodings["isolatin7unix"] = "iso-8859-13";
			Encodings["isolatin7mac"] = "iso-8859-13";

			Encodings["latin8"] = "iso-8859-14";
			Encodings["isolatin8"] = "iso-8859-14";
			Encodings["isolatin8unix"] = "iso-8859-14";
			Encodings["isolatin8mac"] = "iso-8859-14";

			Encodings["latin9"] = "iso-8859-15";
			Encodings["isolatin9"] = "iso-8859-15";
			Encodings["isolatin9unix"] = "iso-8859-15";
			Encodings["isolatin9mac"] = "iso-8859-15";

			Encodings["cp1250"] = "windows-1250";
			Encodings["isolatin2dos"] = "windows-1250";
			Encodings["winlatin2"] = "windows-1250";

			Encodings["cp1250"] = "windows-1250";
			Encodings["isolatin2dos"] = "windows-1250";
			Encodings["winlatin2"] = "windows-1250";

			Encodings["cp1251"] = "windows-1251";

			Encodings["cp1253"] = "windows-1253";

			Encodings["cp1254"] = "windows-1254";
			Encodings["isolatin5dos"] = "windows-1254";
			Encodings["winlatin5"] = "windows-1254";

			Encodings["cp1255"] = "windows-1255";

			Encodings["cp1256"] = "windows-1256";

			Encodings["cp1257"] = "windows-1257";
			Encodings["isolatin7dos"] = "windows-1257";
			Encodings["winlatin7"] = "windows-1257";

			Encodings["cp1258"] = "windows-1258";
		}

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
			magicComment =
					magicComment.Substring(index + codingString.Length).TrimStart();
			index = magicComment.IndexOf(' ');
			if (index < 0)
				index = magicComment.IndexOf('　');
			if (index < 0)
				index = magicComment.IndexOf('\t');
			if (index >= 0)
				magicComment = magicComment.Substring(0, index);

			string dictEncoding;
			Encodings.TryGetValue(
					magicComment.Replace("-", "").Replace("/", "").ToLower(), out dictEncoding);
			return Encoding.GetEncoding(dictEncoding ?? magicComment);
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
			return str.Length == 0 || str[0] != 65279 ? str : str.Substring(1);
		}

		public static void Convert(string path, Encoding encoding) {
			var text = ReadAllText(path);
			File.WriteAllText(path, text, encoding);
		}
	}
}