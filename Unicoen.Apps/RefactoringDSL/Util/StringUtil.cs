namespace Unicoen.Apps.RefactoringDSL.Util {
	/// <summary>
	/// 文字列操作に関するユーティリティメソッド群
	/// </summary>
	public class StringUtil {
		/// <summary>
		/// 文字列の先頭の文字だけ大文字に変換します
		/// </summary>
		/// <example>field => Field</example>
		/// <param name="str">対象文字列</param>
		/// <returns></returns>
		public static string UpperFirstChar(string str) {
			if (string.IsNullOrEmpty(str)) {
				return "";
			}

			var result = "";
			var charArray = str.ToCharArray();
			result += charArray[0].ToString().ToUpper();

			for (int i = 1; i < charArray.Length; i++) {
				result += charArray[i];
			}

			return result;
		}
	}

	
}
