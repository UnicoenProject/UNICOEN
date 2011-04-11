using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   ジェネリクスパラメータなど型に対する実引数を表します。
	/// </summary>
	public class UnifiedTypeArgument : UnifiedElement
	{
		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers
		{
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private IUnifiedExpression _value;

		public IUnifiedExpression Value
		{
			get { return _value; }
			set { _value = SetParentOfChild(value, _value); }
		}

		private UnifiedTypeArgument() {}

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
			yield return Value;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Value, v => Value = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_value, v => _value = (IUnifiedExpression)v);
		}

		public static UnifiedTypeArgument Create(IUnifiedExpression value)
		{
			return new UnifiedTypeArgument {
				Value = value,
			};
		}

		public static UnifiedTypeArgument Create(UnifiedType type,
		                                         UnifiedModifierCollection modifiers)
		{
			return new UnifiedTypeArgument {
				Value = type,
				Modifiers = modifiers,
			};
		}
	}
}