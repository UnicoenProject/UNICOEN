using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   予約語によって表現される特殊な式（ステートメント含む）を表します。
	/// </summary>
	public class UnifiedSpecialExpression : UnifiedElement, IUnifiedExpression {
		public UnifiedSpecialExpressionKind Kind { get; set; }

		private IUnifiedExpression _value;

		public IUnifiedExpression Value {
			get { return _value; }
			set { _value = SetParentOfChild(value, _value); }
		}

		private UnifiedSpecialExpression() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Value;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Value, v => Value = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_value, v => _value = (IUnifiedExpression)v);
		}

		public static UnifiedSpecialExpression Create(
				UnifiedSpecialExpressionKind kind) {
			return new UnifiedSpecialExpression {
					Kind = kind,
			};
		}

		public static UnifiedSpecialExpression Create(
				UnifiedSpecialExpressionKind kind,
				IUnifiedExpression value) {
			return new UnifiedSpecialExpression {
					Kind = kind,
					Value = value,
			};
		}

		public static UnifiedSpecialExpression CreateReturn() {
			return Create(UnifiedSpecialExpressionKind.Return);
		}

		public static UnifiedSpecialExpression CreateReturn(IUnifiedExpression value) {
			return Create(UnifiedSpecialExpressionKind.Return, value);
		}

		public static UnifiedSpecialExpression CreateBreak() {
			return Create(UnifiedSpecialExpressionKind.Break);
		}

		public static UnifiedSpecialExpression CreateBreak(IUnifiedExpression value) {
			return Create(UnifiedSpecialExpressionKind.Break, value);
		}

		public static UnifiedSpecialExpression CreateContinue() {
			return Create(UnifiedSpecialExpressionKind.Continue);
		}

		public static UnifiedSpecialExpression CreateContinue(IUnifiedExpression value) {
			return Create(UnifiedSpecialExpressionKind.Continue, value);
		}

		public static UnifiedSpecialExpression CreateGoto() {
			return Create(UnifiedSpecialExpressionKind.Goto);
		}

		public static UnifiedSpecialExpression CreateGoto(IUnifiedExpression value) {
			return Create(UnifiedSpecialExpressionKind.Goto, value);
		}

		public static UnifiedSpecialExpression CreateThrow() {
			return Create(UnifiedSpecialExpressionKind.Throw);
		}

		public static UnifiedSpecialExpression CreateThrow(IUnifiedExpression value) {
			return Create(UnifiedSpecialExpressionKind.Throw, value);
		}
	}
}