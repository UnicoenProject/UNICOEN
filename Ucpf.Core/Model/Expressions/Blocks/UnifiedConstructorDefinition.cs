using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   コンストラクタの定義部分を表します。
	/// </summary>
	public class UnifiedConstructorDefinition
		: UnifiedExpressionWithBlock<UnifiedConstructorDefinition>
	{
		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers
		{
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private UnifiedParameterCollection _parameters;

		public UnifiedParameterCollection Parameters
		{
			get { return _parameters; }
			set { _parameters = SetParentOfChild(value, _parameters); }
		}

		public UnifiedFunctionDefinitionKind Kind { get; set; }

		private UnifiedConstructorDefinition()
		{
			Modifiers = UnifiedModifierCollection.Create();
			Parameters = UnifiedParameterCollection.Create();
		}

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data)
		{
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements()
		{
			yield return Modifiers;
			yield return Parameters;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Parameters, v => Parameters = (UnifiedParameterCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_parameters, v => _parameters = (UnifiedParameterCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedConstructorDefinition Create()
		{
			return new UnifiedConstructorDefinition();
		}

		public static UnifiedConstructorDefinition Create(UnifiedBlock body)
		{
			return new UnifiedConstructorDefinition {
				Body = body,
			};
		}

		public static UnifiedConstructorDefinition Create(UnifiedBlock body,
		                                                  UnifiedModifier modifier,
		                                                  UnifiedParameterCollection
		                                                  	parameters,
		                                                  UnifiedFunctionDefinitionKind
		                                                  	kind)
		{
			return Create(body, UnifiedModifierCollection.Create(modifier), parameters,
				kind);
		}

		public static UnifiedConstructorDefinition Create(UnifiedBlock body,
		                                                  UnifiedModifier modifier,
		                                                  UnifiedParameterCollection
		                                                  	parameters)
		{
			return Create(body, UnifiedModifierCollection.Create(modifier), parameters,
				UnifiedFunctionDefinitionKind.Constructor);
		}

		public static UnifiedConstructorDefinition Create(UnifiedBlock body,
		                                                  UnifiedModifierCollection
		                                                  	modifier,
		                                                  UnifiedParameterCollection
		                                                  	parameters)
		{
			return Create(body, modifier, parameters,
				UnifiedFunctionDefinitionKind.Constructor);
		}

		public static UnifiedConstructorDefinition Create(UnifiedBlock body,
		                                                  UnifiedModifierCollection
		                                                  	modifiers,
		                                                  UnifiedParameterCollection
		                                                  	parameters,
		                                                  UnifiedFunctionDefinitionKind
		                                                  	kind)
		{
			return new UnifiedConstructorDefinition {
				Body = body,
				Modifiers = modifiers,
				Parameters = parameters,
				Kind = kind,
			};
		}
	}
}