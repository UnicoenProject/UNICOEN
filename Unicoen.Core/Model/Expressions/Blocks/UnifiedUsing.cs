using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model
{
	public class UnifiedUsing 
			: UnifiedExpressionWithBlock<UnifiedUsing> {
		private UnifiedMatcherCollection _matchers;

		public UnifiedMatcherCollection Matchers {
			get { return _matchers; }
			set { _matchers = SetParentOfChild(value, _matchers); }
		}

		private UnifiedUsing() {}

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
			yield return Matchers;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Matchers, v => Matchers = (UnifiedMatcherCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_matchers, v => _matchers = (UnifiedMatcherCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedUsing Create(
				UnifiedMatcherCollection matchers,
				UnifiedBlock body) {
			return new UnifiedUsing {
					Matchers = matchers,
					Body = body,
			};
		}
			}
}