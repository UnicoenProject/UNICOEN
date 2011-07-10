using System;
using System.Text;

namespace UniUni.Text {
	public class EncodingUtil {
		public static Encoding Guess(string text) {
			return Encoding.UTF8;
		}
	}
}
