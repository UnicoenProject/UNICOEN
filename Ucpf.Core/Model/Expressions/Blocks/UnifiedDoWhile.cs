using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   do-while文を表します。
	/// </summary>
	public class UnifiedDoWhile : UnifiedExpressionWithBlock<UnifiedDoWhile> {
		private IUnifiedExpression _condition;

		public IUnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetParentOfChild(value, _condition); }
		}

		private UnifiedDoWhile() {}

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
			yield return Condition;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Condition, v => Condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_condition, v => _condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedDoWhile Create() {
			return new UnifiedDoWhile();
		}

		public static UnifiedDoWhile Create(UnifiedBlock body) {
			return new UnifiedDoWhile {
					Body = body,
			};
		}

		public static UnifiedDoWhile Create(UnifiedBlock body,
		                                    IUnifiedExpression condition) {
			return new UnifiedDoWhile {
					Body = body,
					Condition = condition,
			};
		}

		public static UnifiedDoWhile Create(IUnifiedExpression condition) {
			return new UnifiedDoWhile {
					Condition = condition,
			};
		}
	}
}