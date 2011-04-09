using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	public interface IUnifiedElement : ICloneable
	{
		/// <summary>
		///   親のコードモデルの要素を取得もしくは設定します。
		/// </summary>
		IUnifiedElement Parent { get; }

		/// <summary>
		///   ビジターを適用してコードモデルを走査します。
		/// </summary>
		/// <param name = "visitor"></param>
		void Accept(IUnifiedModelVisitor visitor);

		/// <summary>
		///   ビジターを適用してコードモデルを走査します。
		/// </summary>
		/// <typeparam name = "TData"></typeparam>
		/// <typeparam name = "TResult"></typeparam>
		/// <param name = "visitor"></param>
		/// <param name = "data"></param>
		/// <returns></returns>
		TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data);

		/// <summary>
		///   子要素を列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		IEnumerable<IUnifiedElement> GetElements();

		/// <summary>
		///   子要素とセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters();

		/// <summary>
		///   子要素とプロパティを介さないセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters();

		/// <summary>
		///   コードモデルを正規化します。
		///   正規化の内容は以下のとおりです。
		///   ・子要素がUnifiedBlockだけのUnifiedBlockを削除
		///   ・-1や+1などの単項式を定数に変換
		/// </summary>
		IUnifiedElement Normalize();

		/// <summary>
		///   深いコピーを取得します。
		/// </summary>
		/// <returns>深いコピー</returns>
		IUnifiedElement DeepCopy();

		/// <summary>
		///   深いコピーを取得します。
		/// </summary>
		/// <returns>深いコピー</returns>
		T DeepCopy<T>()
			where T : IUnifiedElement;

		/// <summary>
		///   指定した子要素を削除して、自分自身を取得します。
		/// </summary>
		/// <param name = "target">自分自身</param>
		/// <returns></returns>
		IUnifiedElement RemoveChild(IUnifiedElement target);

		/// <summary>
		///   親要素から自分自身を削除して、親要素を取得します。
		/// </summary>
		/// <returns>親要素</returns>
		IUnifiedElement Remove();
	}
}