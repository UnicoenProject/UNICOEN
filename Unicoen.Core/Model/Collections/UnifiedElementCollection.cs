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
			return this.Concat(base.GetElements());
		}

		/// <summary>
		///   子要素とセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		public override IEnumerable<ElementReference> GetElementReferences() {
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return ElementReference.Create(
						() => this[i],
						e => this[i] = (TElement)e);
			}
			foreach (var reference in base.GetElementReferences()) {
				yield return reference;
			}
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		public override IEnumerable<ElementReference>
				GetElementReferencesOfFields() {
			var count = Elements.Count;
			for (int i = 0; i < count; i++) {
				yield return ElementReference.Create(
						() => Elements[i],
						e => Elements[i] = (TElement)e);
			}
			foreach (var reference in base.GetElementReferencesOfFields()) {
				yield return reference;
			}
		}

		public void RemoveAt(int index) {
			((UnifiedElement)(IUnifiedElement)Elements[index]).Parent = null;
			Elements.RemoveAt(index);
		}

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

		#region IEnumerable<TElement> Members

		public IEnumerator<TElement> GetEnumerator() {
			return Elements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		#endregion

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

		public bool Remove(TElement item) {
			return Elements.Remove(item);
		}

		public int IndexOf(TElement element, int index) {
			return Elements.IndexOf(element, index);
		}

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

		IUnifiedElement IUnifiedElement.PrivateDeepCopy() {
			var ret = (UnifiedElementCollection<TElement, TSelf>)MemberwiseClone();
			ret.Parent = null;
			// Elementsの深いコピーが必要なため,UnifiedElementとは別の処理が必要
			ret.Elements = new List<TElement>();
			foreach (var element in this) {
				ret.Add(element.DeepCopy());
			}
			return ret;
		}

		public override IUnifiedElement RemoveChild(IUnifiedElement target) {
			return RemoveChild((TElement)target);
		}

		public TSelf RemoveChild(TElement target) {
			Contract.Requires(target != null);
			Elements.Remove(target);
			((UnifiedElement)(IUnifiedElement)target).Parent = null;
			return (TSelf)this;
		}

		// TODO: UnifiedElementCollectionを継承するクラスがプロパティを持たなければ、このクラスでGetElementsを実装しても良い

		public override IUnifiedElement Normalize() {
			NormalizeChildren();
			if (Elements.Count == 1) {
				var element = Elements[0];
				if (GetType().IsInstanceOfType(element))
					return element;
			}
			return this;
		}

		public static TSelf Create() {
			return UnifiedFactory<TSelf>.Create();
		}

		public static TSelf Create(params TElement[] elements) {
			var ret = UnifiedFactory<TSelf>.Create();
			if (elements != null)
				ret.AddRange(elements);
			return ret;
		}

		public static TSelf Create(IEnumerable<TElement> elements) {
			var ret = UnifiedFactory<TSelf>.Create();
			if (elements != null)
				ret.AddRange(elements);
			return ret;
		}
			}
}