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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   共通表現の要素集合に必要な機能を提供します．
	/// </summary>
	/// <typeparam name = "TElement"></typeparam>
	/// <typeparam name = "TSelf"></typeparam>
	public abstract class UnifiedElementCollection<TElement, TSelf>
			: UnifiedElement, IUnifiedCreatable<TSelf>,
			  IUnifiedElementCollection<TElement>
		where TElement : class, IUnifiedElement
		where TSelf : UnifiedElementCollection<TElement, TSelf> {
		protected List<TElement> Elements;

		protected UnifiedElementCollection() {
			Debug.Assert(typeof(TSelf).Equals(GetType()));
			Elements = new List<TElement>();
		}

		/// <summary>
		///   レシーバーと同じ型のオブジェクトを生成します．
		/// </summary>
		/// <returns>生成したオブジェクト</returns>
		public abstract TSelf CreateSelf();

		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			// Deal with the bug of Mono 2.10.2
			throw new InvalidOperationException("You should override this method.");
		}

		public override TResult Accept<TResult, TArg>(
				IUnifiedVisitor<TResult, TArg> visitor, TArg arg) {
			// Deal with the bug of Mono 2.10.2
			throw new InvalidOperationException("You should override this method.");
		}

		/// <summary>
		///   子要素を列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		public override IEnumerable<IUnifiedElement> GetElements() {
			// base.GetElements(): このクラスが持つ共通表現の要素のプロパティから得られる要素列
			// Elements: 共通表現の要素集合として持つ子要素列
			return base.GetElements().Concat(Elements);
		}

		/// <summary>
		///   子要素とセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		public override IEnumerable<ElementReference> GetElementReferences() {
			// このクラスが持つ共通表現の要素のプロパティから得られる要素列
			foreach (var reference in base.GetElementReferences()) {
				yield return reference;
			}
			// 共通表現の要素集合として持つ子要素列
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return ElementReference.Create(
						() => this[i],
						e => this[i] = (TElement)e);
			}
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		public override IEnumerable<ElementReference>
				GetElementReferencesOfFields() {
			// このクラスが持つ共通表現の要素のプロパティから得られる要素列
			foreach (var reference in base.GetElementReferencesOfFields()) {
				yield return reference;
			}
			// 共通表現の要素集合として持つ子要素列
			var count = Elements.Count;
			for (int i = 0; i < count; i++) {
				yield return ElementReference.Create(
						() => Elements[i],
						e => Elements[i] = (TElement)e);
			}
		}

		/// <summary>
		///   指定した条件を満たす要素を一つだけ削除します．
		/// </summary>
		/// <param name = "predicator">要素が削除対象かどうか判定するデリゲート</param>
		/// <returns>削除したか否か</returns>
		public bool Remove(Func<TElement, bool> predicator) {
			var count = Elements.Count;
			for (int i = 0; i < count; i++) {
				var element = Elements[i];
				if (predicator(element)) {
					Elements.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///   指定した条件を満たす要素を全て削除します．
		/// </summary>
		/// <param name = "predicator">要素が削除対象かどうか判定するデリゲート</param>
		/// <returns>削除したか否か</returns>
		public bool RemoveAll(Func<TElement, bool> predicator) {
			var count = Elements.Count;
			var result = false;
			for (int i = 0; i < count; i++) {
				var element = Elements[i];
				if (predicator(element)) {
					Elements.RemoveAt(i);
					result = true;
				}
			}
			return result;
		}

		/// <summary>
		///   深いコピーを取得します。
		/// </summary>
		/// <returns>深いコピー</returns>
		IUnifiedElement IUnifiedElement.PrivateDeepCopy() {
			var ret = (UnifiedElementCollection<TElement, TSelf>)MemberwiseClone();
			ret.Parent = null;
			// Elementsの深いコピーが必要なため UnifiedElement とは別の処理が必要
			ret.Elements = new List<TElement>();
			foreach (var element in this) {
				ret.Add(element.DeepCopy());
			}
			return ret;
		}

		/// <summary>
		///   指定した子要素を削除します。
		/// </summary>
		/// <param name = "target">削除する子要素</param>
		/// <returns>レシーバーオブジェクト</returns>
		public override IUnifiedElement RemoveChild(IUnifiedElement target) {
			return RemoveChild((TElement)target);
		}

		/// <summary>
		///   指定した子要素を削除します。
		/// </summary>
		/// <param name = "target">削除する子要素</param>
		/// <returns>レシーバーオブジェクト</returns>
		public TSelf RemoveChild(TElement target) {
			Contract.Requires(target != null);
			Elements.Remove(target);
			((UnifiedElement)(IUnifiedElement)target).Parent = null;
			return (TSelf)this;
		}

		/// <summary>
		///   コードモデルを正規化します。
		///   正規化の内容は以下のとおりです。
		///   ・子要素がUnifiedBlockだけのUnifiedBlockを削除
		///   ・-1や+1などの単項式を定数に変換
		/// </summary>
		public override IUnifiedElement Normalize() {
			NormalizeChildren();
			if (Elements.Count == 1) {
				var element = Elements[0];
				if (GetType().IsInstanceOfType(element))
					return element;
			}
			return this;
		}

		/// <summary>
		///   空の要素集合を生成します．
		/// </summary>
		/// <returns>生成した要素集合</returns>
		public static TSelf Create() {
			return UnifiedFactory<TSelf>.Create();
		}

		/// <summary>
		///   指定した要素列を格納する要素集合を作成します．
		/// </summary>
		/// <returns>生成した要素集合</returns>
		public static TSelf Create(params TElement[] elements) {
			var ret = UnifiedFactory<TSelf>.Create();
			if (elements != null)
				ret.AddRange(elements);
			return ret;
		}

		/// <summary>
		///   指定した要素列を格納する要素集合を作成します．
		/// </summary>
		/// <returns>生成した要素集合</returns>
		public static TSelf Create(IEnumerable<TElement> elements) {
			var ret = UnifiedFactory<TSelf>.Create();
			if (elements != null)
				ret.AddRange(elements);
			return ret;
		}

		#region IEnumerable<TElement> Members

		public IEnumerator<TElement> GetEnumerator() {
			return Elements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		#endregion

		#region IList<TElement> Members

		public TElement this[int index] {
			get { return Elements[index]; }
			set {
				if (value != null) {
					if (value.Parent != null)
						value = value.DeepCopy();
					((UnifiedElement)(IUnifiedElement)value).Parent = this;
				}
				Elements[index] = value;
			}
		}

		public int Count {
			get { return Elements.Count; }
		}

		public bool IsReadOnly {
			get { return false; }
		}

		public void Add(TElement element) {
			Elements.Add(element);
			if (element != null)
				((UnifiedElement)(IUnifiedElement)element).Parent = this;
		}

		public void Clear() {
			foreach (var element in Elements) {
				((UnifiedElement)(IUnifiedElement)element).Parent = null;
			}
			Elements.Clear();
		}

		public bool Contains(TElement item) {
			return Elements.Contains(item);
		}

		public void CopyTo(TElement[] array, int arrayIndex) {
			Elements.CopyTo(array, arrayIndex);
		}

		public void AddRange(IEnumerable<TElement> elements) {
			// 1回の走査で処理を終わらせるようにする
			foreach (var element in elements) {
				Elements.Add(element);
				if (element != null)
					((UnifiedElement)(IUnifiedElement)element).Parent = this;
			}
		}

		public int IndexOf(TElement item) {
			return Elements.IndexOf(item);
		}

		public void Insert(int index, TElement element) {
			Elements.Insert(index, element);
		}

		public int IndexOf(TElement element, int index) {
			return Elements.IndexOf(element, index);
		}

		public bool Remove(TElement item) {
			return Elements.Remove(item);
		}

		public void RemoveAt(int index) {
			((UnifiedElement)(IUnifiedElement)Elements[index]).Parent = null;
			Elements.RemoveAt(index);
		}

		#endregion

	}
}