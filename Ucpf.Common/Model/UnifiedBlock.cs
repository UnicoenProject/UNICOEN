using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	 public class UnifiedBlock : UnifiedStatement, IEnumerable<UnifiedStatement> {
		private readonly List<UnifiedStatement> _statements;

		public UnifiedBlock() {
			_statements = new List<UnifiedStatement>();
		}

		public UnifiedBlock(IEnumerable<UnifiedStatement> statements) {
			_statements = statements.ToList();
		}

		public UnifiedStatement this[int index] {
			get { return _statements[index]; }
		}

		public void Add(UnifiedStatement stmt) {
			_statements.Add(stmt);
		}

		public IEnumerator<UnifiedStatement> GetEnumerator() {
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
