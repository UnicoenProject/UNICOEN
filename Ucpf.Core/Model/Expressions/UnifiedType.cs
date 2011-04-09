using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Extensions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   型を表します。
	/// </summary>
	public class UnifiedType : UnifiedElement, IUnifiedExpression
	{
		private UnifiedIdentifier _name;

		public UnifiedIdentifier Name
		{
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private UnifiedTypeParameterCollection _parameters;

		public UnifiedTypeParameterCollection Parameters
		{
			get { return _parameters; }
			set { _parameters = SetParentOfChild(value, _parameters); }
		}

		private UnifiedType()
		{
			Parameters = UnifiedTypeParameterCollection.Create();
		}

		public UnifiedType AddToParameters(IUnifiedExpression expression)
		{
			Parameters.Add(expression.ToTypeParameter());
			return this;
		}

		public UnifiedType AddToParameters(UnifiedTypeParameter parameter)
		{
			Parameters.Add(parameter);
			return this;
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
			yield return Name;
			yield return Parameters;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Name, v => Name = (UnifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Parameters, v => Parameters = (UnifiedTypeParameterCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_name, v => _name = (UnifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_parameters, v => _parameters = (UnifiedTypeParameterCollection)v);
		}

		public static UnifiedType Create(string name)
		{
			return new UnifiedType {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierType.Type),
			};
		}

		public static UnifiedType Create(string name,
		                                 UnifiedTypeParameterCollection parameters)
		{
			return new UnifiedType {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierType.Type),
				Parameters = parameters,
			};
		}
	}
}