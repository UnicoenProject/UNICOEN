using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedSwitch : UnifiedExpression {
		private UnifiedExpression _value;

		public UnifiedExpression Value {
			get { return _value; }
			set {
				_value = SetParentOfChild(value, this, _value);
			}
		}

		private UnifiedCaseCollection _cases;

		public UnifiedCaseCollection Cases {
			get { return _cases; }
			set {
				_cases = SetParentOfChild(value, this, _cases);
			}
		}

		public UnifiedSwitch() {
			Cases = new UnifiedCaseCollection();
		}

		public UnifiedSwitch AddToCases(UnifiedCase kase) {
			Cases.Add(kase);
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
			yield return Value;
			yield return Cases;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Value, v => Value = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Cases, v => Cases = (UnifiedCaseCollection)v);
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_value, v => _value = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_cases, v => _cases = (UnifiedCaseCollection)v);
		}
	}
}