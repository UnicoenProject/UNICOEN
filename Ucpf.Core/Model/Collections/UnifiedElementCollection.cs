using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Ucpf.Core.Model
{
	public abstract class UnifiedElementCollection<TElement, TSelf>
		: UnifiedElement, IUnifiedElementCollection<TElement>
		where TElement : class, IUnifiedElement
		where TSelf : UnifiedElementCollection<TElement, TSelf>
	{
		protected List<TElement> Elements;

		protected UnifiedElementCollection()
		{
			Debug.Assert(typeof(TSelf).Equals(GetType()));
			Elements = new List<TElement>();
		}

		protected UnifiedElementCollection(IEnumerable<TElement> elements)
			: this()
		{
			foreach (var element in elements) {
				Add(element);
			}
		}

		public TElement this[int index]
		{
			get { return Elements[index]; }
			set
			{
				if (value != null) {
					if (value.Parent != null)
						value = (TElement)value.DeepCopy();
					((UnifiedElement)(IUnifiedElement)value).Parent = this;
				}
				Elements[index] = value;
			}
		}

		public int Count
		{
			get { return Elements.Count; }
		}

		#region IEnumerable<TElement> Members

		public IEnumerator<TElement> GetEnumerator()
		{
			return Elements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		public void PrivateAdd(TElement element)
		{
			Add(element);
		}

		public TSelf Add(TElement element)
		{
			Elements.Add(element);
			if (element != null)
				((UnifiedElement)(IUnifiedElement)element).Parent = this;
			return (TSelf)this;
		}

		public override IUnifiedElement DeepCopy()
		{
			var ret = (UnifiedElementCollection<TElement, TSelf>)MemberwiseClone();
			ret.Parent = null;
			ret.Elements = new List<TElement>();
			foreach (var element in this) {
				ret.Add((TElement)element.DeepCopy());
			}
			return ret;
		}

		public override IUnifiedElement RemoveChild(IUnifiedElement target)
		{
			return RemoveChild((TElement)target);
		}

		public TSelf RemoveChild(TElement target)
		{
			Contract.Requires(target != null);
			Elements.Remove(target);
			((UnifiedElement)(IUnifiedElement)target).Parent = null;
			return (TSelf)this;
		}

		// TODO: UnifiedElementCollectionを継承するクラスがプロパティを持たなければ、このクラスでGetElementsを実装しても良い
		public override IEnumerable<IUnifiedElement> GetElements()
		{
			return this;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(this[i], v => this[i] = (TElement)v);
			}
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Elements[i], v => Elements[i] = (TElement)v);
			}
		}

		public override IUnifiedElement Normalize()
		{
			NormalizeChildren();
			if (Elements.Count == 1) {
				var element = Elements[0];
				if (GetType().IsInstanceOfType(element))
					return element;
			}
			return this;
		}
	}
}