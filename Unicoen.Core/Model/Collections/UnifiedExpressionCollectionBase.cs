#region License

// Copyright (C) 2011-2012 The Unicoen Project
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
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   集合を表す共通表現オブジェクトに必要な機能を提供します．
	/// </summary>
	/// <typeparam name="TElement"> 集合の要素である共通表現オブジェクトの型 </typeparam>
	/// <typeparam name="TSelf"> このクラスを継承する自分自身のクラス </typeparam>
	public abstract class UnifiedExpressionCollectionBase<TElement, TSelf>
			: UnifiedExpression, IUnifiedCreatable<TSelf>,
			  IUnifiedElementCollection<TElement>, ICopiable
			where TElement : UnifiedElement
			where TSelf : UnifiedExpressionCollectionBase<TElement, TSelf> {
		protected List<TElement> ElementList;

		protected UnifiedExpressionCollectionBase() {
			Debug.Assert(typeof(TSelf) == GetType(), "TSelf should equal itself class.");
			ElementList = new List<TElement>();
		}

		/// <summary>
		///   レシーバーと同じ型のオブジェクトを生成します．
		/// </summary>
		/// <returns> 生成したオブジェクト </returns>
		public abstract TSelf CreateSelf();

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				UnifiedVisitor<TArg> visitor,
				TArg arg) {
			// Deal with the bug of Mono 2.10.2
			throw new InvalidOperationException(
					"You should override this method.");
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				UnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			// Deal with the bug of Mono 2.10.2
			throw new InvalidOperationException(
					"You should override this method.");
		}

		/// <summary>
		///   子要素を列挙します。
		/// </summary>
		/// <returns> 子要素 </returns>
		public override IEnumerable<UnifiedElement> Elements() {
			Debug.Assert(
					!base.Elements().Any(),
					"UnifiedElementCollectionBase can't have properties without ElementList");
			return ElementList;
		}

		/// <summary>
		///   子要素とセッターのペアを列挙します。
		/// </summary>
		/// <returns> 子要素 </returns>
		public override IEnumerable<ElementReference> ElementReferences() {
			// このクラスが持つ共通表現の要素のプロパティから得られる要素列
			foreach (var reference in base.ElementReferences()) {
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
		/// <returns> 子要素 </returns>
		public override IEnumerable<ElementReference>
				ElementReferencesOfFields() {
			// このクラスが持つ共通表現の要素のプロパティから得られる要素列
			foreach (var reference in base.ElementReferencesOfFields()) {
				yield return reference;
			}
			// 共通表現の要素集合として持つ子要素列
			var count = ElementList.Count;
			for (int i = 0; i < count; i++) {
				yield return ElementReference.Create(
						() => ElementList[i],
						e => ElementList[i] = (TElement)e);
			}
		}

		/// <summary>
		///   指定した条件を満たす要素を一つだけ削除します．
		/// </summary>
		/// <param name="predicator"> 要素が削除対象かどうか判定するデリゲート </param>
		/// <returns> 削除したか否か </returns>
		public bool Remove(Func<TElement, bool> predicator) {
			var count = ElementList.Count;
			for (int i = 0; i < count; i++) {
				var element = ElementList[i];
				if (predicator(element)) {
					element.Parent = null;
					ElementList.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///   指定した条件を満たす要素を全て削除します．
		/// </summary>
		/// <param name="predicator"> 要素が削除対象かどうか判定するデリゲート </param>
		/// <returns> 削除したか否か </returns>
		public bool RemoveAll(Func<TElement, bool> predicator) {
			var count = ElementList.Count;
			var result = false;
			for (int i = count - 1; i >= 0; i--) {
				var element = ElementList[i];
				if (predicator(element)) {
					element.Parent = null;
					ElementList.RemoveAt(i);
					result = true;
				}
			}
			return result;
		}

		/// <summary>
		///   深いコピーを取得します。
		/// </summary>
		/// <returns> 深いコピー </returns>
		UnifiedElement ICopiable.PrivateDeepCopy() {
			var ret =
					(UnifiedExpressionCollectionBase<TElement, TSelf>)MemberwiseClone();
			ret.Parent = null;
			// ElementListの深いコピーが必要なため UnifiedElement とは別の処理が必要
			ret.ElementList = new List<TElement>();
			foreach (var element in this) {
				ret.Add(element.DeepCopy());
			}
			return ret;
		}

		/// <summary>
		///   指定した子要素を削除します。
		/// </summary>
		/// <param name="target"> 削除する子要素 </param>
		/// <returns> レシーバーオブジェクト </returns>
		public override UnifiedElement RemoveChild(UnifiedElement target) {
			return RemoveChild((TElement)target);
		}

		/// <summary>
		///   指定した子要素を削除します。
		/// </summary>
		/// <param name="target"> 削除する子要素 </param>
		/// <returns> レシーバーオブジェクト </returns>
		public TSelf RemoveChild(TElement target) {
			Contract.Requires(target != null);
			ElementList.Remove(target);
			target.Parent = null;
			return (TSelf)this;
		}

		/// <summary>
		///   コードモデルを正規化します。 正規化の内容は以下のとおりです。 ・子要素がUnifiedBlockだけのUnifiedBlockを削除 ・-1や+1などの単項式を定数に変換
		/// </summary>
		public override UnifiedElement Normalize() {
			// TODO: パフォーマンス向上のためUnifiedBlockに移したほうが良い？
			NormalizeChildren();
			if (ElementList.Count == 1) {
				var element = ElementList[0];
				if (GetType().IsInstanceOfType(element)) {
					return element;
				}
			}
			return this;
		}

		/// <summary>
		///   空の要素集合を生成します．
		/// </summary>
		/// <returns> 生成した要素集合 </returns>
		public static TSelf Create() {
			return UnifiedFactory<TSelf>.Create();
		}

		/// <summary>
		///   指定した要素列を格納する要素集合を作成します．
		/// </summary>
		/// <returns> 生成した要素集合 </returns>
		public static TSelf Create(params TElement[] elements) {
			return Create((IEnumerable<TElement>)elements);
		}

		/// <summary>
		///   指定した要素列を格納する要素集合を作成します．
		/// </summary>
		/// <returns> 生成した要素集合 </returns>
		public static TSelf Create(IEnumerable<TElement> elements) {
			var ret = UnifiedFactory<TSelf>.Create();
			if (elements != null) {
				ret.AddRange(elements);
			}
			return ret;
		}

		/// <summary>
		///   指定した位置から指定した探索して指定した要素が存在する位置を返します．
		/// </summary>
		/// <param name="element"> 探索する要素 </param>
		/// <param name="index"> 探索を開始する位置 </param>
		/// <returns> 要素が存在する位置，存在しない場合は-1 </returns>
		public int IndexOf(TElement element, int index) {
			return ElementList.IndexOf(element, index);
		}

		/// <summary>
		///   全ての要素を返してからコレクションから要素を取り除きます．
		/// </summary>
		/// <exception cref="T:System.NotSupportedException">The
		///   <see cref="T:System.Collections.Generic.ICollection`1" />
		///   is read-only.</exception>
		public IEnumerable<TElement> ElementsThenClear() {
			foreach (var element in ElementList) {
				element.Parent = null;
				yield return element;
			}
			ElementList.Clear();
		}

		#region IEnumerable<TElement> Members

		/// <summary>
		///   Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns> A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection. </returns>
		/// <filterpriority>1</filterpriority>
		public IEnumerator<TElement> GetEnumerator() {
			return ElementList.GetEnumerator();
		}

		/// <summary>
		///   Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns> An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection. </returns>
		/// <filterpriority>2</filterpriority>
		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		#endregion

		#region IList<TElement> Members

		/// <summary>
		///   Gets or sets the element at the specified index.
		/// </summary>
		/// <returns> The element at the specified index. </returns>
		/// <param name="index"> The zero-based index of the element to get or set. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" />
		///   is not a valid index in the
		///   <see cref="T:System.Collections.Generic.IList`1" />
		///   .</exception>
		/// <exception cref="T:System.NotSupportedException">The property is set and the
		///   <see cref="T:System.Collections.Generic.IList`1" />
		///   is read-only.</exception>
		public TElement this[int index] {
			get { return ElementList[index]; }
			set {
				if (value != null) {
					if (value.Parent != null) {
						throw new InvalidOperationException(
								"既に親要素が設定されている要素を設定できません。");
					}
					value.Parent = this;
				}
				ElementList[index] = value;
			}
		}

		/// <summary>
		///   Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </summary>
		/// <returns> The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" /> . </returns>
		public int Count {
			get { return ElementList.Count; }
		}

		/// <summary>
		///   Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
		/// </summary>
		/// <returns> true if the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise, false. </returns>
		public bool IsReadOnly {
			get { return false; }
		}

		/// <summary>
		///   Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </summary>
		/// <param name="item"> The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" /> . </param>
		/// <exception cref="T:System.NotSupportedException">The
		///   <see cref="T:System.Collections.Generic.ICollection`1" />
		///   is read-only.</exception>
		public void Add(TElement item) {
			ElementList.Add(item);
			if (item != null) {
				if (item.Parent != null) {
					throw new InvalidOperationException(
							"既に親要素が設定されている要素を設定できません。");
				}
				item.Parent = this;
			}
		}

		/// <summary>
		///   Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </summary>
		/// <exception cref="T:System.NotSupportedException">The
		///   <see cref="T:System.Collections.Generic.ICollection`1" />
		///   is read-only.</exception>
		public void Clear() {
			foreach (var element in ElementList) {
				element.Parent = null;
			}
			ElementList.Clear();
		}

		/// <summary>
		///   Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
		/// </summary>
		/// <returns> true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" /> ; otherwise, false. </returns>
		/// <param name="item"> The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" /> . </param>
		public bool Contains(TElement item) {
			return ElementList.Contains(item);
		}

		/// <summary>
		///   Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an <see cref="T:System.Array" /> , starting at a particular <see
		///    cref="T:System.Array" /> index.
		/// </summary>
		/// <param name="array"> The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see
		///    cref="T:System.Collections.Generic.ICollection`1" /> . The <see cref="T:System.Array" /> must have zero-based indexing. </param>
		/// <param name="arrayIndex"> The zero-based index in <paramref name="array" /> at which copying begins. </param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" />
		///   is null.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="arrayIndex" />
		///   is less than 0.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="array" />
		///   is multidimensional.-or-The number of elements in the source
		///   <see cref="T:System.Collections.Generic.ICollection`1" />
		///   is greater than the available space from
		///   <paramref name="arrayIndex" />
		///   to the end of the destination
		///   <paramref name="array" />
		///   .-or-Type
		///   <paramref name="T" />
		///   cannot be cast automatically to the type of the destination
		///   <paramref name="array" />
		///   .</exception>
		public void CopyTo(TElement[] array, int arrayIndex) {
			ElementList.CopyTo(array, arrayIndex);
		}

		/// <summary>
		///   共通表現の要素列を追加します．
		/// </summary>
		/// <param name="elements"> </param>
		public void AddRange(IEnumerable<TElement> elements) {
			// 1回の走査で処理を終わらせるようにする
			foreach (var element in elements) {
				ElementList.Add(element);
				if (element != null) {
					if (element.Parent != null) {
						throw new InvalidOperationException(
								"既に親要素が設定されている要素を設定できません。");
					}
					element.Parent = this;
				}
			}
		}

		/// <summary>
		///   Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" /> .
		/// </summary>
		/// <returns> The index of <paramref name="item" /> if found in the list; otherwise, -1. </returns>
		/// <param name="item"> The object to locate in the <see cref="T:System.Collections.Generic.IList`1" /> . </param>
		public int IndexOf(TElement item) {
			return ElementList.IndexOf(item);
		}

		/// <summary>
		///   Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.
		/// </summary>
		/// <param name="index"> The zero-based index at which <paramref name="item" /> should be inserted. </param>
		/// <param name="item"> The object to insert into the <see cref="T:System.Collections.Generic.IList`1" /> . </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" />
		///   is not a valid index in the
		///   <see cref="T:System.Collections.Generic.IList`1" />
		///   .</exception>
		/// <exception cref="T:System.NotSupportedException">The
		///   <see cref="T:System.Collections.Generic.IList`1" />
		///   is read-only.</exception>
		public void Insert(int index, TElement item) {
			if (item.Parent != null) {
				throw new InvalidOperationException("既に親要素が設定されている要素を設定できません。");
			}
			item.Parent = this;
			ElementList.Insert(index, item);
		}

		/// <summary>
		///   Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" /> .
		/// </summary>
		/// <returns> true if <paramref name="item" /> was successfully removed from the <see
		///    cref="T:System.Collections.Generic.ICollection`1" /> ; otherwise, false. This method also returns false if <paramref
		///    name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" /> . </returns>
		/// <param name="item"> The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" /> . </param>
		/// <exception cref="T:System.NotSupportedException">The
		///   <see cref="T:System.Collections.Generic.ICollection`1" />
		///   is read-only.</exception>
		public bool Remove(TElement item) {
			var ret = ElementList.Remove(item);
			if (ret) {
				item.Parent = null;
			}
			return ret;
		}

		/// <summary>
		///   Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
		/// </summary>
		/// <param name="index"> The zero-based index of the item to remove. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" />
		///   is not a valid index in the
		///   <see cref="T:System.Collections.Generic.IList`1" />
		///   .</exception>
		/// <exception cref="T:System.NotSupportedException">The
		///   <see cref="T:System.Collections.Generic.IList`1" />
		///   is read-only.</exception>
		public void RemoveAt(int index) {
			ElementList[index].Parent = null;
			ElementList.RemoveAt(index);
		}

		#endregion
			}
}