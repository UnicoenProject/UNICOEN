using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	/// switch文を表します。
	/// </summary>
	public class UnifiedSwitch : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _value;

		public IUnifiedExpression Value {
			get { return _value; }
			set {
				_value = SetParentOfChild(value, _value);
			}
		}

		private UnifiedCaseCollection _cases;

		public UnifiedCaseCollection Cases {
			get { return _cases; }
			set {
				_cases = SetParentOfChild(value, _cases);
			}
		}

		private UnifiedSwitch() {
			Cases = UnifiedCaseCollection.Create();
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

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Value;
			yield return Cases;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Value, v => Value = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Cases, v => Cases = (UnifiedCaseCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_value, v => _value = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_cases, v => _cases = (UnifiedCaseCollection)v);
		}

		public static UnifiedSwitch Create(IUnifiedExpression value) {
			return new UnifiedSwitch {
					Value = value,
			};
		}

		public static UnifiedSwitch Create(IUnifiedExpression value, UnifiedCaseCollection cases) {
			return new UnifiedSwitch {
				Value = value,
				Cases = cases,
			};
		}
	}
}