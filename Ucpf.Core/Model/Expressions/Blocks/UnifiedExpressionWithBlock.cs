using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Ucpf.Core.Model {
	public abstract class UnifiedExpressionWithBlock<TSelf> : UnifiedElement, IUnifiedExpression
			where TSelf : UnifiedExpressionWithBlock<TSelf> {
		protected UnifiedBlock _body;

		public UnifiedBlock Body {
			get { return _body; }
			set {
				_body = SetParentOfChild(value, _body);
			}
		}

		protected UnifiedExpressionWithBlock() {
			Debug.Assert(typeof(TSelf).Equals(GetType()));
			Body = UnifiedBlock.Create();
		}

		public TSelf AddToBody(IUnifiedExpression expression) {
			Body.Add(expression);
			return (TSelf)this;
		}
			}
}