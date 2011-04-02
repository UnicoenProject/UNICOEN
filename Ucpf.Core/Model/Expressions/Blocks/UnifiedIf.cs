using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedIf : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _condition;

		public IUnifiedExpression Condition {
			get { return _condition; }
			set {
				_condition = SetParentOfChild(value, _condition);
			}
		}

		private UnifiedBlock _trueBody;

		public UnifiedBlock TrueBody {
			get { return _trueBody; }
			set {
				_trueBody = SetParentOfChild(value, _trueBody);
			}
		}

		private UnifiedBlock _falseBody;

		public UnifiedBlock FalseBody {
			get { return _falseBody; }
			set {
				_falseBody = SetParentOfChild(value, _falseBody);
			}
		}

		public UnifiedIf() {
			TrueBody = new UnifiedBlock();
			FalseBody = new UnifiedBlock();
		}

		public UnifiedIf AddToTrueBody(IUnifiedExpression expression) {
			TrueBody.Add(expression);
			return this;
		}

		public UnifiedIf AddToFalseBody(IUnifiedExpression expression) {
			FalseBody.Add(expression);
			return this;
		}

		public UnifiedIf RemoveFalseBody() {
			FalseBody = null;
			return this;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Condition;
			yield return TrueBody;
			yield return FalseBody;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Condition, v => Condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(TrueBody, v => TrueBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(FalseBody, v => FalseBody = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_condition, v => _condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_trueBody, v => _trueBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_falseBody, v => _falseBody = (UnifiedBlock)v);
		}
	}
}