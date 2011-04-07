namespace Ucpf.Core.Model {
	/// <summary>
	/// ブロックを持つ式を表します。
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class UnifiedExpressionWithBlock<T> : UnifiedElement, IUnifiedExpression
			where T : UnifiedExpressionWithBlock<T> {
		protected UnifiedBlock _body;

		public UnifiedBlock Body {
			get { return _body; }
			set {
				_body = SetParentOfChild(value, _body);
			}
		}

		protected UnifiedExpressionWithBlock() {
			Body = new UnifiedBlock();
		}

		public T AddToBody(IUnifiedExpression expression) {
			Body.Add(expression);
			return (T)this;
		}
			}
}