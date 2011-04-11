using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   継承関係やデフォルトコンストラクタの存在などの制約を表します。
	///   継承関係を表す場合、対象の型の個数は１つです。
	///   例えば、Javaにおける"class A extends Object { .. "の"extends Object"部分に該当します。
	///   例えば、C#における"where A : new()"に該当します。
	/// </summary>
	public class UnifiedTypeConstrain : UnifiedElement
	{
		public UnifiedTypeConstrainType Kind { get; set; }

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
	}
}