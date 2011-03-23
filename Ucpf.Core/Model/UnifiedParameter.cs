using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedParameter : UnifiedElement {
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

		public string Name { get; set; }
		private UnifiedType _type;

		public UnifiedType Type {
			get { return _type; }
			set {
				if (value != null) {
					if (value.Parent != null) {
						value = (UnifiedType)value.DeepCopy();
					}
					value.Parent = this;
				}
				_type = value;
			}
		}

		public UnifiedParameter() {
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
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Type, v => Type = (UnifiedType)v);
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementAndDirectSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_type, v => _type = (UnifiedType)v);
		}
	}
}