using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedIf : UnifiedExpression {
		private UnifiedExpression _condition;

		public UnifiedExpression Condition {
			get { return _condition; }
			set {
				_condition = value;
				if (value != null) value.Parent = this;
			}
		}

		private UnifiedBlock _trueBody;

		public UnifiedBlock TrueBody {
			get { return _trueBody; }
			set {
				_trueBody = value;
				if (value != null) value.Parent = this;
			}
		}

		private UnifiedBlock _falseBody;

		public UnifiedBlock FalseBody {
			get { return _falseBody; }
			set {
				_falseBody = value;
				if (value != null) value.Parent = this;
			}
		}

		public UnifiedIf() {
			TrueBody = new UnifiedBlock();
			FalseBody = new UnifiedBlock();
		}

		public UnifiedIf AddToTrueBody(UnifiedExpression expression) {
			TrueBody.Add(expression);
			return this;
		}

		public UnifiedIf AddToFalseBody(UnifiedExpression expression) {
			FalseBody.Add(expression);
			return this;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Condition;
			yield return TrueBody;
			yield return FalseBody;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
			GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Condition, v => Condition = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(TrueBody, v => TrueBody = (UnifiedBlock)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(FalseBody, v => FalseBody = (UnifiedBlock)v);
		}
	}
}