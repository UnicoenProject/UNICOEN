using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   変数宣言部分を表します。
	/// </summary>
	public class UnifiedVariableDefinition : UnifiedElement, IUnifiedExpression
	{
		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers
		{
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private UnifiedType _type;

		public UnifiedType Type
		{
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedIdentifier _name;

		public UnifiedIdentifier Name
		{
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private IUnifiedExpression _initialValue;

		public IUnifiedExpression InitialValue
		{
			get { return _initialValue; }
			set { _initialValue = SetParentOfChild(value, _initialValue); }
		}

		private UnifiedVariableDefinition()
		{
			Modifiers = UnifiedModifierCollection.Create();
		}

		public static UnifiedVariableDefinition Create(UnifiedType type, string name)
		{
			return new UnifiedVariableDefinition {
				Type = type,
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierType.Variable),
			};
		}

		public static UnifiedVariableDefinition Create(string name)
		{
			return new UnifiedVariableDefinition {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierType.Variable),
			};
		}

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements()
		{
			yield return Modifiers;
			yield return Type;
			yield return Name;
			yield return InitialValue;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Type, v => Type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Name, v => Name = (UnifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(InitialValue, v => InitialValue = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_type, v => _type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_name, v => _name = (UnifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_initialValue, v => _initialValue = (IUnifiedExpression)v);
		}

		public static UnifiedVariableDefinition Create(string name,
		                                               IUnifiedExpression initialValue)
		{
			return new UnifiedVariableDefinition {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierType.Variable),
				InitialValue = initialValue,
			};
		}

		public static UnifiedVariableDefinition Create(UnifiedType type, string name,
		                                               IUnifiedExpression initialValue)
		{
			return new UnifiedVariableDefinition {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierType.Variable),
				Type = type,
				InitialValue = initialValue,
			};
		}

		public static UnifiedVariableDefinition Create(UnifiedType type,
		                                               UnifiedModifierCollection
		                                               	modifiers,
		                                               IUnifiedExpression initialValue,
		                                               string name)
		{
			return new UnifiedVariableDefinition {
				Type = type,
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierType.Variable),
				InitialValue = initialValue,
				Modifiers = modifiers,
			};
		}

		public static UnifiedVariableDefinition Create(UnifiedType type, string name,
		                                               UnifiedModifierCollection
		                                               	modifiers)
		{
			return new UnifiedVariableDefinition {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierType.Variable),
				Modifiers = modifiers,
				Type = type,
			};
		}
	}
}