using System;
using System.Collections.Generic;
using System.Numerics;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   整数のリテラルを表します。
	/// </summary>
	public class UnifiedIntegerLiteral : UnifiedTypedLiteral<BigInteger> {
		private UnifiedIntegerLiteral() {}

		public UnifiedIntegerLiteralKind Kind { get; set; }

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
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield break;
		}

		public static UnifiedIntegerLiteral Create(BigInteger value, UnifiedIntegerLiteralKind kind) {
			return new UnifiedIntegerLiteral {
					Value = value,
					Kind = kind,
			};
		}

		public static UnifiedIntegerLiteral Create(int value) {
			return Create(value, UnifiedIntegerLiteralKind.Int32);
		}

		public static UnifiedIntegerLiteral CreateInt32(BigInteger value) {
			return Create(value, UnifiedIntegerLiteralKind.Int32);
		}

		public static UnifiedIntegerLiteral Create(long value) {
			return Create(value, UnifiedIntegerLiteralKind.Int64);
		}

		public static UnifiedIntegerLiteral CreateInt64(BigInteger value) {
			return Create(value, UnifiedIntegerLiteralKind.Int64);
		}

		public static UnifiedIntegerLiteral Create(BigInteger value) {
			return Create(value, UnifiedIntegerLiteralKind.BigInteger);
		}

		public static UnifiedIntegerLiteral CreateBigInteger(BigInteger value) {
			return Create(value, UnifiedIntegerLiteralKind.BigInteger);
		}
	}
}