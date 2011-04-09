using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	/// プロパティを表します。
	/// </summary>
	public class UnifiedProperty : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _owner;

		public IUnifiedExpression Owner {
			get { return _owner; }
			set {
				_owner = SetParentOfChild(value, _owner);
			}
		}

		private UnifiedIdentifier _name;

		public UnifiedIdentifier Name {
			get { return _name; }
			set {
				_name = SetParentOfChild(value, _name);
			}
		}

		public string Delimiter { get; set; }

		private UnifiedProperty() { }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Owner;
			yield return Name;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Owner, v => Owner = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Name, v => Name = (UnifiedIdentifier)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_owner, v => _owner = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_name, v => _name = (UnifiedIdentifier)v);
		}

		public static UnifiedProperty Create(IUnifiedExpression owner, UnifiedIdentifier name, string delimite) {
			return new UnifiedProperty {
				Owner = owner,
				Name = name,
				Delimiter = delimite,
			};
		}

		public static UnifiedProperty Create(IUnifiedExpression owner, string name, string delimite) {
			return new UnifiedProperty {
				Owner = owner,
				Name = UnifiedIdentifier.CreateUnknown(name),
				Delimiter = delimite,
			};
		}
	}
}