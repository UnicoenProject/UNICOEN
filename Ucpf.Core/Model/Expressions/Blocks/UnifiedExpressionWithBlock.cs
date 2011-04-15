using System.Diagnostics;

namespace Ucpf.Core.Model {
	/// <summary>
	///   ブロックを持つ式を表します。
	/// </summary>
	/// <typeparam name = "TSelf"></typeparam>
	public abstract class UnifiedExpressionWithBlock
			: UnifiedElement, IUnifiedExpression {
		protected UnifiedBlock _body;

		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetParentOfChild(value, _body); }
		}

		protected UnifiedExpressionWithBlock() {
			Body = UnifiedBlock.Create();
		}
			}

	/// <summary>
	///   ブロックを持つ式を表します。
	/// </summary>
	/// <typeparam name = "TSelf"></typeparam>
	public abstract class UnifiedExpressionWithBlock<TSelf>
			: UnifiedExpressionWithBlock
			where TSelf : UnifiedExpressionWithBlock<TSelf> {
		protected UnifiedExpressionWithBlock() {
			Debug.Assert(typeof(TSelf).Equals(GetType()));
		}

		public TSelf AddToBody(IUnifiedExpression expression) {
			Body.Add(expression);
			return (TSelf)this;
		}
			}
}