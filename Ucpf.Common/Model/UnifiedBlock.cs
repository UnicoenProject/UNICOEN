using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {
	public class UnifiedBlock  : IEnumerable<UnifiedExpression>{
		private readonly IList<UnifiedExpression> _statements = new List<UnifiedExpression>();

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
	}
}
