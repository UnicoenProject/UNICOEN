using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code2Xml.Languages.Java.XmlGenerators;
using Unicoen.Core.Model;
using Unicoen.Languages.Java.ModelFactories;

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
		
		/// <summary>
		/// すべての関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name="root">コードを追加するモデルのルートノード</param>
		/// <param name="advice">挿入するコード断片</param>
		public static void InsertBeforeAllFunction(IUnifiedElement root, string advice) {
			//get function list
			var functions = GetFunctionDefinitions(root);
			//create advice as model
			var actual = CreateAdvice(advice);

			foreach (var e in functions) {
				e.Body.Insert(0, actual);
				throw new NotImplementedException();
				//TODO どうやってe.Bodyの一番前に処理を追加するか検討する
			}
		}

		/// <summary>
		/// すべての関数の後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name="root">コードを追加するモデルのルートノード</param>
		/// <param name="advice">挿入するコード断片</param>
		public static void InsertAfterAllFunction(IUnifiedElement root, string advice) {
			//get function list
			var functions = GetFunctionDefinitions(root);
			//create advice as model
			var actual = CreateAdvice(advice);

			foreach (var function in functions) {
				var returns =
						GetElementsBySpecifiedType<UnifiedSpecialExpression>(function).Where(
								e => e.Kind == UnifiedSpecialExpressionKind.Return);

				if(returns.Count() == 0) { //case function don't have return statement
					function.Body.Add(actual);
				}
				foreach (var returnStmt in returns) {
					throw new NotImplementedException();
					//TODO insertElementBefore(returnStmt, actual)みたいなメソッドが必要
				}
			}
		}

		/// <summary>
		/// 与えられたコードを共通コードモデルとして生成します。
		/// </summary>
		/// <param name="code">コード断片</param>
		/// <returns></returns>
		public static UnifiedBlock CreateAdvice(string code) {
			//generate model from string advice (as UnifiedBlock)
			var ast = JavaXmlGenerator.Instance.Generate(code, p => p.block());
			var actual = JavaModelFactoryHelper.CreateBlock(ast);
			actual.Normalize();

			return actual;
		}
	}
}
