namespace Unicoen.Apps.Aop.AspectElement
{
	/// <summary>
	/// アスペクトファイルの構成要素を表します
	/// </summary>
	public interface IAspectElement {
		void SetLanguageType(string language);
		void SetContents(string content);
		void SetElementType(string elementType);
		void SetTarget(string target);
		void SetName(string name);
		void SetParameterType(string paramType);
		void SetParameter(string param);
		void SetType(string type);

		string GetProperty();
	}
}
