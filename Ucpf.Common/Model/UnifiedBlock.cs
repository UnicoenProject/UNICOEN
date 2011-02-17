using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {
	public class UnifiedBlock : IEnumerable<UnifiedStatement> {
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
	}
}
