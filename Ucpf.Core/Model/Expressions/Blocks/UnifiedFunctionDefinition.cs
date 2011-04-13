using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   関数、メソッド、コンストラクタなどの定義部分を表します。
	/// </summary>
	public class UnifiedFunctionDefinition
		: UnifiedExpressionWithBlock<UnifiedFunctionDefinition>
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

		private UnifiedTypeParameterCollection _typeParameters;

		public UnifiedTypeParameterCollection TypeParameters
		{
			get { return _typeParameters; }
			set { _typeParameters = SetParentOfChild(value, _typeParameters); }
		}

		private UnifiedIdentifier _name;

		public UnifiedIdentifier Name
		{
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private UnifiedParameterCollection _parameters;

		public UnifiedParameterCollection Parameters
		{
			get { return _parameters; }
			set { _parameters = SetParentOfChild(value, _parameters); }
		}

		private UnifiedTypeCollection _throws;

		public UnifiedTypeCollection Throws
		{
			get { return _throws; }
			set { _throws = SetParentOfChild(value, _throws); }
		}

		private UnifiedFunctionDefinition()
		{
			Modifiers = UnifiedModifierCollection.Create();
			Parameters = UnifiedParameterCollection.Create();
			Body = UnifiedBlock.Create();
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
			yield return TypeParameters;
			yield return Name;
			yield return Parameters;
			yield return Throws;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Type, v => Type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(TypeParameters, v => TypeParameters = (UnifiedTypeParameterCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Name, v => Name = (UnifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Parameters, v => Parameters = (UnifiedParameterCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Throws, v => Throws = (UnifiedTypeCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_type, v => _type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_typeParameters, v => _typeParameters = (UnifiedTypeParameterCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_name, v => _name = (UnifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_parameters, v => _parameters = (UnifiedParameterCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_throws, v => _throws = (UnifiedTypeCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedFunctionDefinition CreateFunction(UnifiedIdentifier name,
		                                                       UnifiedType type,
		                                                       UnifiedModifierCollection
		                                                       	modifiers,
		                                                       UnifiedParameterCollection
		                                                       	parameters,
		                                                       UnifiedTypeCollection
		                                                       	throws,
		                                                       UnifiedBlock body)
		{
			return new UnifiedFunctionDefinition {
				Name = name,
				Type = type,
				Modifiers = modifiers,
				Parameters = parameters,
				Throws = throws,
				Body = body,
			};
		}

		public static UnifiedFunctionDefinition CreateFunction(UnifiedIdentifier name)
		{
			return CreateFunction(name, null, UnifiedModifierCollection.Create(),
				UnifiedParameterCollection.Create(), null, UnifiedBlock.Create());
		}

		public static UnifiedFunctionDefinition CreateFunction(UnifiedIdentifier name,
		                                                       UnifiedType type,
		                                                       UnifiedModifierCollection
		                                                       	modifiers,
		                                                       UnifiedParameterCollection
		                                                       	parameters)
		{
			return CreateFunction(name, type, modifiers, parameters, null,
				UnifiedBlock.Create());
		}

		public static UnifiedFunctionDefinition CreateFunction(UnifiedIdentifier name,
		                                                       UnifiedType type,
		                                                       UnifiedModifierCollection
		                                                       	modifiers,
		                                                       UnifiedParameterCollection
		                                                       	parameters,
		                                                       UnifiedBlock body)
		{
			return CreateFunction(name, type, modifiers, parameters, null, body);
		}

		public static UnifiedFunctionDefinition CreateFunction(UnifiedIdentifier name,
		                                                       UnifiedParameterCollection
		                                                       	parameters,
		                                                       UnifiedBlock body)
		{
			return CreateFunction(name, null, UnifiedModifierCollection.Create(),
				parameters,
				null, body);
			;
		}

		public static UnifiedFunctionDefinition CreateFunction(UnifiedIdentifier name,
		                                                       UnifiedParameterCollection
		                                                       	parameters)
		{
			return CreateFunction(name, null, UnifiedModifierCollection.Create(),
				parameters,
				null, UnifiedBlock.Create());
		}

		public static UnifiedFunctionDefinition CreateFunction(UnifiedIdentifier name,
		                                                       UnifiedType type,
		                                                       UnifiedBlock body)
		{
			return CreateFunction(name, type, UnifiedModifierCollection.Create(),
				UnifiedParameterCollection.Create(), null, body);
		}

		public static UnifiedFunctionDefinition CreateFunction(UnifiedIdentifier name,
		                                                       UnifiedType type,
		                                                       UnifiedModifierCollection
		                                                       	modifiers,
		                                                       UnifiedBlock body)
		{
			return CreateFunction(name, type, modifiers,
				UnifiedParameterCollection.Create(),
				null, body);
		}

		public static UnifiedFunctionDefinition CreateFunction(string name,
		                                                       UnifiedType type,
		                                                       UnifiedModifierCollection
		                                                       	modifiers,
		                                                       UnifiedParameterCollection
		                                                       	parameters,
		                                                       UnifiedTypeCollection
		                                                       	throws,
		                                                       UnifiedBlock body)
		{
			return CreateFunction(
				UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Function), type,
				modifiers, parameters, throws, body);
		}

		public static UnifiedFunctionDefinition CreateFunction(string name)
		{
			return CreateFunction(name, null, UnifiedModifierCollection.Create(),
				UnifiedParameterCollection.Create(), null, UnifiedBlock.Create());
		}

		public static UnifiedFunctionDefinition CreateFunction(string name,
		                                                       UnifiedType type,
		                                                       UnifiedModifierCollection
		                                                       	modifiers,
		                                                       UnifiedParameterCollection
		                                                       	parameters)
		{
			return CreateFunction(name, type, modifiers, parameters, null,
				UnifiedBlock.Create());
		}

		public static UnifiedFunctionDefinition CreateFunction(string name,
		                                                       UnifiedType type,
		                                                       UnifiedModifierCollection
		                                                       	modifiers,
		                                                       UnifiedParameterCollection
		                                                       	parameters,
		                                                       UnifiedBlock body)
		{
			return CreateFunction(name, type, modifiers, parameters, null, body);
		}

		public static UnifiedFunctionDefinition CreateFunction(string name,
		                                                       UnifiedParameterCollection
		                                                       	parameters,
		                                                       UnifiedBlock body)
		{
			return CreateFunction(name, null, UnifiedModifierCollection.Create(),
				parameters,
				null, body);
		}

		public static UnifiedFunctionDefinition CreateFunction(string name,
		                                                       UnifiedParameterCollection
		                                                       	parameters)
		{
			return CreateFunction(name, null, UnifiedModifierCollection.Create(),
				parameters,
				null, UnifiedBlock.Create());
		}

		public static UnifiedFunctionDefinition CreateFunction(string name,
		                                                       UnifiedType type,
		                                                       UnifiedBlock body)
		{
			return CreateFunction(name, type, UnifiedModifierCollection.Create(),
				UnifiedParameterCollection.Create(), null, body);
		}

		public static UnifiedFunctionDefinition CreateFunction(string name,
		                                                       UnifiedType type,
		                                                       UnifiedModifierCollection
		                                                       	modifiers,
		                                                       UnifiedBlock body)
		{
			return CreateFunction(name, type, modifiers,
				UnifiedParameterCollection.Create(),
				null, body);
		}
	}
}