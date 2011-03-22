namespace Ucpf.Core.Model {
	public abstract class UnifiedExpressionWithBlock<T> : UnifiedExpression
		where T : UnifiedExpressionWithBlock<T> {
		private UnifiedBlock _body;

		public UnifiedBlock Body {
			get { return _body; }
			set {
				_body = value;
				if (value != null) value.Parent = this;
			}
		}

		protected UnifiedExpressionWithBlock() {
			Body = new UnifiedBlock();
		}

		public T AddToBody(UnifiedExpression expression) {
			Body.Add(expression);
			return (T)this;
		}
		}
}