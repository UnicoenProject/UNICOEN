using System;
using Ucpf.Core.Model.Expressions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedFunctionDefinition : UnifiedExpressionWithBlock<UnifiedFunctionDefinition> {
		public UnifiedModifierCollection Modifiers { get; set; }
		public UnifiedType Type { get; set; }
		public string Name { get; set; }
		public UnifiedParameterCollection Parameters { get; set; }

		public UnifiedFunctionDefinition() {
			Modifiers = new UnifiedModifierCollection();
			Parameters = new UnifiedParameterCollection();
			Body = new UnifiedBlock();
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
	}
}