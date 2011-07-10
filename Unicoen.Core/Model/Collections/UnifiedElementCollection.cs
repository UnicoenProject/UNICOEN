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
	///   集合を表す共通表現オブジェクトに必要な機能を提供します．
	/// </summary>
	/// <typeparam name = "TElement">集合の要素である共通表現オブジェクトの型</typeparam>
	/// <typeparam name = "TSelf">このクラスを継承する自分自身のクラス</typeparam>
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

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			// Deal with the bug of Mono 2.10.2
			throw new InvalidOperationException("You should override this method.");
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
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

		/// <summary>
		///   指定した位置から指定した探索して指定した要素が存在する位置を返します．
		/// </summary>
		/// <param name = "element">探索する要素</param>
		/// <param name = "index">探索を開始する位置</param>
		/// <returns>要素が存在する位置，存在しない場合は-1</returns>
		public int IndexOf(TElement element, int index) {
			return Elements.IndexOf(element, index);
		}

		#region IEnumerable<TElement> Members

		/// <summary>
		///   Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		///   A <see cref = "T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		public IEnumerator<TElement> GetEnumerator() {
			return Elements.GetEnumerator();
		}

		/// <summary>
		///   Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		///   An <see cref = "T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		#endregion

		#region IList<TElement> Members

		/// <summary>
		///   Gets or sets the element at the specified index.
		/// </summary>
		/// <returns>
		///   The element at the specified index.
		/// </returns>
		/// <param name = "index">The zero-based index of the element to get or set.</param>
		/// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "index" /> is not a valid index in the <see
		///    cref = "T:System.Collections.Generic.IList`1" />.</exception>
		/// <exception cref = "T:System.NotSupportedException">The property is set and the <see
		///    cref = "T:System.Collections.Generic.IList`1" /> is read-only.</exception>
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

		/// <summary>
		///   Gets the number of elements contained in the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </summary>
		/// <returns>
		///   The number of elements contained in the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </returns>
		public int Count {
			get { return Elements.Count; }
		}

		/// <summary>
		///   Gets a value indicating whether the <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.
		/// </summary>
		/// <returns>
		///   true if the <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise, false.
		/// </returns>
		public bool IsReadOnly {
			get { return false; }
		}

		/// <summary>
		///   Adds an item to the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </summary>
		/// <param name = "item">The object to add to the <see cref = "T:System.Collections.Generic.ICollection`1" />.</param>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
		public void Add(TElement element) {
			Elements.Add(element);
			if (element != null)
				((UnifiedElement)(IUnifiedElement)element).Parent = this;
		}

		/// <summary>
		///   Removes all items from the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </summary>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only. </exception>
		public void Clear() {
			foreach (var element in Elements) {
				((UnifiedElement)(IUnifiedElement)element).Parent = null;
			}
			Elements.Clear();
		}

		/// <summary>
		///   Determines whether the <see cref = "T:System.Collections.Generic.ICollection`1" /> contains a specific value.
		/// </summary>
		/// <returns>
		///   true if <paramref name = "item" /> is found in the <see cref = "T:System.Collections.Generic.ICollection`1" />; otherwise, false.
		/// </returns>
		/// <param name = "item">The object to locate in the <see cref = "T:System.Collections.Generic.ICollection`1" />.</param>
		public bool Contains(TElement item) {
			return Elements.Contains(item);
		}

		/// <summary>
		///   Copies the elements of the <see cref = "T:System.Collections.Generic.ICollection`1" /> to an <see
		///    cref = "T:System.Array" />, starting at a particular <see cref = "T:System.Array" /> index.
		/// </summary>
		/// <param name = "array">The one-dimensional <see cref = "T:System.Array" /> that is the destination of the elements copied from <see
		///    cref = "T:System.Collections.Generic.ICollection`1" />. The <see cref = "T:System.Array" /> must have zero-based indexing.</param>
		/// <param name = "arrayIndex">The zero-based index in <paramref name = "array" /> at which copying begins.</param>
		/// <exception cref = "T:System.ArgumentNullException"><paramref name = "array" /> is null.</exception>
		/// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "arrayIndex" /> is less than 0.</exception>
		/// <exception cref = "T:System.ArgumentException"><paramref name = "array" /> is multidimensional.-or-The number of elements in the source <see
		///    cref = "T:System.Collections.Generic.ICollection`1" /> is greater than the available space from <paramref
		///    name = "arrayIndex" /> to the end of the destination <paramref name = "array" />.-or-Type <paramref name = "T" /> cannot be cast automatically to the type of the destination <paramref
		///    name = "array" />.</exception>
		public void CopyTo(TElement[] array, int arrayIndex) {
			Elements.CopyTo(array, arrayIndex);
		}

		/// <summary>
		///   共通表現の要素列を追加します．
		/// </summary>
		/// <param name = "elements"></param>
		public void AddRange(IEnumerable<TElement> elements) {
			// 1回の走査で処理を終わらせるようにする
			foreach (var element in elements) {
				Elements.Add(element);
				if (element != null)
					((UnifiedElement)(IUnifiedElement)element).Parent = this;
			}
		}

		/// <summary>
		///   Determines the index of a specific item in the <see cref = "T:System.Collections.Generic.IList`1" />.
		/// </summary>
		/// <returns>
		///   The index of <paramref name = "item" /> if found in the list; otherwise, -1.
		/// </returns>
		/// <param name = "item">The object to locate in the <see cref = "T:System.Collections.Generic.IList`1" />.</param>
		public int IndexOf(TElement item) {
			return Elements.IndexOf(item);
		}

		/// <summary>
		///   Inserts an item to the <see cref = "T:System.Collections.Generic.IList`1" /> at the specified index.
		/// </summary>
		/// <param name = "index">The zero-based index at which <paramref name = "item" /> should be inserted.</param>
		/// <param name = "item">The object to insert into the <see cref = "T:System.Collections.Generic.IList`1" />.</param>
		/// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "index" /> is not a valid index in the <see
		///    cref = "T:System.Collections.Generic.IList`1" />.</exception>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.IList`1" /> is read-only.</exception>
		public void Insert(int index, TElement element) {
			Elements.Insert(index, element);
		}

		/// <summary>
		///   Removes the first occurrence of a specific object from the <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </summary>
		/// <returns>
		///   true if <paramref name = "item" /> was successfully removed from the <see
		///    cref = "T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref
		///    name = "item" /> is not found in the original <see cref = "T:System.Collections.Generic.ICollection`1" />.
		/// </returns>
		/// <param name = "item">The object to remove from the <see cref = "T:System.Collections.Generic.ICollection`1" />.</param>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
		public bool Remove(TElement item) {
			return Elements.Remove(item);
		}

		/// <summary>
		///   Removes the <see cref = "T:System.Collections.Generic.IList`1" /> item at the specified index.
		/// </summary>
		/// <param name = "index">The zero-based index of the item to remove.</param>
		/// <exception cref = "T:System.ArgumentOutOfRangeException"><paramref name = "index" /> is not a valid index in the <see
		///    cref = "T:System.Collections.Generic.IList`1" />.</exception>
		/// <exception cref = "T:System.NotSupportedException">The <see cref = "T:System.Collections.Generic.IList`1" /> is read-only.</exception>
		public void RemoveAt(int index) {
			((UnifiedElement)(IUnifiedElement)Elements[index]).Parent = null;
			Elements.RemoveAt(index);
		}

		#endregion
			}
}