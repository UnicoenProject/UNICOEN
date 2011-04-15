using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   synchronizedなど特殊なブロックを表します。
	/// </summary>
	public class UnifiedSpecialBlock
			: UnifiedExpressionWithBlock<UnifiedSpecialBlock> {
		public UnifiedSpecialBlockKind Kind { get; set; }

		public IUnifiedExpression Value { get; set; }

		private UnifiedSpecialBlock() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedSpecialBlock Create(UnifiedSpecialBlockKind kind,
		                                         IUnifiedExpression value,
		                                         UnifiedBlock body) {
			return new UnifiedSpecialBlock {
					Kind = kind,
					Value = value,
					Body = body,
			};
		}
			}
}