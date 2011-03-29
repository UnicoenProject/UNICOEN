using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Ucpf.Core.Model {
	public abstract class UnifiedElementCollection<TElement>
			: UnifiedElement, IEnumerable<TElement>
			where TElement : UnifiedElement {
		private List<TElement> _elements;

		protected UnifiedElementCollection() {
			_elements = new List<TElement>();
		}

		protected UnifiedElementCollection(IEnumerable<TElement> elements)
				: this() {
			foreach (var element in elements) {
				Add(element);
			}
		}

		public TElement this[int index] {
			get { return _elements[index]; }
			set {
				if (value != null) {
					if (value.Parent != null)
						value = (TElement)value.DeepCopy();
					value.Parent = this;
				}
				_elements[index] = value;
			}
		}

		public int Count {
			get { return _elements.Count; }
		}

		#region IEnumerable<TElement> Members

		public IEnumerator<TElement> GetEnumerator() {
			return _elements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		#endregion

		public void Add(TElement element) {
			_elements.Add(element);
			if (element != null) element.Parent = this;
		}

		public override UnifiedElement DeepCopy() {
			var ret = (UnifiedElementCollection<TElement>)MemberwiseClone();
			ret.Parent = null;
			ret._elements = new List<TElement>();
			foreach (var element in this) {
				ret.Add((TElement)element.DeepCopy());
			}
			return ret;
		}

		public override UnifiedElement RemoveChild(UnifiedElement target) {
			return RemoveChild((TElement)target);
		}

		public UnifiedElement RemoveChild(TElement target) {
			Contract.Requires(target != null);
			_elements.Remove(target);
			return this;
		}

		// TODO: UnifiedElementCollectionを継承するクラスがプロパティを持たなければ、このクラスでGetElementsを実装しても良い
		public override IEnumerable<UnifiedElement> GetElements() {
			return this;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndSetters() {
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
						(this[i], v => this[i] = (TElement)v);
			}
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndDirectSetters() {
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
						(_elements[i], v => _elements[i] = (TElement)v);
			}
		}
			}
}