using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   boolean型であるリテラルを表します。
	/// </summary>
	public class UnifiedBooleanLiteral : UnifiedTypedLiteral<UnifiedBoolean>
	{
		private UnifiedBooleanLiteral() {}

		public static UnifiedBooleanLiteral Create(bool value)
		{
			var eValue = value ? UnifiedBoolean.True : UnifiedBoolean.False;
			return new UnifiedBooleanLiteral { Value = eValue };
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
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield break;
		}
	}
}