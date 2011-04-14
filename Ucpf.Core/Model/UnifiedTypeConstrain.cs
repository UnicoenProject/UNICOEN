using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   継承関係やデフォルトコンストラクタの存在などの制約を表します。
	///   なお、継承関係を表す場合、対象の型の個数は１つです。
	///   e.g. Javaにおける継承関係の制約(<c>class C extends P { ... }</c>の<c>extends P</c>部分)
	///   e.g. C#におけるデフォルトコンストラクタの制約(<c>where A : new()</c>の<c>: new()</c>部分)
	/// </summary>
	public class UnifiedTypeConstrain : UnifiedElement
	{
		public UnifiedTypeConstrainKind Kind { get; set; }

		private UnifiedType _type;

		public UnifiedType Type
		{
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedTypeConstrain() {}

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
			yield return Type;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Type, v => Type = (UnifiedType)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_type, v => _type = (UnifiedType)v);
		}

		public static UnifiedTypeConstrain Create(UnifiedType type,
		                                          UnifiedTypeConstrainKind kind)
		{
			return new UnifiedTypeConstrain {
				Type = type,
				Kind = kind,
			};
		}

		public static UnifiedTypeConstrain CreateExtends(UnifiedType type)
		{
			return Create(type, UnifiedTypeConstrainKind.Extends);
		}

		public static UnifiedTypeConstrain CreateImplements(UnifiedType type)
		{
			return Create(type, UnifiedTypeConstrainKind.Implements);
		}

		public static UnifiedTypeConstrain CreateExtendsOrImplements(UnifiedType type)
		{
			return Create(type, UnifiedTypeConstrainKind.ExtendsOrImplements);
		}
	}
}