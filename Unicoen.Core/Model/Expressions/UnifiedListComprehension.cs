using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model.Expressions
{
	/// <summary>
	/// リスト内包表記の式を表します．
	/// </summary>
	public class UnifiedListComprehension : UnifiedElement
	{
		private IUnifiedExpression _element;

		/// <summary>
		/// リスト内包表記によって生成される要素部分の式を表します．
		/// </summary>
		public IUnifiedExpression Element {
			get { return _element; }
			set { _element = SetParentOfChild(value, _element); }
		}

		private UnifiedExpressionCollection _collection;

		/// <summary>
		/// リスト内包表記の集合部分の式を表します．
		/// </summary>
		public UnifiedExpressionCollection Collection {
			get { return _collection; }
			set { _collection = SetParentOfChild(value, _collection); }
		}
		private UnifiedListComprehension() { }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Element;
			yield return Collection;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Element, v => Element = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Collection, v => Collection = (UnifiedExpressionCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_element, v => _element = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_collection, v => _collection = (UnifiedExpressionCollection)v);
		}

		public static UnifiedListComprehension Create(
				IUnifiedExpression element,
				UnifiedExpressionCollection collection) {
			return new UnifiedListComprehension {
				Element = element,
				Collection = collection,
			};
		}
	}
}