using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   文字列であるリテラルを表します。
	/// </summary>
	public class UnifiedStringLiteral : UnifiedTypedLiteral<string> {
		private UnifiedStringLiteral() {}

		public UnifiedStringLiteralKind Kind { get; set; } 

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

		public static UnifiedStringLiteral Create(string value, UnifiedStringLiteralKind kind) {
			return new UnifiedStringLiteral {
					Value = value,
					Kind = kind,
			};
		}

		public static UnifiedStringLiteral CreateChar(string value) {
			return Create(value, UnifiedStringLiteralKind.Char);
		}

		public static UnifiedStringLiteral CreateString(string value) {
			return Create(value, UnifiedStringLiteralKind.String);
		}
	}
}