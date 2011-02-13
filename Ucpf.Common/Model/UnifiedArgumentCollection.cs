using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {

	public class UnifiedArgumentCollection : IEnumerable<UnifiedArgument> {

		private readonly List<UnifiedArgument> _args = new List<UnifiedArgument>();

		public void Add(UnifiedArgument arg) {
			_args.Add(arg);
		}

		public IEnumerator<UnifiedArgument> GetEnumerator() {
			return _args.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
