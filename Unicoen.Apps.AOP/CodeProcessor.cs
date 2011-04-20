using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;

namespace Unicoen.Apps.AOP {
	/// <summary>
	/// アスペクト指向プログラミングに必要なソースコードの加工処理メソッドを保有します。
	/// </summary>
	public class CodeProcessor {
		
		/// <summary>
		/// 指定されたモデルから、指定されたタイプのリストを返します。
		/// </summary>
		/// <typeparam name="T">指定する共通コードモデルのタイプ</typeparam>
		/// <param name="root">要素を取得する共通コードモデルのルートノード</param>
		/// <returns></returns>
		//GetElementsBySpecifiedComponent<UnifiedNew>(null);
		public static IEnumerable<T> GetElementsBySpecifiedType<T>(IUnifiedElement root)
			where T : class
		{
			foreach (var e in root.DescendantsAndSelf()) {
				var result = e as T;
				if(result != null) {
					yield return result;
				}
			}
		}
		
		//TODO このメソッドは必要か？
		/// <summary>
		/// 指定されたモデルから、指定されたタイプのリストを返します。
		/// </summary>
		/// <param name="root">要素を取得する共通コードモデルのルートノード</param>
		/// <param name="type">指定する共通コードモデルのタイプ</param>
		/// <returns></returns>
		//GetElementsBySpecifiedComponent(null, typeof(UnifiedNew));
		public static IEnumerable<IUnifiedElement> GetElementsBySpecifiedType(IUnifiedElement root, Type type) {
			foreach (var e in root.DescendantsAndSelf()) {
				if(type.IsInstanceOfType(e)) {
					yield return e;
				}
			}
		}

		/// <summary>
		/// 指定されたモデルから、関数のリストを返します。
		/// </summary>
		/// <param name="root">要素を取得する共通コードモデルのルートノード</param>
		/// <returns></returns>
		public static IEnumerable<UnifiedFunctionDefinition> GetFunctionDefinitions(IUnifiedElement root) {
			return GetElementsBySpecifiedType<UnifiedFunctionDefinition>(root);
		}

		/// <summary>
		/// 指定されたモデルから、指定された名前を持つ関数を返します。
		/// </summary>
		/// <param name="root">要素を取得する共通コードモデルのルートノード</param>
		/// <param name="name">要素を取得する関数の名前</param>
		/// <returns></returns>
		public static UnifiedFunctionDefinition GetFunctionDefinitionByName(IUnifiedElement root, string name) {
			foreach (var e in GetElementsBySpecifiedType<UnifiedFunctionDefinition>(root)) {
				if (e.Name.Value == name)
						return e;
			}
			return null;
		}
	}
}
