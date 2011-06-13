namespace Unicoen.Apps.Aop.AspectElement
{
	/// <summary>
	/// 言語依存ブロックを表します
	/// </summary>
	public class LanguageDependBlock
	{
		/// <summary>
		/// 依存する言語の種類
		/// </summary>
		private string _languageType;

		/// <summary>
		/// 合成される処理内容
		/// </summary>
		private string _contents;

		public string GetLanguageType()
		{
			return _languageType;
		}

		public string GetContents()
		{
			return _contents;
		}

		public void SetLanguageType(string language)
		{
			_languageType = language;
		}

		public void SetContents(string content)
		{
			_contents += (content + " ");
		}
	}
}
