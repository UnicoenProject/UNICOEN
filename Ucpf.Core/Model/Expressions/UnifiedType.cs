using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedType : UnifiedExpression {
		public string Name { get; set; }
		public List<UnifiedExpression> Parameters { get; set; }

		public static UnifiedType Create(string name) {
			return new UnifiedType {
				Name = name,
			};
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield break;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementsAndSetters() {
			yield break;
		}
	}
}