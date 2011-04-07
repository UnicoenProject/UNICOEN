using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	/// 処理を移動させる式を表します。
	/// </summary>
	public class UnifiedJump : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _value;
		public UnifiedJumpType Type { get; set; }

		public IUnifiedExpression Value {
			get { return _value; }
			set {
				_value = SetParentOfChild(value, _value);
			}
		}

		private UnifiedJump() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
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

		public static UnifiedJump Create(UnifiedJumpType type) {
			return new UnifiedJump {
				Type = type,
			};
		}

		public static UnifiedJump Create(UnifiedJumpType type, IUnifiedExpression value) {
			return new UnifiedJump {
				Type = type,
				Value = value,
			};
		}

		public static UnifiedJump CreateReturn() {
			return Create(UnifiedJumpType.Return);
		}

		public static UnifiedJump CreateReturn(IUnifiedExpression value) {
			return Create(UnifiedJumpType.Return, value);
		}

		public static UnifiedJump CreateBreak() {
			return Create(UnifiedJumpType.Break);
		}

		public static UnifiedJump CreateBreak(IUnifiedExpression value) {
			return Create(UnifiedJumpType.Break, value);
		}

		public static UnifiedJump CreateContinue() {
			return Create(UnifiedJumpType.Continue);
		}

		public static UnifiedJump CreateContinue(IUnifiedExpression value) {
			return Create(UnifiedJumpType.Continue, value);
		}

		public static UnifiedJump CreateGoto() {
			return Create(UnifiedJumpType.Goto);
		}

		public static UnifiedJump CreateGoto(IUnifiedExpression value) {
			return Create(UnifiedJumpType.Goto, value);
		}

		public static UnifiedJump CreateThrow() {
			return Create(UnifiedJumpType.Throw);
		}

		public static UnifiedJump CreateThrow(IUnifiedExpression value) {
			return Create(UnifiedJumpType.Throw, value);
		}
	}
}
