using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedVariableDefinition : UnifiedExpression {
		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set {
				_modifiers = value;
				if (value != null) value.Parent = this;
			}
		}

		private UnifiedType _type;

		public UnifiedType Type {
			get { return _type; }
			set {
				_type = value;
				if (value != null) value.Parent = this;
			}
		}

		public string Name { get; set; }
		private UnifiedExpression _initialValue;

		public UnifiedExpression InitialValue {
			get { return _initialValue; }
			set {
				_initialValue = value;
				if (value != null) value.Parent = this;
			}
		}

		public UnifiedVariableDefinition() {
			Modifiers = new UnifiedModifierCollection();
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
			yield return Type;
			yield return InitialValue;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
			GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Type, v => Type = (UnifiedType)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(InitialValue, v => InitialValue = (UnifiedExpression)v);
		}
	}
}