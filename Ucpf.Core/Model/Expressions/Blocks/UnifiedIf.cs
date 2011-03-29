﻿using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedIf : UnifiedExpression {
		private UnifiedExpression _condition;

		public UnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetParentOfChild(value, _condition); }
		}

		private UnifiedBlock _trueBody;

		public UnifiedBlock TrueBody {
			get { return _trueBody; }
			set { _trueBody = SetParentOfChild(value, _trueBody); }
		}

		private UnifiedBlock _falseBody;

		public UnifiedBlock FalseBody {
			get { return _falseBody; }
			set { _falseBody = SetParentOfChild(value, _falseBody); }
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

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Condition;
			yield return TrueBody;
			yield return FalseBody;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Condition, v => Condition = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(TrueBody, v => TrueBody = (UnifiedBlock)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(FalseBody, v => FalseBody = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_condition, v => _condition = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_trueBody, v => _trueBody = (UnifiedBlock)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_falseBody, v => _falseBody = (UnifiedBlock)v);
		}
	}
}