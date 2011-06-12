using System;

namespace Unicoen.Apps.Aop.AspectElement
{
	/// <summary>
	/// インタータイプ宣言を表します
	/// インタータイプ宣言は１つの言語依存ブロックから構成されます
	/// </summary>
	public class Intertype : IAspectElement
	{
		private LanguageDependBlock _block = new LanguageDependBlock();
		private string _targetClass;
		
		//織り込み対象となる言語を指定します
		public void SetLanguageType(string language)
		{
			_block.SetLanguageType(language);
		}

		//織り込み対象に合成する処理を指定します
		public void SetContents(string content)
		{
			_block.SetContents(content);
		}

		public void SetTarget(string target)
		{
			_targetClass = target;
		}

		#region Un-use Methods

		public void SetElementType(string elementType)
		{
			throw new InvalidOperationException();
		}

		public void SetName(string name)
		{
			throw new InvalidProgramException();
		}

		public void SetParameterType(string paramType)
		{
			throw new InvalidOperationException();
		}

		public void SetParameter(string param)
		{
			throw new InvalidOperationException();
		}

		public void SetType(string type)
		{
			throw new InvalidOperationException();
		}

		#endregion

		public string GetProperty()
		{
			var property = "language: " + _block.GetLanguageType() + "\n";
			property += "ClassName: " + _targetClass + "\n";
			property += "contents: ";
			foreach (var c in _block.GetContents())
			{
				property += c;
			}
			property += "\n";

			return property;
		}

		public string GetLanguageType()
		{
			return _block.GetLanguageType();
		}

		public string GetContents()
		{
			return _block.GetContents();
		}

		public string GetTarget()
		{
			return _targetClass;
		}
	}
}
