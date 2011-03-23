using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedTypeParameter : UnifiedElement {
		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set {
				if (value != null) {
					if (value.Parent != null) {
						value = (UnifiedModifierCollection)value.DeepCopy();
					}
					value.Parent = this;
				}
				_modifiers = value;
			}
		}

		private UnifiedExpression _value;

		public UnifiedExpression Value {
			get { return _value; }
			set {
				if (value != null) {
					if (value.Parent != null) {
						value = (UnifiedExpression)value.DeepCopy();
					}
					value.Parent = this;
				}
				_value = value;
			}
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Modifiers;
			yield return Value;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Value, v => Value = (UnifiedExpression)v);
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementAndDirectSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_value, v => _value = (UnifiedExpression)v);
		}
	}
}