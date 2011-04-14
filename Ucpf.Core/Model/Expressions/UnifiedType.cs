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
		private UnifiedQualifiedIdentifier _name;

		public UnifiedQualifiedIdentifier Name
		{
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private UnifiedTypeArgumentCollection _arguments;

		public UnifiedTypeArgumentCollection Arguments
		{
			get { return _arguments; }
			set { _arguments = SetParentOfChild(value, _arguments); }
		}

		private UnifiedTypeSupplementCollection _supplements;

		/// <summary>
		///   Javaにおける<c>int[10] a;</c>の<c>[10]</c>部分、
		///   Cにおける<c>int** a;</c>の<c>**</c>部分、
		///   <c>int[] a;</c>の<c>[]</c>部分などが該当します。
		/// </summary>
		public UnifiedTypeSupplementCollection Supplements
		{
			get { return _supplements; }
			set { _supplements = SetParentOfChild(value, _supplements); }
		}

		private UnifiedType()
		{
			Arguments = UnifiedTypeArgumentCollection.Create();
		}

		public UnifiedType AddToParameters(IUnifiedExpression expression)
		{
			Arguments.Add(expression.ToTypeParameter());
			return this;
		}

		public UnifiedType AddToParameters(UnifiedTypeArgument argument)
		{
			Arguments.Add(argument);
			return this;
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
			yield return Name;
			yield return Arguments;
			yield return Supplements;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Name, v => Name = (UnifiedQualifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Arguments, v => Arguments = (UnifiedTypeArgumentCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Supplements, v => Supplements = (UnifiedTypeSupplementCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_name, v => _name = (UnifiedQualifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_arguments, v => _arguments = (UnifiedTypeArgumentCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_supplements, v => _supplements = (UnifiedTypeSupplementCollection)v);
		}

		public void AddSupplement(UnifiedTypeSupplement supplement)
		{
			if (Supplements == null)
				Supplements = UnifiedTypeSupplementCollection.Create();
			Supplements.Add(supplement);
		}

		public void AddSupplementRange(IEnumerable<UnifiedTypeSupplement> supplements)
		{
			if (Supplements == null)
				Supplements = UnifiedTypeSupplementCollection.Create();
			Supplements.AddRange(supplements);
		}

		public static UnifiedType CreateUsingString(string name)
		{
			return CreateUsingString(name, null, null);
		}

		public static UnifiedType CreateUsingString(string name,
		                                            UnifiedTypeArgumentCollection
		                                            	arguments)
		{
			return CreateUsingString(name, arguments, null);
		}

		public static UnifiedType CreateUsingString(string name,
		                                            UnifiedTypeArgumentCollection
		                                            	arguments,
		                                            UnifiedTypeSupplementCollection
		                                            	supplements)
		{
			return new UnifiedType {
				Name = name != null
				       	? UnifiedIdentifier.CreateType(name).ToQualified()
				       	: null,
				Arguments = arguments,
				Supplements = supplements,
			};
		}

		public static UnifiedType Create(UnifiedIdentifier name,
		                                 UnifiedTypeArgumentCollection arguments,
		                                 UnifiedTypeSupplementCollection supplements)
		{
			return new UnifiedType {
				Name = name.ToQualified(),
				Arguments = arguments,
				Supplements = supplements,
			};
		}

		public static UnifiedType Create(UnifiedQualifiedIdentifier name,
		                                 UnifiedTypeArgumentCollection arguments,
		                                 UnifiedTypeSupplementCollection supplements)
		{
			return new UnifiedType {
				Name = name,
				Arguments = arguments,
				Supplements = supplements,
			};
		}

		public static UnifiedType CreateArray(string name)
		{
			return CreateUsingString(name, null, UnifiedTypeSupplementCollection.Create(
				UnifiedTypeSupplement.CreateArray()));
		}

		public static UnifiedType CreateArray(string name, UnifiedArgument argument)
		{
			return new UnifiedType {
				Name = name != null
				       	? UnifiedIdentifier.CreateType(name).ToQualified()
				       	: null,
				Arguments = null,
				Supplements = UnifiedTypeSupplementCollection.Create(
					UnifiedTypeSupplement.CreateArray(argument)),
			};
		}
	}
}