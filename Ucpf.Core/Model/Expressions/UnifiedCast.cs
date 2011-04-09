using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   Cast演算子を表します。
	/// </summary>
	public class UnifiedCast : UnifiedElement, IUnifiedExpression
	{
		private UnifiedType _castType;

		public UnifiedType CastType
		{
			get { return _castType; }
			set { _castType = SetParentOfChild(value, _castType); }
		}

		private IUnifiedExpression _expression;

		public IUnifiedExpression Expression
		{
			get { return _expression; }
			set { _expression = SetParentOfChild(value, _expression); }
		}

		private UnifiedCast() {}

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
			yield return CastType;
			yield return Expression;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(CastType, v => CastType = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Expression, v => Expression = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_castType, v => _castType = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_expression, v => _expression = (IUnifiedExpression)v);
		}

		public static UnifiedCast Create(UnifiedType type,
		                                 IUnifiedExpression createExpression)
		{
			return new UnifiedCast {
				CastType = type,
				Expression = createExpression
			};
		}
	}
}