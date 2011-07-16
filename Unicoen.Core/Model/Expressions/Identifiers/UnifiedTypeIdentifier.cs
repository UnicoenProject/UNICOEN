using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Unicoen.Processor;

namespace Unicoen.Model {

	/// <summary>
	/// 型を示すす識別子を表します。
	/// </summary>
	public class UnifiedTypeIdentifier : UnifiedIdentifier {

		protected internal UnifiedTypeIdentifier() {}

		[DebuggerStepThrough]
		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedTypeIdentifier Create(string name) {
			return new UnifiedTypeIdentifier {
					Name = name,
			};
		}
	}
}
