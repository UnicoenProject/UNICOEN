using Ucpf.Core.Model.Expressions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedForeach : UnifiedExpressionWithBlock<UnifiedForeach> {
		public UnifiedVariableDefinition Element { get; set; }
		public UnifiedExpression Set { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
