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
using Unicoen.Processor;

namespace Unicoen.Model {
	public interface IUnifiedElement : ICloneable {
		/// <summary>
		///   親のコードモデルの要素を取得もしくは設定します。
		/// </summary>
		IUnifiedElement Parent { get; }

		/// <summary>
		///   ビジターを適用してコードモデルを走査します。
		/// </summary>
		/// <param name = "visitor"></param>
		void Accept(IUnifiedVisitor visitor);

		/// <summary>
		///   ビジターを適用してコードモデルを走査します。
		/// </summary>
		/// <param name = "visitor"></param>
		/// <param name = "arg"></param>
		void Accept<TArg>(IUnifiedVisitor<TArg> visitor, TArg arg);

		/// <summary>
		///   ビジターを適用してコードモデルを走査します。
		/// </summary>
		/// <typeparam name = "TArg"></typeparam>
		/// <typeparam name = "TResult"></typeparam>
		/// <param name = "visitor"></param>
		/// <param name = "arg"></param>
		/// <returns></returns>
		TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg);

		/// <summary>
		///   子要素を列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		IEnumerable<IUnifiedElement> Elements();

		/// <summary>
		///   子要素とセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		IEnumerable<ElementReference> ElementReferences();

		/// <summary>
		///   子要素とプロパティを介さないセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		IEnumerable<ElementReference> ElementReferencesOfFields();

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
		IUnifiedElement PrivateDeepCopy();

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
		IUnifiedElement RemoveSelf();
	}
}