using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   修飾子を表します。
	///   e.g. Javaにおける<code>public int methd(){...}</code>や<code>private String _str</code>の，<code>public</code>や<code>private</code>
	/// </summary>
	public class UnifiedModifier : UnifiedElement {
		/// <summary>
		/// 修飾子の名前を表します
		/// </summary>
		public string Name { get; set; }

		private UnifiedModifier() {}

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

		public static UnifiedModifier Create(string name) {
			return new UnifiedModifier { Name = name };
		}
	}
}