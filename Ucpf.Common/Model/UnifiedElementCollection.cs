using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common {
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

		public void Add(TElement element) {
			_elements.Add(element);
		}

		public IEnumerator<TElement> GetEnumerator() {
			return _elements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public override string ToString() {
			return UnifiedModelToXml.ToXml(this).ToString();
		}
	}
}