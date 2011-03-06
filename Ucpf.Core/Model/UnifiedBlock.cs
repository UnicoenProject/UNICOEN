using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedBlock : UnifiedExpression, IEnumerable<UnifiedExpression> {
		private readonly List<UnifiedExpression> _statements;

		public UnifiedBlock() {
			_statements = new List<UnifiedExpression>();
		}

		public UnifiedBlock(IEnumerable<UnifiedExpression> statements) {
			_statements = statements.ToList();
		}

		public UnifiedExpression this[int index] {
			get { return _statements[index]; }
		}

		public void Add(UnifiedExpression stmt) {
			_statements.Add(stmt);
		}

		public IEnumerator<UnifiedExpression> GetEnumerator() {
			return _statements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}