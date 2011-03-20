using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ucpf.Core.Model {
	public abstract class UnifiedElementCollection<TElement>
		: UnifiedElement, IEnumerable<TElement>
		where TElement : UnifiedElement {
		private readonly List<TElement> _elements;

		protected UnifiedElementCollection() {
			_elements = new List<TElement>();
		}

		protected UnifiedElementCollection(IEnumerable<TElement> elements) {
			_elements = elements.ToList();
		}

		public TElement this[int index] {
			get { return _elements[index]; }
			set { _elements[index] = value; }
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
		}

		// TODO: UnifiedElementCollectionを継承するクラスがプロパティを持たなければ、このクラスでGetElementsを実装しても良い
		public override IEnumerable<UnifiedElement> GetElements() {
			return this;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementsAndSetters() {
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(this[i], v => this[i] = (TElement)v);
			}
		}


		}
}