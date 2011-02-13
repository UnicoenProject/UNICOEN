using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {
	public class UnifiedBlock : IEnumerable<UnifiedStatement>{
		private readonly IList<UnifiedStatement> _statements = new List<UnifiedStatement>();

		public bool StructuralEqual(UnifiedBlock that) {
			throw new NotImplementedException();
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
