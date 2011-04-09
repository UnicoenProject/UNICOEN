using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	/// クラスの定義部分を表します。
	/// </summary>
	public class UnifiedClassDefinition
			: UnifiedExpressionWithBlock<UnifiedClassDefinition> {
		public UnifiedClassType Type { get; set; }

		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set {
				_modifiers = SetParentOfChild(value, _modifiers);
			}
		}

		private UnifiedIdentifier _name;

		// TODO: A.B.C を UnifiedPropertyで表現
		public UnifiedIdentifier Name {
			get { return _name; }
			set {
				_name = SetParentOfChild(value, _name);
			}
		}

		private UnifiedClassDefinition() {
			Modifiers = UnifiedModifierCollection.Create();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Modifiers;
			yield return Name;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Name, v => Name= (UnifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_name, v => _name= (UnifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedClassDefinition Create(UnifiedIdentifier name, UnifiedBlock body, UnifiedModifierCollection modifiers, UnifiedClassType type) {
			return new UnifiedClassDefinition {
				Body = body,
				Name = name,
				Modifiers = modifiers,
				Type = type,
			};
		}

		public static UnifiedClassDefinition CreateClass(UnifiedIdentifier name) {
			return Create(name, UnifiedBlock.Create(), UnifiedModifierCollection.Create(), UnifiedClassType.Class);
		}

		public static UnifiedClassDefinition CreateClass(UnifiedIdentifier name, UnifiedModifierCollection modifiers) {
			return Create(name, UnifiedBlock.Create(), modifiers, UnifiedClassType.Class);
		}

		public static UnifiedClassDefinition CreateClass(UnifiedIdentifier name, UnifiedBlock body) {
			return Create(name, body, UnifiedModifierCollection.Create(), UnifiedClassType.Class);
		}

		public static UnifiedClassDefinition CreateClass(UnifiedIdentifier name, UnifiedBlock body, UnifiedModifierCollection modifiers) {
			return Create(name, body, modifiers, UnifiedClassType.Class);
		}

		public static UnifiedClassDefinition CreateClass(string name) {
			return Create(UnifiedIdentifier.Create(name, UnifiedIdentifierType.Type),
					UnifiedBlock.Create(), UnifiedModifierCollection.Create(), UnifiedClassType.Class);
		}

		public static UnifiedClassDefinition CreateClass(string name, UnifiedModifierCollection modifiers) {
			return Create(UnifiedIdentifier.Create(name, UnifiedIdentifierType.Type),
					UnifiedBlock.Create(), modifiers, UnifiedClassType.Class);
		}

		public static UnifiedClassDefinition CreateClass(string name, UnifiedBlock body) {
			return Create(UnifiedIdentifier.Create(name, UnifiedIdentifierType.Type),
					body, UnifiedModifierCollection.Create(), UnifiedClassType.Class);
		}

		public static UnifiedClassDefinition CreateClass(string name, UnifiedBlock body, UnifiedModifierCollection modifiers) {
			return Create(UnifiedIdentifier.Create(name, UnifiedIdentifierType.Type),
					body, modifiers, UnifiedClassType.Class);
		}
	}
}