namespace Ucpf.Core.Model {
	public abstract class UnifiedExpressionWithBlock<T> : UnifiedExpression
			where T : UnifiedExpressionWithBlock<T> {
		protected UnifiedBlock _body;

		public UnifiedBlock Body {
			get { return _body; }
			set {
				if (value != null) {
					if (value.Parent != null) {
						value = (UnifiedBlock)value.DeepCopy();
					}
					value.Parent = this;
				}
				_body = value;
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